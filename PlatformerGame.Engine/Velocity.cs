using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game.Actors;

namespace PlatformerGame.Engine
{
    public class Velocity
    {
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
        public int StartFrameNumber { get; set; }
        public int NumFramesUntilEnd { get; set; }

        public Velocity()
        {
            
        }
        public Velocity(int deltaX, int deltaY, int startFrameNumber, int numFramesUntilEnd)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
            StartFrameNumber = startFrameNumber;
            NumFramesUntilEnd = numFramesUntilEnd;
        }

        //apply the velocity to the actor based on how many frames are left
        public void Apply(IActor actor, int currentFrameNumber)
        {
            if (currentFrameNumber >= StartFrameNumber && 
                currentFrameNumber < StartFrameNumber + NumFramesUntilEnd)
            {
                actor.X += DeltaX;
                actor.Y += DeltaY;
            }
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}
