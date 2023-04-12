using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformerGame
{
    public partial class GameDisplay : UserControl
    {
        private readonly Engine.Engine _engine;

        public GameDisplay()
        {
            InitializeComponent();
        }

        private volatile Bitmap _bm;

        public GameDisplay(Engine.Engine engine) : this()
        {
            _engine = engine;
            _engine.Frame += _engine_Frame;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_bm != null)
            {
                var g = e.Graphics;
                g.DrawImage(_bm, 0, 0);
            }

            base.OnPaint(e);
        }

        private void _engine_Frame(Engine.EngineStateUpdate obj)
        {
            _bm = obj.Bitmap;
            //force a redraw
            Invalidate();
        }
        /*protected override void OnKeyDown(KeyEventArgs e)
        {
            GameEngine.KeyDown(e);
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            GameEngine.KeyUp(e);
            base.OnKeyUp(e);
        }*/
        private void GameDisplay_Load(object sender, EventArgs e)
        {

        }
    }
}
