using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_
{
    // Here (Classes) prefix before Student, is not connected to Student. It is rather used for better 
    //  organisation of naming in a folder. (personal stuff...)
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

        // (section POLYMORPHISM explained below)
        // This method will be used later for polymorphism.
        // You have to use VIRTUAL keyword, in order for this method to be available to be overriden by child classes.
        public virtual void DrawCircle()
        {
            Console.WriteLine("Studnet draws some circle");
        }


        // PROPERTIES, GETTER, SETTER 
        // Are used to ENCAPSULATE code - better control and security of class members.
        // To setup properties, you have to:
        //  Declare fields/variables as private
        //  Provide public get and set methods, through properties, to access and update the value of a private field
        // Notice that we normally created class atribute 'private string ethnicity',
        //  constructor with 'Ethnicity = aEthnicity' and above else also new string
        //  (Ethnicity) which has getter and setter.
        // The process is following - user inputs new value into instance of a class outside. The
        //  value is now passed from parameter aEthnicity to public string Ethnicity. Based on the
        //  value which was inputed into the instance of a class, the setter in this case below
        //  checks the condition and assigns new value to internal string ethnicity. If the user
        //  wants to access the value stored in public string ethnicity, he has to call the public
        //  string Ethnicity and its getter will return value.

        public string Ethnicity // PROPERTY (Use the same name as the class atribute/field, but with Capital first letter.
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

        // (section POLYMORPHISM explained below)
        // Use OVERRIDE keyword, so that mathod that you want to use in POLYMORPHISM does unique stuff, that you defined here. Without override 
        //  keyword, the method would do the same thing that was defined in parent class method.
        public override void DrawCircle()
        {
            Console.WriteLine("University studnet draws perfect circle");
        }

    }

    // SEALED
    // With sealed keyword before a class, other classes will not be able to inherit from thisone.
    // Use it if you want to limit inheritance.
    sealed class SomeSealedClass { }


    // POLYMORPHISM
    // Polimorphism means of many forms.
    // In practise this means that during inheritance there can be mathods that will have the same name accross
    //  many classes, but they will do different things.
    // It is important that the polymorphic methods have the same name. The parent method must have 'virtual' keyword in it. Methods in child classes
    //  then have to have 'override' keyword. Without this keywords, the methods would just do the same thing as it is defined in the parent class method.

    public class HighShoolStudent: ClassesStudent
    {
        public HighShoolStudent(string aName, int aAge, int aId, string aEthnicity) : base (aName, aAge, aId, aEthnicity)
        {
            name = aName;
            age = aAge;
            id = aId; 
        }

        // Use OVERRIDE keyword, so that mathod that you want to use in POLYMORPHISM does unique stuff, that you defined here. Without override 
        //  keyword, the method would do the same thing that was defined in parent class method.
        public override void DrawCircle()
        {
            Console.WriteLine("Highshool studnet draws decent circle");
        }
    }


    // ABSTRACTION
    /* Data abstraction is the process of hiding certain details and showing only essential 
     *  information to the user.
     * Abstraction can be achieved with either abstract classes or interfaces.
     * The abstract keyword is used for classes and methods:
     *  -> Abstract class: is a restricted class that cannot be used to create objects
     *      (to access it, it must be inherited from another class).
     *  -> Abstract method: can only be used in an abstract class, and it does not have a body. 
     *      The body is provided by the derived class (inherited from).
     */

    // With this code, it will not be possible to create an instance of Animal class.
    // Notice also, that in abstract class, you can still create object like mehthod which is not abstract.
    // Do not take relevance of these classes in account, they are rather example of abstraction concepts.
    abstract class Animal // Abstract class
    {
        public abstract void animalSound();
        public void sleep()
        {
            Console.WriteLine("Zzz");
        }
    }

    // To access the abstract class, it must be inherited from another class.
    class Pig : Animal // Pig is derived class (inherit from Animal)
    {
        public override void animalSound()
        {
            // The body of animalSound() is provided here
            Console.WriteLine("The pig says: wee wee");
        }
    }

    
}