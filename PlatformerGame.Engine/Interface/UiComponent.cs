using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Interface
{
    public abstract class UiComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public UiComponent Parent { get; set; }
        public abstract void Draw(Bitmap bm, EngineStateUpdate update, Graphics graph);
    }
}
