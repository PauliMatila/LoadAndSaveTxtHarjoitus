using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class FileHandler
    {
        public string filePath;
        public string fileName;

        public FileHandler(string aFilePath, string aFileName)
        {
            filePath = aFilePath;
            fileName = aFileName;
        }

        public FileHandler()
        {
            filePath = @"D:\harjotus\";
            fileName = "PersonData.txt";           
        }                

        public List<string> ReadFile(string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            return lines;
        }

        public void WriteFile(List<string> lines)
        {            
            File.WriteAllLines(filePath, lines);
        }
    }
}
