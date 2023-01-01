using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game.Actors;
using PlatformerGame.Engine.Physics;
using static System.Windows.Forms.AxHost;

namespace PlatformerGame.Engine.Game.Levels
{
    public class ActorLevel : Level
    {
        public Physics2d Physics { get; set; }

        public ActorLevel(Engine e) : base(e)
        {
            Physics = new Physics2d(e,this);
            Grid = new Grid(128, 64);
            //set ground level to 60
            for (int y = 60; y < Grid.Height; y++)
            {
                for (int i = 0; i < Grid.Width; i++)
                {
                    Grid.Squares[i, y].Pathing = Pathing.Ground;
                    Grid.Squares[i, y].Color = Color.Brown;
                }
            }

            var rand = new Random();
            //add some random platforms 
            for (int i = 0; i < 10; i++)
            {
                int x = rand.Next(0, Grid.Width);
                int y = rand.Next(0, Grid.Height);
                int w = Math.Clamp(rand.Next(1, 10), 0, Grid.Width - x);
                int h = Math.Clamp(rand.Next(1, 10), 0, Grid.Height - y);
                for (int x1 = x; x1 < x + w; x1++)
                {
                    for (int y1 = y; y1 < y + h; y1++)
                    {
                        Grid.Squares[x1, y1].Pathing = Pathing.Ground;
                        Grid.Squares[x1, y1].Color = Color.Brown;
                    }
                }
            }
            //put a border of Ground around the grid
            for (int i = 0; i < Grid.Width; i++)
            {
                Grid.Squares[i, 0].Pathing = Pathing.Ground;
                Grid.Squares[i, 0].Color = Color.Brown;
                Grid.Squares[i, Grid.Height - 1].Pathing = Pathing.Ground;
                Grid.Squares[i, Grid.Height - 1].Color = Color.Brown;
            }
            for (int i = 0; i < Grid.Height; i++)
            {
                Grid.Squares[0, i].Pathing = Pathing.Ground;
                Grid.Squares[0, i].Color = Color.Brown;
                Grid.Squares[Grid.Width-1, i].Pathing = Pathing.Ground;
                Grid.Squares[Grid.Width - 1, i].Color = Color.Brown;
            }

            //le.WriteAllText("C:\\tmp\\grid.txt", Grid.DumpToAscii());
            Grid = Grid.LoadFromAscii(File.ReadAllText(@"C:\tmp\grid.txt"));
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            _actors.ForEach(a =>
            {
                Grid[a.X, a.Y].Color = Color.Blue;
                Grid[a.X, a.Y].Pathing = Grid[a.X, a.Y].Pathing == Pathing.Actor? Pathing.Freespace: Grid[a.X, a.Y].Pathing;
            });
            Physics.OnFrame(state);
            _actors.ForEach(a =>
            {
                a.OnFrame(state);
            });
            UpdatePlayerLocation();
        }

        public void UpdatePlayerLocation()
        {
            //Grid.Squares[_playerX, _playerY].Color = Color.Green;
            _actors.ForEach(act =>
            {
                Grid[act.X, act.Y].Pathing = Pathing.Actor;
            });
        }
        public override void OnProcessKey(KeyEvent keyEvent)
        {
            _actors.ForEach(a => { Grid[a.X, a.Y].Color = Color.Blue; });
            _actors.ForEach(a => a.OnProcessKey(keyEvent));
            UpdatePlayerLocation();
        }
    }
}
