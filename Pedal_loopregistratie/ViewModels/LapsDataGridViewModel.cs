using System;
using System.Collections.ObjectModel;

using GalaSoft.MvvmLight;

using Pedal_loopregistratie.Models;
using Pedal_loopregistratie.Services;

namespace Pedal_loopregistratie.ViewModels
{
    public class LapsDataGridViewModel : ViewModelBase
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
