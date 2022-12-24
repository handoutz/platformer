using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game
{
    public abstract class Level
    {
        public Grid Grid { get; set; }
        public abstract void OnFrame(EngineStateUpdate state);
        public abstract void OnProcessKey(KeyEvent keyEvent);
    }
}
