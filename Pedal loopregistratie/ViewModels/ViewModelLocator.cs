using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

using Pedal_loopregistratie.Services;
using Pedal_loopregistratie.Views;

namespace Pedal_loopregistratie.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<HomeViewModel, HomePage>();
            Register<ResidencesViewModel, ResidencesPage>();
            Register<RunnersViewModel, RunnersPage>();
            Register<QueueViewModel, QueuePage>();
        }

        public RunnersViewModel RunnersViewModel => ServiceLocator.Current.GetInstance<RunnersViewModel>();

        public ResidencesViewModel ResidencesViewModel => ServiceLocator.Current.GetInstance<ResidencesViewModel>();

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public QueueViewModel QueueViewModel => ServiceLocator.Current.GetInstance<QueueViewModel>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
