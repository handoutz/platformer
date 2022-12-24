﻿using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PlatformerGame.Engine.Game;
using PlatformerGame.Engine.Game.Levels;

namespace PlatformerGame.Engine
{
    public class Engine
    {
        public Thread GameThread { get; set; }
        public object Sync { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        private volatile int _frameCt;
        public int FrameCount => _frameCt;

        public event Action<EngineStateUpdate> Frame;
        public Level Level { get; set; }
        public ConcurrentStack<KeyEvent> Keys { get; set; } = new();

        public event Action<string> LogEvent;

        public Engine()
        {
            Level = new LevelOne();
            GameThread = new Thread(new ThreadStart(GameLoop));
            Sync = new();
            CancellationTokenSource = new();
        }

        public void KeyDown(KeyEventArgs e)
        {
            var ke = new KeyEvent()
            {
                Edge = true,
                Down = true,
                Key = e.KeyData
            };
            Keys.Push(ke);
            OnLogEvent($"KeyDown {ke}");
        }

        public void KeyUp(KeyEventArgs e)
        {
            var ke = new KeyEvent()
            {
                Edge = true,
                Down = false,
                Key = e.KeyData
            };
            Keys.Push(ke);
            OnLogEvent($"KeyUp {ke}");
        }

        public void Start()
        {
            GameThread.Start();
        }

        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }

        public Bitmap GetBitmap()
        {
            const int sz = 8;
            var bm = new Bitmap(Level.Grid.Width*sz, Level.Grid.Height*sz);
            using var g = Graphics.FromImage(bm);
            for (int x = 0; x < Level.Grid.Width; x++)
            {
                for (int y = 0; y < Level.Grid.Height; y++)
                {
                    //bm.SetPixel(x, y, Level.Grid.Squares[x, y].Color);
                    g.FillRectangle(new SolidBrush(Level.Grid.Squares[x, y].Color), x * sz, y * sz, sz, sz);
                }
            }

            return bm;
        }

        private void GameLoop()
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                while (!CancellationTokenSource.IsCancellationRequested)
                {
                    lock (Sync)
                    {
                        _frameCt++;
                        var upd = new EngineStateUpdate()
                        {
                            ElapsedMilliseconds = sw.ElapsedMilliseconds,
                            FrameNumber = _frameCt,
                            Bitmap = GetBitmap()
                        };

                        //process key events
                        while (Keys.TryPop(out var keyEvent))
                        {
                            Level.OnProcessKey(keyEvent);
                        }

                        OnFrame(upd);
                        Level.OnFrame(upd);
                        Thread.Sleep(10);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        protected virtual void OnFrame(EngineStateUpdate obj)
        {
            Frame?.Invoke(obj);
        }

        protected virtual void OnLogEvent(string obj)
        {
            LogEvent?.Invoke(obj);
        }
    }
}