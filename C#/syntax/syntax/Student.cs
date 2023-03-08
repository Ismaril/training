using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Student
    {
        // CLASS ATTRIBUTES
        public string name;
        public int age;
        public int id;
        private string ethnicity;

        // STATIC CLASS ATTRIBUTES
        // (is the same to all instances of that class)
        // Can be used only on Class.static_atribute. It cannot be used on instances
        //  like my_class1.static_atribute
        public static string memberOfWhichSchool = "Some high shool";
        public static int counter = 0; // We could for example use this line to check
                                       //   how many times an instance of this class has
                                       //   been created, by incrementing it witch each call.
                                       // You could theoretically use static attribute on an
                                       //   instance of a class but you would have to do it through
                                       //   some of your custom getter methods etc.

        // CONSTRUCTOR
        public Student(string aName, int aAge, int aId, string aEthnicity)
        {
            name = aName;
            age = aAge;
            id = aId;
            Ethnicity = aEthnicity;
            counter++;
        }

        // METHOD
        public bool IsAboveThirtyFive()
        {
            return age > 35;
        }

        // STATIC METHOD
        // Static method is a method which belongs to the actual class (seems like it can't be actually used on instances)
        // Example of build in class method: Math.Sqrt(someNumber)
        // This example is only to show the syntax, not the actual relevance of the function.
        public static void WelcomeStudent(string name)
        {
            Console.WriteLine($"Hello {name}, you are our new student!");
        }

        // GETTER, SETTER
        // Notice that we normally created class atribute 'private string ethnicity',
        //  constructor with 'Ethnicity = aEthnicity' and above else also new string
        //  (Ethnicity) which has getter and setter.
        // The process is following - user inputs new value into instance of a class outside. The
        //  value is now passed from parameter aEthnicity to public string Ethnicity. Based on the
        //  value which was inputed into the instance of a class, the setter in this case below
        //  checks the condition and assigns new value to internal string ethnicity. If the user
        //  wants to access the value stored in public string ethnicity, he has to call the public
        //  string Ethnicity and its getter will return value.
        public string Ethnicity
        {
            set
            {
                // value is a keyword, and means whatever value user inputed as a parameter
                //  into class from the outside.
                if (value == "White"
                    || value == "Black"
                    || value == "Yellow")
                {
                    ethnicity = value;
                }
                else
                {
                    ethnicity = "Color not specified correctly.";
                }
            }
            get
            {
                return ethnicity;
            }
        }
    }
    /*
    // INHERITANCE
    internal class UniversityStudent : Student // inherits from Student.
    {
        // todo: fix this error on row 92.
        public UniversityStudent(string aName, int aAge, int aId, string aEthnicity)
        {
            name = aName;
            age = aAge;
            id = aId;
            Ethnicity = aEthnicity;
        }
    }
    */
}