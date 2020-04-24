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

        List<Person> list = new List<Person>();
        
        List<string> lines = new List<string>();
        
        FileHandler fh = new FileHandler();

        public DataHandler(FileHandler fileHandler)
        {
            fh = fileHandler;
        }

        public string UppercaseFirst(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            return char.ToUpper(value[0]) + value.Substring(1);
        }

        public Person AddNewPerson()
        {
            Console.Write("Give person's first name: ");
            string firstName = Console.ReadLine();
            Console.Clear();
            Console.Write("Give person's last name: ");
            string lastName = Console.ReadLine();
            Console.Clear();
            Console.Write("Give person's age: ");
            var ageAsString = Console.ReadLine();
            Console.Clear();
            int age;           
            while(!int.TryParse(ageAsString, out age))
            {
                Console.WriteLine("Oops! You didn't input age!");
                Console.Write("Give person's age: ");
                ageAsString = Console.ReadLine();
            }
            bool ageCheck = false;
            Person person = new Person(UppercaseFirst(firstName).Trim(), UppercaseFirst(lastName).Trim(), age, ageCheck);
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

        //public Person SelectList()
        //{
        //    PrintPeopleList();
        //    Console.WriteLine("Input persons number:");
        //    int selected = int.Parse(Console.ReadLine());
        //    return list[selected - 1];
        //}

        public void PrintPeopleList()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("List is empty");
                return;
            }
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Name: {people[i].firstName} {people[i].lastName} \nAge: {people[i].age}");
                
                if (people[i].ageCheck == true)
                {
                    Console.WriteLine("Person is adult");
                }
                if (people[i].ageCheck == false)
                {
                    Console.WriteLine("Person is minor");
                }
                Console.WriteLine();
            }            
        }

        public List<Person> RemovePersonFromList()
        {
            PrintPeopleList();
            Console.WriteLine("Select person to remove:");
            int selected = int.Parse(Console.ReadLine());           
            people.Remove(selected);
            return people;
        }

        public string PersonToString(Person person)
        {
            return $"{person.firstName},{person.lastName},{person.age},{person.ageCheck}";
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
            Console.Clear();
            SavePeopleList(people);
            Console.WriteLine("Peoples are saved!");
            Console.WriteLine(fh.GetCurrentFilePath());
        }

        public List<string> LoadStringsFromFile(string filePath)
        {
            List<string> lines = fh.ReadFile(filePath);
            if (lines != null)
            {
                Console.Write($"Loading from file...");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Done!");
                Console.ResetColor();
                Console.WriteLine();
                return lines;
            }
            return lines;
        }

        public Person StringToPerson(string personInfo)
        {
            string[] entries = personInfo.Split(',');
            Person newPerson = new Person();

                newPerson.firstName = entries[0];
                newPerson.lastName = entries[1];
                newPerson.age = int.Parse(entries[2]);
                newPerson.ageCheck = bool.Parse(entries[3]); 

            return newPerson;
        }
        
        public List<Person> LoadPersonDataFromCurrentFile()
        {           
            lines = LoadStringsFromFile(fh.GetCurrentFilePath());
            if (lines != null)
            {
                List<Person> newPeople = new List<Person>();
                foreach (string line in lines)
                {
                    newPeople.Add(StringToPerson(line));
                }
                return newPeople;
            }
            return null;
        }

        public void AddPersonDataToList(List<Person> oldPeople)
        {
            if (oldPeople != null)
            {
                people.Clear();
                people.AddRange(oldPeople);
                PrintPeopleList();
            }
            else
            {
                Console.WriteLine("People list is empty");
            }
        }
    }
}
