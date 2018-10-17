using System;

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
    }
}
