using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public interface IActor
    {
        int X { get; set; }
        int Y { get; set; }
        Color Color { get; set; }
        Velocity CurrentVelocity { get; set; }
        void OnFrame(EngineStateUpdate state);
        void OnProcessKey(KeyEvent keyEvent);

        void SetVelocity(Velocity v);
    }
}
