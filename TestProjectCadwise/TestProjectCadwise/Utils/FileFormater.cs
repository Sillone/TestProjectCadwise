using System.IO;
using System.Text.RegularExpressions;
using TestProjectCadwise.Models;

namespace TestProjectCadwise.Utils
{
    class FileFormater
    {
        private FormatingModel settingValue;
        readonly string pattern = "-.?!)(,:<>\"«";
        StreamReader reader;
        public FileFormater(FormatingModel value)
        {
            settingValue = value;
            reader = new StreamReader(settingValue.InputFile);
        }

        public void Formate()
        {
           bool fileEnd = false;
           string inputString;


            while (!fileEnd)
            {
                inputString = ReadInputString();
                if (string.IsNullOrEmpty(inputString))
                    fileEnd = true;
                if (settingValue.DeletePunctMark)
                   inputString = DeletePunct(inputString);
                var outputString = FormatString(inputString);
                WriteOutputString(outputString);
            }
        }
        private string ReadInputString()
        {
            if (!reader.EndOfStream)
                return reader.ReadLine();
            else
                return null;
        }
        private string FormatString(string inputStr)
        {
            var tempStrings = inputStr.Split(' ');
            string outputString = string.Empty;
            for (int i = 0; i < tempStrings.Length; i++)
            {
                var ind = tempStrings[i].IndexOfAny(pattern.ToCharArray(0, pattern.Length));
                if ((ind == -1) && (tempStrings[i].Length >= settingValue.MinWorldLenght))
                {
                    outputString = $"{outputString} {tempStrings[i]}";
                }
                else if (ind >= settingValue.MinWorldLenght)
                {
                    outputString = $"{outputString} {tempStrings[i]}";
                }
                else if (Regex.IsMatch(tempStrings[i], $"[{pattern}]"))
                {
                    outputString = $"{outputString} {Regex.Replace(tempStrings[i], "[а-яА-ЯёЁa-zA-Z0-9]", "")}";
                }
            }
            return outputString;
        }
        private string DeletePunct(string inputString)
        {
            return Regex.Replace(inputString, $"[{pattern}]", "");
        }
        private void WriteOutputString(string outputstr)
        {   
            StreamWriter writer = new StreamWriter(settingValue.OutputFile, true);
            writer.Write($"{outputstr}\n");
            writer.Close();
        }
       
    }
}
