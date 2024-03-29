﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Engine.Sound
{
    public class SoundManager : IAcceptFrames
    {
        public event Action<SoundEventArgs> StartSound;
        public void OnFrame(EngineStateUpdate obj)
        {
            
        }

        public void OnStartSound(SoundEventArgs obj)
        {
            EngineLog.Trace($"Starting sound {obj.SoundName}" + (obj.Loop ? " looping":""));
            StartSound?.Invoke(obj);
        }
    }
}
