using System;

using Pedal_loopregistratie.Models;
using Pedal_loopregistratie_Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class RunnersDetailControl : UserControl
    {
        public Runner MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Runner; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Runner), typeof(RunnersDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public RunnersDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RunnersDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
