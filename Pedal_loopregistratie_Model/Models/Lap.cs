using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal_loopregistratie_Model.Models
{
    public class Lap
    {
        public int LapId { get; set; }
        public double Milliseconds { get; set; }
        public double AverageSpeedKmH { get; set; }
        public double AverageSpeedS { get; set; }

        public int RunnerId { get; set; }
        public Runner Runner { get; set; }
    }
}
