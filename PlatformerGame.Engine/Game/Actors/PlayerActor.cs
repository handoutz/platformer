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
        public Velocity CurrentVelocity { get; set; } = new(0,-5,0,1000000000);

        public void OnFrame(EngineStateUpdate state)
        {
            //set Color to random
            Color = Color.Blue;
            CurrentVelocity.Apply(this, state);
        }

        public void OnProcessKey(KeyEvent keyEvent)
        {
            if (keyEvent.Down && keyEvent.IsLeft())
            {
                X--;
            }
            if (keyEvent.Down && keyEvent.IsRight())
            {
                X++;
            }
            if (keyEvent.Down && keyEvent.IsUp())
            {
                Y--;
            }
            if (keyEvent.Down && keyEvent.IsDown())
            {
                Y++;
            }
        }

        public void SetVelocity(Velocity v)
        {
            CurrentVelocity = v;
        }
    }
}
