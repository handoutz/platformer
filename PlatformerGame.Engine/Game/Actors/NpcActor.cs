using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformerGame.Engine.Game.Actors
{
    public class NpcActor : BaseActor
    {
        public override void OnFrame(EngineStateUpdate state)
        {
            if (state.FrameNumber % 50 == 0)
            {
                Jump(2, 5);
            }

            var player = state.Engine.Actors.FirstOrDefault(a => a is PlayerActor);
            if (player.X < X)
            {
                CurrentVelocity.Left(1, 1);
            }
            else if (player.X > X)
            {
                CurrentVelocity.Right(1, 1);
            }
        }

        public override void OnProcessKey(KeyEvent keyEvent)
        {

        }

        public override void SetVelocity(Velocity v)
        {

        }
    }
}
