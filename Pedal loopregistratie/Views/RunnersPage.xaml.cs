using System;
using System.Threading.Tasks;
using Pedal_loopregistratie.Helpers;
using Pedal_loopregistratie.Services;
using Pedal_loopregistratie.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class RunnersPage : Page
    {
        private RunnersViewModel ViewModel
        {
            get { return DataContext as RunnersViewModel; }
        }

        public RunnersPage()
        {
            InitializeComponent();
            Loaded += RunnersPage_Loaded;
        }

        private async void RunnersPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }

        private async void NewRunnerAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            NewRunnerContentDialog newRunnerContentDialog = new NewRunnerContentDialog();
            ContentDialogResult result = await newRunnerContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Frame.Navigate(typeof(RunnersPage), "Force refresh");
                //var navserv = new NavigationServiceEx();
                //navserv.Navigate();
            }
        }

        private void AddRunnerToQueueButton_Click(object sender, RoutedEventArgs e)
        {
            QueueService.AddRunner(ViewModel.Selected);
        }

        private void SearchRunner_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            ViewModel.Runners
        }
    }
}
