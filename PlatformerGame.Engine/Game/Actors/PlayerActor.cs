using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public class PlayerActor : IActor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public Velocity CurrentVelocity { get; set; } = new(0,-1,0,1000000000);

        public void OnFrame(EngineStateUpdate state)
        {
            //set Color to random
            Color = Color.Blue;
            //CurrentVelocity.Apply(this, state);
        }

        public void OnProcessKey(KeyEvent keyEvent)
        {
            if (keyEvent.Down && keyEvent.IsLeft())
            {
                CurrentVelocity.ApplyImpulse(new Impulse(-1, 0, 0, 2));
            }
            if (keyEvent.Down && keyEvent.IsRight())
            {
                CurrentVelocity.ApplyImpulse(new Impulse(1, 0, 0, 2));
            }
            if (keyEvent.Down && keyEvent.IsUp())
            {
                CurrentVelocity.ApplyImpulse(new Impulse(0, -3, 0, 5));
            }
            if (keyEvent.Down && keyEvent.IsDown())
            {
                //CurrentVelocity.ApplyImpulse(new Impulse(0, 1, 0, 60));
            }
        }

        public void SetVelocity(Velocity v)
        {
            CurrentVelocity = v;
        }
    }
}
