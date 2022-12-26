using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game.Actors;
using static System.Windows.Forms.AxHost;

namespace PlatformerGame.Engine.Game.Levels
{
    public class ActorLevel : Level
    {
        private List<IActor> _actors;
        
        public ActorLevel()
        {
            _actors = new()
            {
                new PlayerActor()
            };
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
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            _actors.ForEach(a => a.OnFrame(state));
            UpdatePlayerLocation();
        }

        public void UpdatePlayerLocation()
        {
            //Grid.Squares[_playerX, _playerY].Color = Color.Green;
            _actors.ForEach(act =>
            {
                Grid[act.X, act.Y].Color = Color.Green;
            });
        }
        public override void OnProcessKey(KeyEvent keyEvent)
        {
            _actors.ForEach(a => a.OnProcessKey(keyEvent));
            UpdatePlayerLocation();
        }
    }
}
