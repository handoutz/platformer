using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
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

        public static IEnumerable<Point> GetPointsOnLine(int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                int t;
                t = x0; // swap x0 and y0
                x0 = y0;
                y0 = t;
                t = x1; // swap x1 and y1
                x1 = y1;
                y1 = t;
            }

            if (x0 > x1)
            {
                int t;
                t = x0; // swap x0 and x1
                x0 = x1;
                x1 = t;
                t = y0; // swap y0 and y1
                y0 = y1;
                y1 = t;
            }

            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                yield return new Point((steep ? y : x), (steep ? x : y));
                error = error - dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }

            yield break;
        }

        public bool CanPathTo(Level l, int x, int y)
        {
            return l.Grid[x, y].Pathing != Pathing.Ground;
        }

        public Point? FirstNonPathingPointBetween(Level l, IActor src, int x, int y)
        {
            var pts = GetPointsOnLine(src.X, src.Y, x, y).ToList();
            foreach (var pt in pts)
            {
                if (!CanPathTo(l, pt.X, pt.Y))
                    return pt;
            }

            return null;
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
            var pts = GetPointsOnLine(actor.X, actor.Y, actor.X, actor.Y).ToList();
            var fp = pts.Skip(1).FirstOrDefault(pt => level.Grid[pt.X, pt.Y].Pathing != Pathing.Ground);
            if (!CanPathTo(level, fp.X, fp.Y))
            {
                dx = dy = 0;
            }

            if (!CanPathTo(level, actor.X + dx, actor.Y))
            {
                dx = 0;
            }

            if (!CanPathTo(level, actor.X, actor.Y + dy))
            {
                dy = 0;
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

        public void Left(int frames, int ct)
        {
            var fr = new Impulse(-ct, 0, CurrentFrame, frames);
            Impulses.Add(fr);
        }
        public void Right(int frames, int ct)
        {
            var fr = new Impulse(ct, 0, CurrentFrame, frames);
            Impulses.Add(fr);
        }

        public override string ToString()
        {
            return $"Velocity: {DeltaX}, {DeltaY}, {StartFrameNumber}, {NumFramesUntilEnd}";
        }
    }
}