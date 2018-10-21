using Pedal_loopregistratie.Services;
using Pedal_loopregistratie.ViewModels;
using Pedal_loopregistratie_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Pedal_loopregistratie.Views
{
    public sealed partial class NewRunnerContentDialog : ContentDialog
    {
        public ObservableCollection<string> Residences { get; private set; }

        private NewRunnerContentDialogViewModel ViewModel
        {
            get { return DataContext as NewRunnerContentDialogViewModel; }
            set { ViewModel = value; }
        }

        public NewRunnerContentDialog()
        {
            this.InitializeComponent();
            Residences = new ObservableCollection<string>();
        }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(FirstName.Text) && !string.IsNullOrWhiteSpace(LastName.Text) && !string.IsNullOrWhiteSpace(Residence.SelectedItem.ToString()))
            {
                var residence = DataService.ResolveResidenceFromNameAsync(Residence.SelectedItem.ToString()).Result;
                var runner = new Runner
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Residence = residence,
                    ResidenceId = residence.ResidenceId
                };
                DataService.AddNewRunnerAsync(runner);
            }
        }

        private void ContentDialog_CloseButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var data = DataService.GetAllDistinctResidencesAsync().Result;
            foreach (var item in data)
            {
                Residences.Add(item);
            }
        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
        }
    }
}
