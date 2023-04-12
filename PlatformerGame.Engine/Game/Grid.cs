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
                        Color = Color.Blue
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

        public string DumpToAscii()
        {
            string result = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    result += this[x, y].Pathing == Pathing.Ground ? "#" : " ";
                }

                result += "\r\n";
            }

            return result.Trim();
        }

        public static Grid LoadFromAscii(string ascii)
        {
            var lines = ascii.Split("\r\n");
            var grid = new Grid(lines[0].Length, lines.Length);
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    switch (lines[y][x])
                    {
                        case '#':
                            grid[x, y].Pathing = Pathing.Ground;
                            grid[x, y].Color = Color.SaddleBrown;
                            break;
                        case '*':
                            grid[x, y].Pathing = Pathing.LevelChange;
                            grid[x, y].Color = Color.Aquamarine;
                            break;
                        case '+':
                            grid[x, y].Pathing = Pathing.Objective;
                            grid[x, y].Color = Color.Yellow;
                            break;
                        default:
                            grid[x, y].Pathing = Pathing.Freespace;
                            grid[x, y].Color = Color.Black;
                            break;
                    }
                }
            }

            return grid;
        }
    }
}
