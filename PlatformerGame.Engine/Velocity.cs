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
        public List<Impulse> Impulses { get; set; } = new();
        public int CurrentFrame { get; set; }

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
            int dx = 0, dy = 0;
            var toRemove = new List<Impulse>();
            foreach (var imp in Impulses)
            {
                if (imp.CanRemove(update.FrameNumber))
                    toRemove.Add(imp);
                dx += imp.X;
                dy += imp.Y;
            }

            foreach (var removed in toRemove)
            {
                Engine.Instance.OnLogEvent($"Removing: {removed}");
                Impulses.Remove(removed);
            }

            CurrentFrame = update.FrameNumber;
            
            actor.X += dx;
            //check if actor.Y+DeltaY is Ground
            if (update.Level.Grid[actor.X, actor.Y + dy].Pathing != Pathing.Ground)
            {
                actor.Y = actor.Y + dy;
            }

            DeltaX = dx;
            DeltaY = dy;
        }

        public void ApplyImpulse(Impulse imp)
        {
            imp.StartFrame = CurrentFrame;
            Impulses.Add(imp);
            Engine.Instance.OnLogEvent($"Adding: {imp}");
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}
