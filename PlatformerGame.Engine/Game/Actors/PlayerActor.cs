using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformerGame.Engine.Physics;
using PlatformerGame.Engine.Scripting;
using PlatformerGame.Engine.Sound;

namespace PlatformerGame.Engine.Game.Actors
{
    public class PlayerActor : BaseActor
    {
        private Script _objectiveScript;
        public PlayerActor()
        {
            CurrentVelocity = new(0, -1, 0, 1000000000);
            AddScript(_objectiveScript = new ObjectiveScript());
        }
        public override void OnFrame(EngineStateUpdate state)
        {
            //set Color to random
            Color = Color.Blue;
            //CurrentVelocity.Apply(this, state);
            var same = state.Engine.Actors.ActorsInSameSpotAs(this).Where(s=>s is StaticActor)
                .ToList();
            if (same.Count > 0)
            {
                var obj = _objectiveScript as ObjectiveScript;
                obj.Count++;
                state.Engine.Actors.RemoveActor(same.First());
                state.Engine.Sound.OnStartSound(new SoundEventArgs()
                {
                    SoundName = @"C:\Users\innat\source\repos\PlatformerGame\PlatformerGame\Sounds\grenade.wav"
                });
            }
        }

        public override void OnProcessKey(KeyEvent keyEvent)
        {
            if ((keyEvent.Down && keyEvent.IsLeft()))
            {
                CurrentVelocity.ApplyImpulse(new Impulse(-1, 0, 0, 2));
            }
            if (keyEvent.Down && keyEvent.IsRight())
            {
                CurrentVelocity.ApplyImpulse(new Impulse(1, 0, 0, 2));
            }
            if (keyEvent.Down && keyEvent.IsUp())
            {
                if (!Physics2d.Instance.IsActorInAir(this))
                {
                    CurrentVelocity.ApplyImpulse(new Impulse(0, -3, 0, 5));
                }
            }
            if (keyEvent.Down && keyEvent.IsDown())
            {
                //CurrentVelocity.ApplyImpulse(new Impulse(0, 1, 0, 60));
            }
        }

        public override void SetVelocity(Velocity v)
        {
            CurrentVelocity = v;
        }
    }
}
