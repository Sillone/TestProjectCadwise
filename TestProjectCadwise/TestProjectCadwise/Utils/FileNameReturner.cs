using Microsoft.Win32;
using System;
using System.IO;

namespace TestProjectCadwise.Utils
{
    public class FileNameReturner
    {
        string defalutExt = ".txt";
        string filter = "Text documents (.txt)|*.txt";
        public string GetOpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.DefaultExt = defalutExt;
            openFile.Filter = filter;
            if (openFile.ShowDialog() == true)
                return openFile.FileName;
            else
                return string.Empty;
        }
        public string GetSaveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = defalutExt;
            saveFile.Filter = filter;
            if (saveFile.ShowDialog() == true)
            {
                if (!saveFile.OverwritePrompt)
                {
                   
                    return saveFile.FileName;
                }
                else
                {
                    OverwriteFile(saveFile.FileName);
                    return saveFile.FileName;
                }
            }
            else
            {
                return string.Empty;
            }

        }
        public void OverwriteFile(string file)
        {
            File.WriteAllText(file, String.Empty);
        }
        public string[] GetOpenFiles()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            openFile.DefaultExt = defalutExt;
            openFile.Filter = filter;
            if (openFile.ShowDialog() == true)
            {                
                return openFile.FileNames;
            }
                
            else
                return null;
        }
        private void CheckFile(string fileName)
        {
            if (File.Exists(fileName))
                OverwriteFile(fileName);
        }
        public string GetSaveFiles(string _fileName)
        {
            FileInfo fileInfo = new FileInfo(_fileName);
            if (!Directory.Exists(fileInfo.Directory + "\\Formated"))
                Directory.CreateDirectory(fileInfo.Directory + "\\Formated");
            var fileName = $"{fileInfo.Directory}\\Formated\\{fileInfo.Name}";
            CheckFile(fileName);
            return fileName;
        }
    }
}
