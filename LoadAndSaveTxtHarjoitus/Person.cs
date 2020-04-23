using System;
using System.Collections.Generic;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public bool ageCheck { get; set; }

        public Person()
        {

        }

        public Person(string firstName, string lastName, int age, bool ageCheck)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.ageCheck = ageCheck;
        }
    }
}
