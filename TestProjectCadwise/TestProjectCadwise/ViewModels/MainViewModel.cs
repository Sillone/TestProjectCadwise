using Caliburn.Micro;
using Microsoft.Win32;
using TestProjectCadwise.Models;
using TestProjectCadwise.Utils;

namespace TestProjectCadwise.ViewModels
{
    class MainViewModel : Conductor<object>
    {
       
        public void LoadOneFileFormate()
        {
            ActivateItem(new FormateOneFileViewModel());
        }
        public void LoadManyFilesFormate()
        {
            ActivateItem(new ManyFilesFormateViewModel());
        }
    }
}
