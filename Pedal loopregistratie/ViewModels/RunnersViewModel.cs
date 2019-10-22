using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
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

        public List<Runner> AllRunners { get; set; } = new List<Runner>();
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
                AllRunners.Add(item);
            }

            if (NewRunnerSelectedService.NewRunner)
            {
                SetNewRunner(NewRunnerSelectedService.runner);
                NewRunnerSelectedService.NewRunner = false;
            }

            else if (viewState == MasterDetailsViewState.Both)
            {
                Selected = Runners.First();
            }
        }

        public void Filter(string text)
        {
           var helper = AllRunners.Where(p => p.FirstName.ToLower().Contains(text.ToLower()) || p.LastName.ToLower().Contains(text.ToLower()) || p.Residence.Name.ToLower().Contains(text.ToLower())).Distinct();
            Runners.Clear();
            foreach (var item in helper)
            {
                Runners.Add(item);
            }
        }

        public void NotifyQueue()
        {
            MessengerInstance.Send<NotificationMessage>(new NotificationMessage("New runner in queue"));
        }

        public void SetNewRunner(Runner runner)
        {
            var newRunner = AllRunners.Where(p => p.FirstName.Contains(runner.FirstName) && p.LastName.Contains(runner.LastName)).First();
            if (newRunner != null)
                Selected = newRunner;
        }
    }
}
