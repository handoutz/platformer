using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game;
using PlatformerGame.Engine.Game.Actors;

namespace PlatformerGame.Engine.Physics
{
    public class Physics2d : IAcceptFrames
    {
        private Engine _engine;
        private Level _level;
        private List<IActor> _actors => _engine.Actors;
        public Physics2d(Engine engine, Level level)
        {
            _engine = engine;
            _level = level;
        }

        public void OnFrame(EngineStateUpdate obj)
        {
            _actors.ForEach(a =>
            {
                var x = a.X;
                var y = a.Y;
                var v = a.CurrentVelocity;
                var dy = v.DeltaY;
                if (v.Impulses.Count == 0)
                {
                    v.ApplyImpulse(new Impulse(0, 1, 0, 1));
                }
                v.Apply(a, obj);
            });
        }
    }
}
