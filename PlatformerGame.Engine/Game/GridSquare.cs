using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game
{
    public class GridSquare
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public GridSquare(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
