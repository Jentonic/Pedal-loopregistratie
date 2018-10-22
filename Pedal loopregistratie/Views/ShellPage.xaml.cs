using System;

using Pedal_loopregistratie.Services;
using Pedal_loopregistratie.ViewModels;
using Pedal_loopregistratie_Model.Models;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Pedal_loopregistratie.Views
{
    // TODO WTS: Change the icons and titles for all NavigationViewItems in ShellPage.xaml.
    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel
        {
            get { return DataContext as ShellViewModel; }
        }

        public ShellPage()
        {
            InitializeComponent();
            HideNavViewBackButton();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, navigationView);
            KeyboardAccelerators.Add(ActivationService.AltLeftKeyboardAccelerator);
            KeyboardAccelerators.Add(ActivationService.BackKeyboardAccelerator);
        }

        private void HideNavViewBackButton()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 6))
            {
                navigationView.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
            }
        }

        //#region Queue Commandhandlers
        //private void UpButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    if (QueueListView.SelectedItem != null)
        //    {
        //        QueueService.MoveUp((QueueRunner)QueueListView.SelectedItem);
        //    }
        //}

        //private void DownButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    if (QueueListView.SelectedItem != null)
        //    {
        //        QueueService.MoveDown((QueueRunner)QueueListView.SelectedItem);
        //    }
        //}

        //private void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    if (QueueListView.SelectedItem != null)
        //    {
        //        QueueService.Remove((QueueRunner)QueueListView.SelectedItem);
        //    }
        //}
        

        //private void NextRunnerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    QueueService.QueueNextRunner();
        //}

        //private void RefreshButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        //{
        //    QueueService.Refresh();
        //}
        //#endregion
    }
}
