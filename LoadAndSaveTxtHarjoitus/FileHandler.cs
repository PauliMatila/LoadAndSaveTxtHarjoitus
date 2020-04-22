using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class FileHandler
    {
        public string currentPath { get; set; } = @"D:\harjotus\";
        public string currentFile { get; set; } = "currentFile.txt";

        public FileHandler(string aCurrentPath, string aCurrentFile)
        {
            currentPath = aCurrentPath;
            currentFile = aCurrentFile;
        }

        public FileHandler()
        {
            
        }                

        public List<string> ReadFile(string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            return lines;
        }

        public void WriteFile(List<string> lines)
        {            
            File.WriteAllLines(GetCurrentFilePath(), lines);
        }

        public string GetCurrentFilePath()
        {
            return currentPath + currentFile;
        }
    }
}
