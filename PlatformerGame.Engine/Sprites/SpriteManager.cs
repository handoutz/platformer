using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Sprites
{
    public class SpriteManager
    {
        public Dictionary<string, ISprite> Sprites = new();
        public void AddSprite(string name, string path)
        {
            using var fso = File.OpenRead(path);
            AddSprite(name, fso);
        }

        public void AddSprite(string name, Stream stream)
        {
            var bms = new BitmapSprite(stream);
            Sprites.Add(name, bms);
        }
    }
}
