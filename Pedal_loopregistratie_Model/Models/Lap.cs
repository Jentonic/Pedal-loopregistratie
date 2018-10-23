using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public string Time
        {
            get
            {
                var ts = TimeSpan.FromMilliseconds(Milliseconds);
                return ts.Minutes + ":" + ts.Seconds + "." + ts.Milliseconds;
            }
        }
    }
}
