using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using unvell.D2DLib;
using unvell.D2DLib.WinForm;

namespace PlatformerGame
{
    public partial class GameDisplay : D2DControl
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
        protected override void OnRender(D2DGraphics g)
        {
            if (_bm != null)
            {
                var d2dbmp = Device.CreateBitmapFromGDIBitmap(_bm);
                g.DrawBitmap(_bm, 0, 0);
            }
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
    }
}
