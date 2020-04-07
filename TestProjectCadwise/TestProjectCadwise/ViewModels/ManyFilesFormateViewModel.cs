using Caliburn.Micro;
using System;
using System.IO;
using TestProjectCadwise.Models;
using TestProjectCadwise.Utils;

namespace TestProjectCadwise.ViewModels
{
    class ManyFilesFormateViewModel : Screen
    {
        public FormatingModel SettingValue { get; set; }
        public FileNameReturner MyFileDialog { get; set; }
        public ManyFilesFormateViewModel()
        {
            SettingValue = new FormatingModel();
            MyFileDialog = new FileNameReturner();
        }
        public void Formate()
        {
            var str = MyFileDialog.GetOpenFiles();
            if (str == null)
                return;
            foreach (var item in str)
            {              
                SettingValue.InputFile = item;                       
                SettingValue.OutputFile = MyFileDialog.GetSaveFiles(item);
                if (string.IsNullOrEmpty(SettingValue.InputFile))
                {
                    return;
                }
                else
                {
                    var f = new FileFormater(SettingValue);
                    f.Formate();
                }
            }           
        }
       
    }
}
