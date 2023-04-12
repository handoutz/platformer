using PlatformerGame.Engine.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game
{
    public abstract class Level
    {
        protected List<IActor> _actors => GameEngine.Actors;
        public Engine GameEngine;
        public Grid Grid { get; set; }
        public abstract void OnFrame(EngineStateUpdate state);
        public abstract void OnProcessKey(KeyEvent keyEvent);

        protected Level(Engine e)
        {
            GameEngine = e;
        }
        public T GetGridExtra<T>(int x, int y)
        {
            return (T)Grid.Squares[x, y].Extra;
        }

        public void SetGridExtra(int x, int y, object o)
        {
            Grid[x, y].Extra = o;
        }
    }
}
