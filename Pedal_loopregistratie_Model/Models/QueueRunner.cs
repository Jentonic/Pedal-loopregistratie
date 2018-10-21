using System;
using System.Collections.Generic;
using System.Text;

namespace Pedal_loopregistratie_Model.Models
{
    public class QueueRunner
    {
        public int QueueRunnerId { get; set; }
        public int Position { get; set; }

        public int RunnerId { get; set; }
        public Runner Runner { get; set; }
    }
}
