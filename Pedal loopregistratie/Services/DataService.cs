using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.DAL;
using Pedal_loopregistratie_Model.Models;

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
            return DbContext.Residences.Include("Runners").ToList();
        }

        public static async Task<IEnumerable<Runner>> GetRunnersAsync()
        {
            //jezus, such shitcode (copied that from generated code example)
            await Task.CompletedTask;
            return DbContext.Runners.Include("Residence").Include("Laps").ToList();
        }

        public static async Task<IEnumerable<QueueRunner>> GetAllQueueRunnersAsync()
        {
            await Task.CompletedTask;
            return DbContext.QueueRunners.Include("Runner").Include("Runner.Residence").OrderBy(x => x.Position).ToList();
        }

        public static async Task<List<string>> GetAllDistinctResidencesAsync()
        {
            await Task.CompletedTask;
            return DbContext.Residences.Select(x => x.Name).Distinct().ToList();
        }

        public static async Task<Residence> ResolveResidenceFromNameAsync(string v)
        {
            await Task.CompletedTask;
            return DbContext.Residences.FirstOrDefault(x => x.Name == v);
        }

        public static async void AddNewRunnerAsync(Runner runner)
        {
            await Task.CompletedTask;
            DbContext.Runners.Add(runner);
            DbContext.SaveChanges();
        }

        public static async void UpdateQueueAsync(List<QueueRunner> queueRunners)
        {
            await Task.CompletedTask;
            DbContext.QueueRunners.UpdateRange(queueRunners);
            DbContext.SaveChanges();
        }

        public static async void RemoveFromQueueAsync(QueueRunner queueRunner)
        {
            await Task.CompletedTask;
            DbContext.QueueRunners.Remove(queueRunner);
            DbContext.SaveChanges();
        }

        public static async void SaveLapAsync(Lap lap)
        {
            await Task.CompletedTask;
            DbContext.Laps.Add(lap);
            DbContext.SaveChanges();
        }
    }
}
