using GalaSoft.MvvmLight;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.Models
{
    public class ObservableQueueRunner : ObservableObject
    {
        private QueueRunner queueRunner;
        public QueueRunner QueueRunner
        {
            get
            {
                return queueRunner;
            }
            set
            {
                Set<QueueRunner>(() => this.QueueRunner, ref queueRunner, value);
            }
        }
    }
}
