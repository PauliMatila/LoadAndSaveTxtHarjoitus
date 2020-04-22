using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class FileHandler
    {
        public string filePath;

        public FileHandler(string aFilePath)
        {
            filePath = aFilePath;
        }


        public FileHandler()
        {
            filePath = @"D:\harjotus\PersonData.txt";                   
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
