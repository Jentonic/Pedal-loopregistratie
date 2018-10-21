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

        public static QueueRunner CurrentRunner { get; set; }

        public static void Init()
        {
            QueueRunners = new ObservableCollection<QueueRunner>();

            // DataService get all
            var data = DataService.DbContext.QueueRunners.Select(x => x).OrderBy(x => x.Position).ToList();
            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    QueueRunners.Add(item);
                }
                CurrentRunner = data[0];
            }
        }


        public static void AddRunner(Runner runner)
        {
            var insert = new QueueRunner { Position = QueueRunners.Count + 1, Runner = runner, RunnerId = runner.RunnerId };

            // insert into database to track
            DataService.DbContext.QueueRunners.Add(insert);
            DataService.DbContext.SaveChanges();

            // look up new entry to get the ID (return the whole object)
            var data = DataService.DbContext.QueueRunners.Select(x => x).Where(x => x.Position == QueueRunners.Count + 1 && x.RunnerId == runner.RunnerId).First();

            // insert object into ObservableCollection
            QueueRunners.Add(data);
        }

        public static void MoveUp(QueueRunner selectedItem)
        {
            var index = selectedItem.Position;

            //Bound check
            if (index == 1)
                return;

            //Placeholders
            var helper = QueueRunners.ToList();
            var other = helper[index - 2];

            //Switch positions
            selectedItem.Position -= 1; 
            other.Position += 1;

            //Switch indexes in List
            helper[selectedItem.Position - 1] = selectedItem;
            helper[other.Position - 1] = other;

            //Clear list and update list
            QueueRunners.Clear();
            foreach (var item in helper)
            {
                QueueRunners.Add(item);
            }

            //Update database
            DataService.UpdateQueueAsync(helper);
        }

        public static void Refresh()
        {
            var helper = QueueRunners.ToList().OrderBy(x => x.Position);
            QueueRunners.Clear();
            foreach (var item in helper)
            {
                QueueRunners.Add(item);
            }
        }

        public static void MoveDown(QueueRunner selectedItem)
        {
            var index = selectedItem.Position;

            //Bound check
            if (index >= QueueRunners.Count)
                return;

            //Placeholders
            var helper = QueueRunners.ToList();
            var other = helper[index];

            //Switch positions
            selectedItem.Position += 1;
            other.Position -= 1;

            //Switch indexes in List
            helper[selectedItem.Position - 1] = selectedItem;
            helper[other.Position - 1] = other;

            //Clear and update 
            QueueRunners.Clear();
            foreach (var item in helper)
            {
                QueueRunners.Add(item);
            }

            //Update database
            DataService.UpdateQueueAsync(helper);
        }

        public static void Remove(QueueRunner selectedItem)
        {
            //Placeholder
            var helper = QueueRunners.ToList();
            var helper2 = new List<QueueRunner>();
            helper.Remove(selectedItem);

            //Clear and update plus update position
            QueueRunners.Clear();
            int i = 0;

            foreach (var item in helper)
            {
                item.Position = i + 1;
                helper2.Add(item);
                QueueRunners.Add(item);
                i++;
            }

            //Update database
            DataService.UpdateQueueAsync(helper2);
            DataService.RemoveFromQueueAsync(selectedItem);
        }
    }
}
