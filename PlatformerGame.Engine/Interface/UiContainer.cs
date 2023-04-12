using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Interface
{
    public class UiContainer : UiComponent
    {
        public List<UiComponent> Children { get; set; } = new();
        public void AddChild(UiComponent child)
        {
            Children.Add(child);
            child.Parent = this;
        }
        public override void Draw(Bitmap bm, EngineStateUpdate update, Graphics graph)
        {
            foreach (var child in Children)
            {
                child.Draw(bm, update, graph);
            }
        }
    }
}
