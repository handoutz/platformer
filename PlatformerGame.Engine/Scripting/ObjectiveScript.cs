using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Interface;

namespace PlatformerGame.Engine.Scripting
{
    public class ObjectiveScript : Script
    {
        public int Count { get; set; }
        private TextComponent DisplayText { get; set; } = new("Objectives: 0");

        public override void OnLoad(Engine e)
        {
            e.Hud.AddChild(DisplayText);
        }

        public override void OnFrame(EngineStateUpdate state)
        {
            DisplayText.Text = $"Objectives: {Count}";
        }

        public ObjectiveScript() : base("objective")
        {
        }
    }
}
