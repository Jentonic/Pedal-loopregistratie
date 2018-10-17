using System;

using Pedal_loopregistratie.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class ResidencesPage : Page
    {
        private ResidencesViewModel ViewModel
        {
            get { return DataContext as ResidencesViewModel; }
        }

        public ResidencesPage()
        {
            InitializeComponent();
            Loaded += ResidencesPage_Loaded;
        }

        private async void ResidencesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
