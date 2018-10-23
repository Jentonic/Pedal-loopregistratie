using System;

using Pedal_loopregistratie_Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class ResidencesDetailControl : UserControl
    {
        public Residence MasterMenuItem
        {
            get
            {
                if (counter == 0)
                {
                    OnPropertyChanged();
                    counter--;
                }
                return GetValue(MasterMenuItemProperty) as Residence;
            }
            set
            {
                SetValue(MasterMenuItemProperty, value);
                OnPropertyChanged();
            }
        }

        private static int counter = 0;

        private void OnPropertyChanged()
        {
            //Runners.Text = TotalRunners;
            counter++;
            Laps.Text = TotalLaps;
        }

        public string TotalRunners
        {
            get { return AllRunners().ToString(); }
        }

        private int AllRunners()
        {
            if (MasterMenuItem == null)
                return 0;
            return MasterMenuItem.Runners.Count;
        }

        public string TotalLaps
        {
            get { return AllLaps().ToString(); }
        }

        private int AllLaps()
        {
            if (MasterMenuItem == null)
                return 0;
            int count = 0;
            foreach (var item in MasterMenuItem.Runners)
            {
                count += item.Laps.Count;
            }
            return count;
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Residence), typeof(ResidencesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public ResidencesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ResidencesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
