using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class DataHandler
    {
        List<Person> people = new List<Person>();
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
            List<string> lines = PersonListToString(people);
            WriteLineToFile(lines);
        }

        public void SaveList()
        {
            SavePeopleList(people);
            Console.WriteLine("Peoples are saved!");
            Console.WriteLine($"{fh.filePath}");
        }

        public List<string> LoadData(string filePath)
        {
            List<string> lines = fh.ReadFile(filePath);
            
            //foreach (var line in lines)
            //{
            //    string[] entries = line.Split(',');

            //    Person newPerson = new Person();
            //    newPerson.name = entries[0];
            //    newPerson.age = int.Parse(entries[1]);
            //    newPerson.ageCheck = bool.Parse(entries[2]);
                
            //    people.Add(newPerson);
            //}

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.name} age: {person.age}\nAge check: {person.ageCheck}");
            }
            return lines;
        }
    }
}
