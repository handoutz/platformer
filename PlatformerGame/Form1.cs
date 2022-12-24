using PlatformerGame.Engine;
using System.ComponentModel;

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
            Engine.Start();
            Controls.Add(new GameDisplay(Engine)
            {
                Dock = DockStyle.Fill
            });
            Engine.LogEvent += Engine_LogEvent;
            KeyDown += GameDisplay_KeyDown;
            KeyUp += GameDisplay_KeyUp;
            KeyPreview = true;
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
            });
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}