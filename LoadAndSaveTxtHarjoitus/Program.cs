using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LoadAndSaveTxtHarjoitus
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler fh = new FileHandler();
            DataHandler dh = new DataHandler(fh);
            MainMenu mainMenu = new MainMenu(dh);
            mainMenu.OpenMainMenu();
        }
    }
}
