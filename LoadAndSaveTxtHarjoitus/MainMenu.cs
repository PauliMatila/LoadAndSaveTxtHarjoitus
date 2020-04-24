using System;
using System.Collections.Generic;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class MainMenu
    {
        public DataHandler dataHandler;
        public List<Person> peopleList;

        FileHandler fh = new FileHandler();

        public MainMenu(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public void OpenMainMenu()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = ShowMainMenu();
            }
        }
        
        public bool ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Input new person");
            Console.WriteLine("2. Show list of people");
            Console.WriteLine("3. Save people list to file");
            Console.WriteLine("4. Load people list from file");
            Console.WriteLine("5. Show people list from file");
            Console.WriteLine("6. Exit");
            int selected = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (selected)
            {
                case 1:
                    dataHandler.AddNewPersonToList();
                    break;
                case 2:
                    dataHandler.PrintPeopleList();
                    break;
                case 3:
                    dataHandler.SaveList();
                    break;
                case 4:
                    peopleList = dataHandler.LoadPersonDataFromCurrentFile();
                    break;
                case 5:
                    dataHandler.AddPersonDataToList(peopleList);
                    break;
                case 6:
                    return false;
                default:
                    Console.Clear();
                    return true;
            }
            Console.WriteLine("Press any key");
            Console.ReadKey();
            return true;
        }
    }
}
