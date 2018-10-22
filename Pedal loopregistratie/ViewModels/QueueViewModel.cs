﻿using GalaSoft.MvvmLight;
using Pedal_loopregistratie.Models;
using Pedal_loopregistratie.Services;
using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.ViewModels
{
    public class QueueViewModel : ViewModelBase
    {
        public List<QueueRunner> AllQueueRunners { get; private set; } = new List<QueueRunner>();

        public ObservableCollection<QueueRunner> QueueRunners { get; private set; } = new ObservableCollection<QueueRunner>();

        //CurrentRunner has position 0
        public ObservableQueueRunner CurrentRunner { get; private set; } = new ObservableQueueRunner();

        public async void InitAsync()
        {
            await Task.CompletedTask;
            UpdateCollections();
        }
        public void UpdateCollections()
        {
            //DataService get all
            var data = DataService.GetAllQueueRunnersAsync().Result.ToList();

            //Reset
            AllQueueRunners.Clear();
            QueueRunners.Clear();

            if (data.Count > 0)
            {
                foreach (var item in data)
                {
                    //Filter current runner
                    if (item.Position != 0)
                        QueueRunners.Add(item);

                    if (item.Position == 0)
                        CurrentRunner.QueueRunner = item;

                    AllQueueRunners.Add(item);
                }
            }
        }

        public void AddRunner(Runner runner)
        {
            var insert = new QueueRunner { Position = QueueRunners.Count + 1, Runner = runner, RunnerId = runner.RunnerId };

            // insert into database to track
            DataService.DbContext.QueueRunners.Add(insert);
            DataService.DbContext.SaveChanges();

            UpdateCollections();

            //// look up new entry to get the ID (return the whole object)
            //var data = DataService.DbContext.QueueRunners.Select(x => x).Where(x => x.Position == QueueRunners.Count + 1 && x.RunnerId == runner.RunnerId).First();

            //// insert object into ObservableCollection
            //QueueRunners.Add(data);
        }

        public void QueueNextRunner()
        {
            //Update all position in the queue
            var helper = QueueRunners.ToList();
            foreach (var item in helper)
            {
                item.Position -= 1;
            }

            //Update database
            DataService.UpdateQueueAsync(helper);

            //Register run and Update database
            if (CurrentRunner != null && CurrentRunner.QueueRunner != null)
            {
                RegisterRun();
                DataService.RemoveFromQueueAsync(CurrentRunner.QueueRunner);
            }

            UpdateCollections();
        }

        private static void RegisterRun()
        {

        }

        public void MoveUp(QueueRunner selectedItem)
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

            ////Clear list and update list
            //QueueRunners.Clear();
            //foreach (var item in helper)
            //{
            //    QueueRunners.Add(item);
            //}

            //Update database
            DataService.UpdateQueueAsync(helper);

            UpdateCollections();
        }

        //do not use Refresh or implement AllQueueRunners (use it like updatecollections)
        public void Refresh()
        {
            var helper = QueueRunners.ToList().OrderBy(x => x.Position);
            QueueRunners.Clear();
            foreach (var item in helper)
            {
                QueueRunners.Add(item);
            }
        }

        public void MoveDown(QueueRunner selectedItem)
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

            ////Clear and update 
            //QueueRunners.Clear();
            //foreach (var item in helper)
            //{
            //    QueueRunners.Add(item);
            //}

            //Update database
            DataService.UpdateQueueAsync(helper);
            UpdateCollections();
        }

        public void Remove(QueueRunner selectedItem)
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
                //QueueRunners.Add(item);
                i++;
            }

            //Update database
            DataService.UpdateQueueAsync(helper2);
            DataService.RemoveFromQueueAsync(selectedItem);

            UpdateCollections();
        }
    }
}
