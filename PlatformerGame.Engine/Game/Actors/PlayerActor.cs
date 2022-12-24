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
        public Velocity CurrentVelocity { get; set; } = new();

        public void OnFrame(EngineStateUpdate state)
        {
            CurrentVelocity.Apply(this, state.FrameNumber);
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
                CurrentVelocity.DeltaY += 5;
            }
            if (keyEvent.Down && keyEvent.IsDown())
            {

            }
        }

        public void SetVelocity(Velocity v)
        {
            CurrentVelocity = v;
        }
    }
}
