using Pedal_loopregistratie_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.Services
{
    public static class NewRunnerSelectedService
    {
        public static Runner runner;
        public static bool NewRunner { get; set; }
        public static void SetNewRunner(Runner _runner)
        {
            runner = _runner;
            NewRunner = true;
        }
    }
}
