using Caliburn.Micro;
using System.Windows;
using TestProjectCadwise.ViewModels;

namespace TestProjectCadwise
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
