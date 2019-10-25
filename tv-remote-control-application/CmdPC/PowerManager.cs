using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CmdPC
{
    class PowerManager
    {
        [DllImport("Powrprof.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        public static void Hibernate()
        {
            // Hibernate
            SetSuspendState(true, true, true);
        }

        public static void StandBy()
        {        
            // Standby
            SetSuspendState(false, true, true);
        }
    }
}
