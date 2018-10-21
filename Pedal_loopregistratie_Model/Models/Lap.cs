using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal_loopregistratie_Model.Models
{
    public class Lap
    {
        public int LapId { get; set; }
        public int Milliseconds { get; set; }
        public double AverageSpeed { get; set; }

        public int RunnerId { get; set; }
        public Runner Runner { get; set; }
    }
}
