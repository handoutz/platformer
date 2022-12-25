using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game.Actors;

namespace PlatformerGame.Engine.Game.Levels
{
    public class GravityLevel : Level
    {
        private IActor _player;

        private int _playerY
        {
            get => _player.Y;
            set => _player.Y = value;
        }

        private int _playerX
        {
            get => _player.X;
            set => _player.X = value;
        }
        private int _lastPlayerX = 0, _lastPlayerY = 0;
        public GravityLevel()
        {
            _player = new PlayerActor();
            Grid = new Grid(128, 64);
            //set ground level to 60
            for (int y = 60; y < Grid.Height; y++)
            {
                for (int i = 0; i < Grid.Width; i++)
                {
                    Grid.Squares[i, y].Pathing = Pathing.Ground;
                    Grid.Squares[i, y].Color = Color.Brown;
                }
            }
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            _player.OnFrame(state);
            UpdatePlayerLocation();
        }

        public void UpdatePlayerLocation()
        {
            if (_playerY < 0 || _playerY >= Grid.Height)
            {
                _playerY = _lastPlayerY + 1;
            }

            if (_playerX < 0 || _playerX >= Grid.Width)
            {
                _playerX = _lastPlayerX + 1;
            }

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
            _player.OnProcessKey(keyEvent);
            UpdatePlayerLocation();
        }
    }
}
