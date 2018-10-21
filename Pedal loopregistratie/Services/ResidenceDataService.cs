using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.Services
{
    public static class ResidenceDataService
    {
        private static IEnumerable<Residence> AllResidences()
        {
            using (var db = new PedalDbContext())
            {
                return db.Residences.Select(x => x).ToList();
            }
        }

        public static async Task<IEnumerable<Residence>> GetResidencesAsync()
        {
            //jezus, such shitcode (copied that from generated code example)
            await Task.CompletedTask;
            return AllResidences();
        }
    }
}
