using GalaSoft.MvvmLight;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.Models
{
    public class ObservableQueueRunner 
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
                queueRunner = value;
                //this.OnPropertyChanged();
            }
        }

        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    throw new NotImplementedException(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
