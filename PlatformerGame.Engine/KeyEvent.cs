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
        public static bool IsLeftPressed()
        {
            return Natives.IsKeyDown(VirtualKeys.A);
        }
        public static bool IsRightPressed()
        {
            return Natives.IsKeyDown(VirtualKeys.D);
        }
        public static bool IsUpPressed()
        {
            return Natives.IsKeyDown(VirtualKeys.W);
        }
        public static bool IsDownPressed()
        {
            return Natives.IsKeyDown(VirtualKeys.D);
        }

        public int Frame { get; set; }
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
