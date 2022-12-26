using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Game;
using PlatformerGame.Engine.Game.Actors;

namespace PlatformerGame.Engine
{
    public class Velocity : IVelocity
    {
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }
        public int StartFrameNumber { get; set; }
        public int NumFramesUntilEnd { get; set; }
        private List<Impulse> Impulses { get; set; } = new();
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
            var toRemove = new List<Impulse>();
            foreach (var imp in Impulses)
            {
                if (imp.CanRemove(update.FrameNumber))
                    toRemove.Add(imp);
                
            }

            foreach (var removed in toRemove)
            {
                Impulses.Remove(removed);
            }


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

        public void ApplyImpulse(Impulse imp)
        {
            Impulses.Add(imp);
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}
