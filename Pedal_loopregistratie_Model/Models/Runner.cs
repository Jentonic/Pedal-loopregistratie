using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public List<Lap> Laps { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}