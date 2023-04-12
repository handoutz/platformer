using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Sprites
{
    public class BitmapSprite : IDisposable, ISprite
    {
        private Bitmap _bm;
        public Bitmap Bitmap => _bm;

        public BitmapSprite(Bitmap bm)
        {
            _bm = bm;
        }

        public BitmapSprite(Stream stream)
        {
            var bm = Bitmap.FromStream(stream);
            _bm = new Bitmap(bm)
            {
                Palette = null,
                Tag = null
            };
        }

        public void Dispose()
        {
            _bm.Dispose();
        }

        public string Name { get; set; }

        public Bitmap GetBitmap()
        {
            return _bm;
        }
    }
}
