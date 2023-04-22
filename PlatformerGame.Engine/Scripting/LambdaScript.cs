using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Scripting
{
    public class LambdaScript : Script
    {
        public Action<Engine> _load;
        public Action<EngineStateUpdate> _frame;
        public Action<EngineStateUpdate> _beforeFrame;
        public Action<EngineStateUpdate> _afterFrame;

        public override void OnLoad(Engine e)
        {
            _load?.Invoke(e);
        }

        public override void BeforeFrame(EngineStateUpdate state)
        {
            _beforeFrame?.Invoke(state);
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            _frame?.Invoke(state);
        }
        public override void AfterFrame(EngineStateUpdate state)
        {
            _afterFrame?.Invoke(state);
        }

        public LambdaScript(string identifier) : base(identifier + Guid.NewGuid().ToString())
        {
        }
    }
}
