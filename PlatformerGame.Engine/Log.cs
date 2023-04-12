using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine
{
    public static class EngineLog
    {
        public static void Write(string s)
        {
            var shortTs = DateTime.Now.ToString("HH:mm:ss.fff");
            Engine.Instance.OnLogEvent($"[{shortTs}] {s}");
        }

        public static void Trace(string s)
        {
            Write($"[TRC] {s}");
        }

        public static void Info(string s)
        {
            Write($"[INF] {s}");
        }

        public static void Warn(string s)
        {
            Write($"[WRN] {s}");
        }

        public static void Error(string s)
        {
            Write($"[ERR] {s}");
        }
    }
}
