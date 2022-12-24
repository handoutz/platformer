using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformerGame.Engine
{
    public class KeyEvent
    {
        public bool Edge { get; set; }
        public bool Down { get; set; }
        public Keys Key { get; set; }

        public bool IsLeft()
        {
            return Key == Keys.Left || Key == Keys.A;
        }
        public bool IsRight()
        {
            return Key == Keys.Right || Key == Keys.D;
        }
        public bool IsDown()
        {
            return Key == Keys.Down || Key == Keys.S;
        }
        public bool IsUp()
        {
            return Key == Keys.Up || Key == Keys.W;
        }

        public override string ToString()
        {
            return $"{Key} {(Down ? "Down" : "Up")} {(Edge ? "Edge" : "Repeat")}";
        }
    }
}
