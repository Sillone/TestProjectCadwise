using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestProjectCadwise.Models
{
    class FormatingModel : PropertyChangedBase
    {
        public int MinWorldLenght { get; set; }
        public bool DeletePunctMark { get; set; }
        public string InputFile { get; set; }
        public string OutputFile { get; set; }
      
    }
}
