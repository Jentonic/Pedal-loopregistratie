using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.Services
{
    public static class QueueService
    {
        public static ObservableCollection<QueueRunner> QueueRunners;

        public static void Init()
        {
            QueueRunners = new ObservableCollection<QueueRunner>();
            // DataService get all
        }

        public static void AddRunner(Runner runner)
        {
            var insert = new QueueRunner { Position = QueueRunners.Count + 1, Runner = runner, RunnerId = runner.RunnerId };
            // insert into database to track
            // look up new entry to get the ID (return the whole object)
            // insert object into ObservableCollection

        }
    }
}
