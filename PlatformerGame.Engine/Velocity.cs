using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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

        public bool CanPathTo(Level l, int x, int y)
        {
            return l.Grid[x, y].Pathing != Pathing.Ground;
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
                //Engine.Instance.OnLogEvent($"Removing: {removed}");
                Impulses.Remove(removed);
            }

            if (dx != 0 || dy != 1)
                Engine.Instance.OnLogEvent($"Calculated velocity: {dx}, {dy}");

            CurrentFrame = update.FrameNumber;
            var level = update.Level;
            if (!CanPathTo(level, actor.X + dx, actor.Y+dy))
            {
                if (!CanPathTo(level, actor.X + dx, actor.Y))
                {
                    dx = 0;
                }
                if (!CanPathTo(level, actor.X, actor.Y+dy))
                {
                    dy = 0;
                }
            }
            //check if actor.Y+DeltaY is Ground
            if (update.Level.Grid[actor.X + dx, actor.Y + dy].Pathing != Pathing.Ground)
            {
                actor.X += dx;
                actor.Y = actor.Y + dy;
            }

            DeltaX = dx;
            DeltaY = dy;
        }

        public void ApplyImpulse(Impulse imp)
        {
            imp.StartFrame = CurrentFrame;
            Impulses.Add(imp);
            //Engine.Instance.OnLogEvent($"Adding: {imp}");
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}
