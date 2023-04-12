using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PlatformerGame.Engine.Game;
using PlatformerGame.Engine.Game.Actors;
using PlatformerGame.Engine.Game.Levels;
using PlatformerGame.Engine.Interface;
using PlatformerGame.Engine.Scripting;

namespace PlatformerGame.Engine
{
    public class Engine : IAcceptFrames
    {
        public static Engine Instance { get; set; }
        public ActorList Actors { get; set; } = new();
        public ScriptManager ScriptManager { get; set; } = new();
        public List<Script> Scripts => ScriptManager.Scripts;
        public Thread GameThread { get; set; }
        public static object Sync { get; set; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        private volatile int _frameCt;
        public int FrameCount => _frameCt;

        public event Action<EngineStateUpdate> Frame;
        public Level Level { get; set; }
        public ConcurrentStack<KeyEvent> Keys { get; set; } = new();

        public HeadsUpDisplay Hud { get; set; } = new();

        public event Action<string> LogEvent;

        public Engine()
        {
            Instance = this;
            Actors = new();
            Actors.Add(new PlayerActor());

            Scripts.Add(new ObjectiveScript());
            Level = new ActorLevel(this);
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
                Key = e.KeyData,
                Frame = _frameCt
            };
            Keys.Push(ke);
            //OnLogEvent($"KeyDown {ke}");
        }

        public void KeyUp(KeyEventArgs e)
        {
            var ke = new KeyEvent()
            {
                Edge = true,
                Down = false,
                Key = e.KeyData,
                Frame = _frameCt
            };
            Keys.Push(ke);
            //OnLogEvent($"KeyUp {ke}");
        }

        public void Start()
        {
            foreach (var s in Scripts)
            {
                s.OnLoad(this);
            }
            GameThread.Start();
        }

        public void Stop()
        {
            CancellationTokenSource.Cancel();
        }

        public Bitmap GetBitmap(EngineStateUpdate update)
        {
            const int sz = GameConstants.PIXEL_SIZE;
            var bm = new Bitmap(Level.Grid.Width * sz, Level.Grid.Height * sz);
            using var g = Graphics.FromImage(bm);
            for (int x = 0; x < Level.Grid.Width; x++)
            {
                for (int y = 0; y < Level.Grid.Height; y++)
                {
                    //bm.SetPixel(x, y, Level.Grid.Squares[x, y].Color);
                    g.FillRectangle(new SolidBrush(Level.Grid.Squares[x, y].Color), x * sz, y * sz, sz, sz);
                }
            }

            foreach (var actor in Actors)
            {
                var x = actor.X;
                var y = actor.Y;
                var color = actor.Color;
                g.FillRectangle(new SolidBrush(color), x * sz, y * sz, sz, sz);
            }

            update.Size = sz;
            Hud.Draw(bm, update, g);
            return bm;
        }

        private void ProcessKeys()
        {
            if (KeyEvent.IsLeftPressed())
            {
                KeyDown(new KeyEventArgs(System.Windows.Forms.Keys.A));
            }
            else
            {
                KeyUp(new KeyEventArgs(System.Windows.Forms.Keys.A));
            }

            if (KeyEvent.IsRightPressed())
            {
                KeyDown(new KeyEventArgs(System.Windows.Forms.Keys.D));
            }
            else
            {
                KeyUp(new KeyEventArgs(System.Windows.Forms.Keys.D));
            }

            if (KeyEvent.IsUpPressed())
            {
                KeyDown(new KeyEventArgs(System.Windows.Forms.Keys.W));
            }
            else
            {
                KeyUp(new KeyEventArgs(System.Windows.Forms.Keys.W));
            }

            if (KeyEvent.IsDownPressed())
            {
                KeyDown(new KeyEventArgs(System.Windows.Forms.Keys.S));
            }
            else
            {
                KeyUp(new KeyEventArgs(System.Windows.Forms.Keys.S));
            }
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
                            Level = Level,
                            Engine = this
                        };
                        upd.Bitmap = GetBitmap(upd);
                        if (_frameCt % 2 == 0)
                            ProcessKeys();
                        Level.OnFrame(upd);
                        //process key events
                        while (Keys.TryPop(out var keyEvent))
                        {
                            Level.OnProcessKey(keyEvent);
                        }
                        Scripts.ForEach(s => s.BeforeFrame(upd));
                        OnFrame(upd);
                        Scripts.ForEach(s => s.OnFrame(upd));
                        Scripts.ForEach(s => s.AfterFrame(upd));
                        Actors.AfterFrame(upd);
                        Thread.Sleep(30);
                    }
                }
            }
            catch (Exception e)
            {
                OnLogEvent($"fucked: {e}");
            }
        }

        public virtual void OnFrame(EngineStateUpdate obj)
        {
            Frame?.Invoke(obj);
        }

        public virtual void OnLogEvent(string obj)
        {
            LogEvent?.Invoke(obj);
        }
    }
}