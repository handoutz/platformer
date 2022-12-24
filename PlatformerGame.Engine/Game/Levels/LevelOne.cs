using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Game.Levels
{
    public class LevelOne : Level
    {
        private int _playerX = 0;
        private int _playerY = 0;

        private int _lastPlayerX = 0;
        private int _lastPlayerY = 0;
        public LevelOne()
        {
            Grid = new Grid(128, 64);
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            UpdatePlayerLocation();
        }

        public void UpdatePlayerLocation()
        {
            if (_playerX != _lastPlayerX || _playerY != _lastPlayerY)
            {
                Grid.Squares[_lastPlayerX, _lastPlayerY].Color = Color.Orange;
                _lastPlayerX = _playerX;
                _lastPlayerY = _playerY;
            }
            Grid.Squares[_playerX, _playerY].Color = Color.Green;
        }
        public override void OnProcessKey(KeyEvent keyEvent)
        {
            if (keyEvent.Down && keyEvent.IsLeft())
            {
                _playerX--;
            }
            if (keyEvent.Down && keyEvent.IsRight())
            {
                _playerX++;
            }
            if (keyEvent.Down && keyEvent.IsUp())
            {
                _playerY--;
            }
            if (keyEvent.Down && keyEvent.IsDown())
            {
                _playerY++;
            }
            UpdatePlayerLocation();
        }
    }
}
