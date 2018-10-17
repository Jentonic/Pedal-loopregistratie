using System;

using Pedal_loopregistratie.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class ResidencesDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(ResidencesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

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
