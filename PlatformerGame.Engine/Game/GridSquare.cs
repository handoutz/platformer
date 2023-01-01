using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game
{
    public enum Pathing
    {
        Freespace,
        Ground,
        Actor
    }
    public class GridSquare
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color {
            get
            {
                switch (Pathing)
                {
                    case Pathing.Freespace:
                        return Color.Black;
                    case Pathing.Ground:
                        return Color.SaddleBrown;
                    case Pathing.Actor:
                        return Color.Green;
                    default:
                        return Color.White;
                }
            }
            set { }
        }
        public Pathing Pathing { get; set; }
        public object Extra { get; set; }

        public GridSquare(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
