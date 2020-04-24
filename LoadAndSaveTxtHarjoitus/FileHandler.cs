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
        public string currentFile { get; set; } = "PersonData.txt";

        public FileHandler(string aCurrentPath, string aCurrentFile)
        {
            currentPath = aCurrentPath;
            currentFile = aCurrentFile;
        }

        public FileHandler()
        {
            
        }
        //var files = Directory.GetFiles(currentPath, "*.txt", SearchOption.TopDirectoryOnly);
        public List<string> ReadFile(string currentPath)
        {
            if (File.Exists(currentPath))
            {
                List<string> lines = File.ReadAllLines(currentPath).ToList();
                return lines;
            }
            else
            {
                Console.WriteLine("Folder is empty", currentPath);
            }
            return null;
        }

        public void WriteFile(List<string> lines)
        {
            Console.WriteLine("1. Select default file name.");
            Console.WriteLine("2. Input new file name.");
            int selected = int.Parse(Console.ReadLine());
            switch (selected)
            {
                case 1:
                    File.WriteAllLines(GetCurrentFilePath(), lines);
                    break;
                case 2:
                    File.WriteAllLines(CreateFileName(), lines);
                    break;
                default:
                    Console.WriteLine("Select 1. or 2.");
                    break;
            }
        }

        public string GetCurrentFilePath()
        {
            return currentPath + currentFile;
        }

        public string CreateFileName()
        {
            Console.WriteLine("Enter filename: ");
            currentFile = Console.ReadLine() + ".txt";
            return currentPath + currentFile;
        }
    }
}
