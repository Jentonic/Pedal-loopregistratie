using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.DAL;

namespace Pedal_loopregistratie.Services
{
    public static class DataService
    {
        public static PedalDbContext DbContext { get; set; }

        public static void Init()
        {
            DbContext = new PedalDbContext();
            DbContext.DoMigrate();
        }

        public static async Task<IEnumerable<Residence>> GetResidencesAsync()
        {
            //jezus, such shitcode (copied that from generated code example)
            await Task.CompletedTask;
            return DbContext.Residences.Select(x => x).ToList();
        }

        public static async Task<IEnumerable<Runner>> GetRunnersAsync()
        {
            //jezus, such shitcode (copied that from generated code example)
            await Task.CompletedTask;
            return DbContext.Runners.Select(x => x).ToList();
        }

        public static List<string> GetAllDistinctResidences()
        {
            return DbContext.Residences.Select(x => x.Name).Distinct().ToList();
        }

        public static Residence ResolveResidenceFromName(string v)
        {
            return DbContext.Residences.FirstOrDefault(x => x.Name == v);
        }

        public static void AddNewRunner(Runner runner)
        {
            DbContext.Runners.Add(runner);
            DbContext.SaveChanges();
        }
    }
}
