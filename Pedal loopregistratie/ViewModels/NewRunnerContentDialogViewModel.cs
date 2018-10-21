using GalaSoft.MvvmLight;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Pedal_loopregistratie.Services;
using Pedal_loopregistratie_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedal_loopregistratie.ViewModels
{
    public class NewRunnerContentDialogViewModel : ViewModelBase
    {
        private Residence _selected;

        public Residence Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<string> Residences { get; private set; } = new ObservableCollection<string>();

        public NewRunnerContentDialogViewModel()
        {
        }

        public void LoadData()
        {
            Residences.Clear();

            var data = DataService.GetAllDistinctResidences();

            foreach (var item in data)
            {
                Residences.Add(item);
            }
        }
    }
}
