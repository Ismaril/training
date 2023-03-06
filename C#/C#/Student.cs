using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Student
    {
        // class attributes
        public string name;
        public int age;
        public int id;

        // constructor
        public Student(string aName, int aAge, int aId) { 
            name = aName;
            age = aAge;
            id = aId;
        }

        // method
        public bool IsAboveThirtyFive()
        {
            return age > 35;
        }
    }
}
