using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game;
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
        public void Apply(IActor actor, EngineStateUpdate update)
        {
            var currentFrameNumber = update.FrameNumber;
            if (currentFrameNumber >= StartFrameNumber && 
                currentFrameNumber < StartFrameNumber + NumFramesUntilEnd)
            {
                actor.X += DeltaX;
                //check if actor.Y+DeltaY is Ground
                if (update.Level.Grid[actor.X, actor.Y - DeltaY].Pathing != Pathing.Ground)
                {
                    actor.Y = actor.Y - DeltaY;
                }
            }
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}
