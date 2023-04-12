using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Sound
{
    public class SoundEventArgs : EventArgs
    {
        public string SoundName { get; set; }
        public bool Loop { get; set; }
        public float Volume { get; set; }
        public float Pan { get; set; }
        public float Pitch { get; set; }
    }
}
