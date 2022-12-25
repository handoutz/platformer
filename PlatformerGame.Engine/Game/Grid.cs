using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game
{
    public class Grid
    {
        public GridSquare[,] Squares { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int w, int h)
        {
            //initialize the grid
            Width = w;
            Height = h;
            Squares = new GridSquare[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Squares[x, y] = new GridSquare(x, y)
                    {
                        Color = y > 5 ? Color.Blue : Color.Red
                    };
                }
            }
        }
        public GridSquare this[int x, int y]
        {
            get
            {
                if (x >= Width || x < 0 || y >= Height || y <= 0)
                    return Squares[0, 0];
                return Squares[x, y];
            }
            set => Squares[x, y] = value;
        }
    }
}
