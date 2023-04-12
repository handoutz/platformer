using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Actors
{
    public class ActorList : List<IActor>
    {
        public List<IActor> ActorsAt(int x, int y)
        {
            return this.Where(a => a.X == x && a.Y == y).ToList();
        }

        public List<IActor> ActorsInSameSpotAs(IActor actor)
        {
            return this.Where(a => a.X == actor.X && a.Y == actor.Y).ToList();
        }
    }
}
