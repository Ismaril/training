using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    // Here (Classes) prefix before Student, is not connected to Student. It is rather used for better 
    //  organisation of naming in a folder. (Personal)
    public class ClassesStudent
    {
        // CLASS ATTRIBUTES (a.k.a. FIELDS)
        public string name;
        public int age;
        public int id;
        private string ethnicity;

        // STATIC CLASS ATTRIBUTES
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
        // Must match the class name.
        // Must not have a return type.
        // All classes have constructors by default: if you do not create a class constructor yourself,
        //  C# creates one for you. However, then you are not able to set initial values for fields.
        // Just like other methods, constructors can be overloaded by using different numbers of parameters.
        public ClassesStudent(string aName, int aAge, int aId, string aEthnicity)
        {
            name = aName;
            age = aAge;
            id = aId;
            Ethnicity = aEthnicity;
            counter++;
        }

        // METHOD
        // It is possible to define default paramter, default = optional paramter,
        //  (give it value at function declaration).
        // Declaration: the function's name, return type, and parameters (if any)
        // Definition: the body of the function (code to be executed)
        public bool IsAboveThirtyFive(bool someParamter = true)
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

        // METHOD OVERLOADING
        // Instead of defining two methods that should do the same thing,
        //  it is better to overload one.
        // Multiple methods can have the same name as long as the number and/or
        //  type of parameters are different.
        // In the example below, we overload the PlusMethod method to work for
        //  both int and double:
        public static int PlusMethod(int x, int y)
        {
            return x + y;
        }

        public static double PlusMethod(double x, double y)
        {
            return x + y;
        }


        // PROPERTIES, GETTER, SETTER 
        // Are used to ENCAPSULATE code - better control and security of class members.
        // Notice that we normally created class atribute 'private string ethnicity',
        //  constructor with 'Ethnicity = aEthnicity' and above else also new string
        //  (Ethnicity) which has getter and setter.
        // The process is following - user inputs new value into instance of a class outside. The
        //  value is now passed from parameter aEthnicity to public string Ethnicity. Based on the
        //  value which was inputed into the instance of a class, the setter in this case below
        //  checks the condition and assigns new value to internal string ethnicity. If the user
        //  wants to access the value stored in public string ethnicity, he has to call the public
        //  string Ethnicity and its getter will return value.

        // PROPERTY (Use the same name as the class atribute/field, but with Capital first letter.
        public string Ethnicity 
        {
            set // SETTER
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
            get // GETTER
            {
                return ethnicity;
            }
        }

        // short way to write simple getter and setter
        public string NameOfProperty  // property
        { get; set; }  // getter and setter
    }
    
    // INHERITANCE
    // If there are specified parameters in the class, then you have to use BASE keyword.
    // Todo: explain the base keyword.
    public class UniversityStudent : ClassesStudent // inherits from Student.
    {
        protected string major;

        public UniversityStudent(string aName, int aAge, int aId,
                                string aEthnicity, string aMajor) : base (aName, aAge, aId, aEthnicity)
        {
            name = aName;
            age = aAge;
            id = aId;
            Ethnicity = aEthnicity;
            major = aMajor;

        }
    }
}