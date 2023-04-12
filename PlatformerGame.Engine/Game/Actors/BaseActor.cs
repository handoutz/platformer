using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public abstract class BaseActor : IActor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public Velocity CurrentVelocity { get; set; } = new(0, -1, 0, 1000000000);
        public abstract void OnFrame(EngineStateUpdate state);
        public abstract void OnProcessKey(KeyEvent keyEvent);

        public abstract void SetVelocity(Velocity v);

        public void Jump(int strength, int ct)
        {
            CurrentVelocity.ApplyImpulse(new Impulse(0, -strength, 0, ct));
        }
    }
}
