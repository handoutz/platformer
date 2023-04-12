using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public class NpcActor : IActor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public Velocity CurrentVelocity { get; set; }
        public void OnFrame(EngineStateUpdate state)
        {
            Engine.Instance.OnLogEvent($"{X} {Y}");
            CurrentVelocity = new(0, -1, 0, 1000000000);
        }

        public void OnProcessKey(KeyEvent keyEvent)
        {
            
        }

        public void SetVelocity(Velocity v)
        {
            
        }
    }
}
