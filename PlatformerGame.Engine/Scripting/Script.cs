using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Scripting
{
    public abstract class Script
    {
        public string Identifier { get; set; }

        protected Script(string identifier)
        {
            Identifier = identifier;
        }

        public abstract void OnLoad(Engine e);

        public virtual void BeforeFrame(EngineStateUpdate state)
        {
        }

        public abstract void OnFrame(EngineStateUpdate state);
        public virtual void AfterFrame(EngineStateUpdate state)
        {
            
        }
    }
}
