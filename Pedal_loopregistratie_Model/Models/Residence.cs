using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie_Model
{
    public class Residence
    {
        public int ResidenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageString { get; set; }
        public List<Runner> Runners { get; set; }
    }
}
