using PlatformerGame.Engine;
using System.ComponentModel;
using System.Media;

namespace PlatformerGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Engine.Engine Engine { get; set; }
        private Engine.Engine _engine => Engine;

        private void Form1_Load(object sender, EventArgs e)
        {
            Engine = new();
            Engine.Frame += Engine_Frame;
            Engine.LogEvent += Engine_LogEvent;
            Engine.Sound.StartSound += Sound_StartSound;
            Engine.Start();
            Controls.Add(new GameDisplay(Engine)
            {
                Dock = DockStyle.Fill
            });
            /*KeyDown += GameDisplay_KeyDown;
            KeyUp += GameDisplay_KeyUp;*/
            KeyPreview = true;
        }

        private void Sound_StartSound(Engine.Sound.SoundEventArgs obj)
        {
            this.Post(() =>
            {
                var snd = new SoundPlayer(obj.SoundName);
                if (obj.Loop)
                {
                    snd.PlayLooping();
                }
                else
                {
                    snd.Play();
                }
            });
        }

        private void GameDisplay_KeyUp(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up
                && e.KeyCode != Keys.Down)
            {

            }
            else
            {
                _engine.KeyUp(e);
            }
        }

        private void GameDisplay_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Right && e.KeyCode != Keys.Left && e.KeyCode != Keys.Up
                && e.KeyCode != Keys.Down)
            {

            }
            else
            {
                _engine.KeyDown(e);
            }
        }

        private void Engine_LogEvent(string obj)
        {
            this.Post(() =>
            {
                rtbLog.AppendText($"{obj}\r\n");
                rtbLog.SelectionStart = rtbLog.Text.Length;
                rtbLog.ScrollToCaret();
            });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Engine.Stop();
            base.OnClosing(e);
        }

        private void Engine_Frame(Engine.EngineStateUpdate obj)
        {
            this.Post(() =>
            {
                tslblElapsed.Text = obj.ElapsedMilliseconds.ToString();
                tslblFrame.Text = obj.FrameNumber.ToString();
                tslblFps.Text = (obj.FrameNumber / (obj.ElapsedMilliseconds / 1000.0)).ToString();
                if (obj.FrameNumber % 10 == 0)
                {
                    lbActors.Items.Clear();
                    foreach (var actor in Engine.Actors)
                    {
                        lbActors.Items.Add($"{actor.GetType().Name}: ({actor.X}, {actor.Y})");
                    }
                }
            });
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}