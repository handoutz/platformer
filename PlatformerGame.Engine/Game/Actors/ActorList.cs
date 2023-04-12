using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public class ActorList : List<IActor>
    {
        private Engine _engine => Engine.Instance;
        private Queue<IActor> _removeQueue = new();
        public List<IActor> ActorsAt(int x, int y)
        {
            return this.Where(a => a.X == x && a.Y == y).ToList();
        }

        public List<IActor> ActorsInSameSpotAs(IActor actor)
        {
            return this.Where(a => a.X == actor.X && a.Y == actor.Y).ToList();
        }

        public void AfterFrame(EngineStateUpdate state)
        {
            while (_removeQueue.TryDequeue(out var a))
            {
                EngineLog.Info($"Removing actor {a.GetType().Name}");
                Remove(a);
            }

        }

        public void RemoveActor(IActor act)
        {
            EngineLog.Trace($"Enqueued actor removal {act.GetType().Name}");
            _removeQueue.Enqueue(act);
        }
    }
}
