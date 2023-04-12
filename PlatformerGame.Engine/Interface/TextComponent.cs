using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Interface
{
    public class TextComponent : UiComponent
    {
        public string Text { get; set; }

        public TextComponent()
        {
            Text = "asdf";
        }

        public TextComponent(string text)
        {
            Text = text;
        }

        public override void Draw(Bitmap bm, EngineStateUpdate update, Graphics graph)
        {
            var sz = update.Size;
            graph.DrawString(Text, new Font("Arial", 12), new SolidBrush(Color.White), X * sz, Y * sz);
        }
    }
}
