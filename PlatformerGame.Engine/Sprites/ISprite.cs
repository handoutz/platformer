using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Sprites
{
    public interface ISprite
    {
        string Name { get; set; }
        Bitmap GetBitmap();
    }
}
