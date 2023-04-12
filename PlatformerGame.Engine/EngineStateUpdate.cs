using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game;

namespace PlatformerGame.Engine
{
    public class EngineStateUpdate
    {
        public int FrameNumber { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public Bitmap Bitmap { get; set; }
        public Level Level { get; set; }
        public Engine Engine { get; set; }
        public int Size { get; set; }
    }
}
