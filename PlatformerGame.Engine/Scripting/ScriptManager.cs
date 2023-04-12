using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Scripting
{
    public class ScriptManager
    {
        public List<Script> Scripts { get; set; } = new();
        
        public Script? GetScript(string name)
        {
            return Scripts.FirstOrDefault(s => s.Identifier.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
