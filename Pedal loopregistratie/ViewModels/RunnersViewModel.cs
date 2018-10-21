using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Pedal_loopregistratie.Models;
using Pedal_loopregistratie.Services;
using Pedal_loopregistratie_Model;

namespace Pedal_loopregistratie.ViewModels
{
    public class RunnersViewModel : ViewModelBase
    {
        private Runner _selected;

        public Runner Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Runner> Runners { get; private set; } = new ObservableCollection<Runner>();

        public RunnersViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Runners.Clear();

            var data = await DataService.GetRunnersAsync();

            foreach (var item in data)
            {
                Runners.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Runners.First();
            }
        }
    }
}
