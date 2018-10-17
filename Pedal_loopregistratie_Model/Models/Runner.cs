using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie_Model
{
    public class Runner
    {
        public int RunnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ResidenceId { get; set; }
        public Residence Residence { get; set; }
    }
}