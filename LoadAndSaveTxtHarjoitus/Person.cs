using System;
using System.Collections.Generic;
using System.Text;

namespace LoadAndSaveTxtHarjoitus
{
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public bool ageCheck { get; set; }

        public Person()
        {

        }

        public Person(string name, int age, bool ageCheck)
        {
            this.name = name;
            this.age = age;
            this.ageCheck = ageCheck;
        }
    }
}
