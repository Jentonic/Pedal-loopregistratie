using System;

using Pedal_loopregistratie.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Pedal_loopregistratie.Views
{
    public sealed partial class LapsDataGridPage : Page
    {
        private LapsDataGridViewModel ViewModel
        {
            get { return DataContext as LapsDataGridViewModel; }
        }

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on LapsDataGridPage.xaml.
        // For more details see the documentation at https://github.com/Microsoft/WindowsCommunityToolkit/blob/master/docs/controls/DataGrid.md
        public LapsDataGridPage()
        {
            InitializeComponent();
        }
    }
}
