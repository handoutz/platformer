using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame
{
    public static class FormExtension
    {
        public static void Post(this Form frm, Action act)
        {
            if (frm.InvokeRequired)
            {
                frm.Invoke(act);
            }
            else
            {
                act();
            }
        }
    }
}
