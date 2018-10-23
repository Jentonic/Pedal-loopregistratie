using Pedal_loopregistratie.ViewModels;
using Pedal_loopregistratie_Model.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pedal_loopregistratie.Views
{
    public sealed partial class QueuePage : Page
    {
        DispatcherTimer dt = new DispatcherTimer();
        Stopwatch stopwatch = new Stopwatch();

        private QueueViewModel ViewModel
        {
            get { return DataContext as QueueViewModel; }
        }

        public QueuePage()
        {
            this.InitializeComponent();
            Loaded += QueuePage_Loaded;
            dt.Tick += Dt_Tick;
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }

        private void Dt_Tick(object sender, object e)
        {
            if (stopwatch.IsRunning)
            {
                TimeSpan ts = stopwatch.Elapsed;
                TimerTextBlock.Text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString() + "." + ts.Milliseconds.ToString();
            }
        }

        private void QueuePage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitAsync();
        }

        #region Queue Commandhandlers
        private void UpButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (QueueListView.SelectedItem != null)
            {
                ViewModel.MoveUp((QueueRunner)QueueListView.SelectedItem);
            }
        }

        private void DownButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (QueueListView.SelectedItem != null)
            {
                ViewModel.MoveDown((QueueRunner)QueueListView.SelectedItem);
            }
        }

        private void DeleteButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (QueueListView.SelectedItem != null)
            {
                ViewModel.Remove((QueueRunner)QueueListView.SelectedItem);
            }
        }


        private void NextRunnerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (!stopwatch.IsRunning && !dt.IsEnabled)
            {
                stopwatch.Start();
                dt.Start();
            }
            if (stopwatch.IsRunning || dt.IsEnabled)
            {
                var helper = stopwatch.Elapsed;
                ViewModel.QueueNextRunner(helper);
            }
            stopwatch.Restart();
        }

        private void RefreshButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //ViewModel.Refresh();
        }
        #endregion

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!stopwatch.IsRunning)
                stopwatch.Start();
            if (!dt.IsEnabled)
                dt.Start();
            //ViewModel.StartTimer();
        }

        private void PauseTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (stopwatch.IsRunning)
                stopwatch.Stop();
            //ViewModel.PauseTimer();
        }
    }
}
