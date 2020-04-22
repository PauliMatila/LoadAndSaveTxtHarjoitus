using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoadAndSaveTxtHarjoitus
{
    public class DataHandler
    {
        List<Person> people = new List<Person>();
        
        List<string> lines = new List<string>();
        
        FileHandler fh = new FileHandler();

        public DataHandler(FileHandler fileHandler)
        {
            fh = fileHandler;
        }

        public Person AddNewPerson()
        {
            Console.WriteLine("Give person's name");
            string name = Console.ReadLine();
            Console.WriteLine("Give person's age");
            int age = int.Parse(Console.ReadLine());
            bool ageCheck = false;
            Person person = new Person(name, age, ageCheck);
            if (person.age >= 18)
            {
                person.ageCheck = true;
            }           
            return person;
        }

        public Person AddNewPersonToList()
        {
            Person person = AddNewPerson();
            people.Add(person);
            Console.WriteLine("Person added to list");
            return person;
        }

        public void PrintPeopleList()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Name: {people[i].name} age: {people[i].age}");
                
                if (people[i].ageCheck == true)
                {
                    Console.WriteLine("Person is adult");
                }
                if (people[i].ageCheck == false)
                {
                    Console.WriteLine("Person is minor");
                }
            }            
        }

        public string PersonToString(Person person)
        {
            return $"{person.name},{person.age},{person.ageCheck}";
        }

        public void WriteLineToFile(List<string> lines)
        {          
                fh.WriteFile(lines);
        }

        public List<string> PersonListToString(List<Person> people)
        {
            List<string> peoples = new List<string>();
            foreach (Person person in people)
            {               
                peoples.Add(PersonToString(person));
            }
            return peoples;
        }

        public void SavePeopleList(List<Person> people)
        {
            lines = PersonListToString(people);
            WriteLineToFile(lines);
        }

        public void SaveList()
        {
            SavePeopleList(people);
            Console.WriteLine("Peoples are saved!");
            Console.WriteLine($"{fh.GetCurrentFilePath()}");
        }

        public List<string> LoadStringsFromFile(string filePath)
        {
            List<string> lines = fh.ReadFile(filePath);
            Console.Write($"Loading from file...");
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done!");
            Console.ResetColor();
            Console.WriteLine();
            return lines;
        }

        public Person StringToPerson(string personInfo)
        {
            string[] entries = personInfo.Split(',');
            Person newPerson = new Person();
            
            newPerson.name = entries[0];
            newPerson.age = int.Parse(entries[1]);
            newPerson.ageCheck = bool.Parse(entries[2]);

            return newPerson;
        }
        
        public List<Person> LoadPersonDataFromCurrentFile()
        {           
            lines = LoadStringsFromFile(fh.GetCurrentFilePath());
            List<Person> newPeople = new List<Person>();
            foreach (string line in lines)
            {
                newPeople.Add(StringToPerson(line));
            }
            return newPeople;
        }

        public void AddPersonDataToList()
        {
            people.Clear();
            people.AddRange(LoadPersonDataFromCurrentFile());
            PrintPeopleList();
        }
    }
}
