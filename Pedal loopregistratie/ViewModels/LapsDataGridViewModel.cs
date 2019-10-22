using GalaSoft.MvvmLight;
using Pedal_loopregistratie.Services;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.ViewModels
{
    public class LapsDataGridViewModel : ViewModelBase
    {
        public ObservableCollection<Lap> Source
        {
            get
            {
                return GetLaps();
            }
        }

        public ObservableCollection<Lap> GetLaps()
        {
            var helper = DataService.GetLapsData().OrderByDescending(x => x.LapId).ToList();
            var collection = new ObservableCollection<Lap>();
            foreach (var item in helper)
            {
                collection.Add(item);
            }
            return collection;
        }
}

}
