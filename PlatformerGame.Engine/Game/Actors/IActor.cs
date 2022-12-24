using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public interface IActor
    {
        int X { get; set; }
        int Y { get; set; }
        void OnFrame(EngineStateUpdate state);
        void OnProcessKey(KeyEvent keyEvent);
    }
}
