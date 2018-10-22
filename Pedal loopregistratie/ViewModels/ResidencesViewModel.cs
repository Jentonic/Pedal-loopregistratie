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
    public class ResidencesViewModel : ViewModelBase
    {
        private Residence _selected;

        public Residence Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Residence> Residences { get; private set; } = new ObservableCollection<Residence>();

        public ResidencesViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            Residences.Clear();

            var helper = await DataService.GetResidencesAsync();
            var data = helper.OrderBy(x => x.Name).ToList();

            foreach (var item in data)
            {
                Residences.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Residences.First();
            }
        }
    }
}
