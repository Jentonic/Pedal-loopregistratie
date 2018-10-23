using System;

using Pedal_loopregistratie.Services;
using Pedal_loopregistratie_Model;
using Pedal_loopregistratie_Model.DAL;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using System.Linq;

namespace Pedal_loopregistratie
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);

            // Replaced by static init method in dataservice


            //    // Testcode below

            //    //var lele = "lele";
            //    //var residence = new Residence { ResidenceId = 3, Name = "test", Description = "test", ImageString = "test" };
            //    //db.Residences.Add(residence);
            //    //db.SaveChanges();
            //    //db.Residences.Remove(residence);
            //    //db.SaveChanges();
            //    //var lelele = "lelele";
            Initialise();
            // TestCode

            // Add new Residence
            // var residence = new Residence { ResidenceId = , Name = "", Description = "", ImageString = "" };
            // DataService.DbContext.Residences.Add(residence);
            // DataService.DbContext.SaveChanges();

            // Update Residence
            //var residence = DataService.DbContext.Residences.FirstOrDefault(x => x.Name == "");
            //residence.Description = "";
            //DataService.DbContext.Residences.Update(residence);
            //DataService.DbContext.SaveChanges();

            // Clear Database
            //DataService.DbContext.Laps.RemoveRange(DataService.DbContext.Laps);
            //DataService.DbContext.QueueRunners.RemoveRange(DataService.DbContext.QueueRunners);
            //DataService.DbContext.Runners.RemoveRange(DataService.DbContext.Runners);
            //Initialise();
            //DataService.DbContext.SaveChanges();
        

        //Ugly testcode, move this to migration if enough time
        //DataService.DbContext.Runners.Add(new Runner { FirstName = "Jenne", LastName = "Baeten", ResidenceId = 2 });
        //DataService.DbContext.SaveChanges();
    }

        private void Initialise()
        {
            // Init services
            DataService.Init();
            QueueService.Init();
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(ViewModels.HomeViewModel), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
