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
            Physics = new Physics2d(e, this);
            Grid = new Grid(128, 64);

            //le.WriteAllText("C:\\tmp\\grid.txt", Grid.DumpToAscii());
            Grid = Grid.LoadFromAscii(File.ReadAllText(@"C:\tmp\grid.txt"));
            _actors.Add(new NpcActor()
            {
                X = 50,
                Y = 5,
                Color = Color.Purple,
                CurrentVelocity = new(0, 0, 0, 1000000000)
            });
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            _actors.ForEach(a =>
            {
                Grid[a.X, a.Y].Color = a.Color;//Color.Blue;
                GameEngine.OnLogEvent($"{a.GetType().Name}-{a.X} {a.Y}");
                Grid[a.X, a.Y].Pathing = Grid[a.X, a.Y].Pathing == Pathing.Actor ? Pathing.Freespace : Grid[a.X, a.Y].Pathing;
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
                if (act is PlayerActor)
                {
                    if (Grid[act.X, act.Y].Pathing == Pathing.LevelChange)
                    {
                        Grid = Grid.LoadFromAscii(File.ReadAllText(@"C:\tmp\grid.txt"));
                    }
                    else
                    {
                        
                    }
                }
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
