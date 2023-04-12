﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformerGame.Engine.Game.Actors
{
    public class NpcActor : IActor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public Velocity CurrentVelocity { get; set; } = new(0, -1, 0, 1000000000);
        public void OnFrame(EngineStateUpdate state)
        {
            if (state.FrameNumber % 50 == 0)
            {
                CurrentVelocity.ApplyImpulse(new Impulse(0, -2, 0, 5));
            }

            var player = state.Engine.Actors.FirstOrDefault(a => a is PlayerActor);
            if (player.X < X)
            {
                CurrentVelocity.Left(1, 1);
            }
            else if(player.X > X)
            {
                CurrentVelocity.Right(1, 1);
            }
            else
            {
                
            }
        }

        public void OnProcessKey(KeyEvent keyEvent)
        {
            
        }

        public void SetVelocity(Velocity v)
        {
            
        }
    }
}
