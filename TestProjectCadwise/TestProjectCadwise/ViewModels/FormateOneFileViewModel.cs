using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectCadwise.Models;
using TestProjectCadwise.Utils;

namespace TestProjectCadwise.ViewModels
{
    class FormateOneFileViewModel : Screen
    {
        public FormatingModel SettingValue { get; set; }
        public FileNameReturner MyFileDialog { get; set; }

        public bool Can { get; set; }
        public FormateOneFileViewModel()
        {
            SettingValue = new FormatingModel();
            MyFileDialog = new FileNameReturner();
        }
        public bool CanFormate(bool can) => can;
        public void Formate()
        {
            Can = false;
            SettingValue.InputFile = MyFileDialog.GetOpenFile(); ;
            SettingValue.OutputFile = MyFileDialog.GetSaveFile();
            if (string.IsNullOrEmpty(SettingValue.InputFile) || string.IsNullOrEmpty(SettingValue.OutputFile))
            {
                Can = true;
                return;
            }
            var f = new FileFormater(SettingValue);
            f.Formate();
            Can = true;
        }
    }
}
