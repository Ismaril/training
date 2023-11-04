using syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace syntax
{
    // Here (Classes) prefix before Student, is not connected to Student. It is rather used for better 
    //  organisation of naming in a folder. (personal stuff...)
    public class Student
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
        // It is called everytime there is created new instance of a class
        // All classes have constructors by default: if you do not create a class constructor
        //  yourself, C# creates one for you. However, then you are not able to set initial
        //  values for fields.
        // Just like other methods, constructors can be overloaded by using different numbers of  
        //   parameters.
        // 'this' keyword has the same purpouse as 'self' in python (more research needed from my 
        //   side to confirm it.)

        // It is possible to assign default class parameters like this:
        // This class below does not expect any parameters and all will be assigned by default.
        public Student() : this(aName: "No name", aAge: 0, aId: 0, aEthnicity: "White") { }
        // Here the class is expecting parameter aName, other parameters will be assigned by defautl)
        public Student(string aName) : this(aName, aAge: 0, aId: 0, aEthnicity: "White") { }
        // This class expects bunch of parameters, and if not filled, it will cause an error.
        public Student(string aName, int aAge, int aId, string aEthnicity)
        {
            this.name = aName;
            this.age = aAge;
            this.id = aId;
            this.Ethnicity = aEthnicity;
            counter++;
        }
        // You can also create just constructor like this, here it does not expect any parameters and does nothing.
        //public Student() { }

        // METHOD
        // It is possible to define default paramter, default = optional paramter,
        //  (give it value at function declaration).
        // Declaration: the function's name, return type, and parameters (if any)
        // Definition: the body of the function (code to be executed)
        public bool IsAboveTwentyFive(bool someParamter = true)
        {
            // (someParameter is just for demonstration of default parameter, it is actually
            //  useless in this method.

            // Just returning directly condition result here.
            return this.age > 22;
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
            set // SETTER (here also check if the data passed in is actually valid)
            {
                // value is a keyword, and means whatever value user inputed as a parameter
                //  into class from the outside.
                if (value == "White"
                    || value == "Black"
                    || value == "Yellow")
                {
                    this.ethnicity = value;
                }
                else
                {
                    throw new Exception("Color not specified correctly.");
                }
            }
            get // GETTER
            {
                return this.ethnicity;
            }
        }

        // short way to write simple getter and setter
        public string NameOfProperty  // property
        { get; set; }  // getter and setter
                       // Below example how to set default value to getter/setter.
                       //{ get; set; } = "Some default value here"
    }

    // INHERITANCE
    // If there are specified parameters in the class, then you have to use BASE keyword.
    // Todo: explain the base keyword.
    public class UniversityStudent : Student // inherits from Student.
    {
        // created a new class attribute
        public string major;

        // BASE keyword - Specify which base-class constructor should be called when creating instances of the derived class.
        public UniversityStudent(string aName, int aAge, int aId,
                                string aEthnicity, string aMajor) : base(aName, aAge, aId, aEthnicity)
        {
            // It is fine to just create "this.variable" of the new class atribute, you do not have to repeat it for attributes
            //  of parent class.
            this.major = aMajor;

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

    public class HighShoolStudent : Student
    {
        public HighShoolStudent(string aName, int aAge, int aId, string aEthnicity) : base(aName, aAge, aId, aEthnicity)
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
    //q: Difference between abstract class and interface?
    //a: Abstract class can have implementation of some methods, interface cannot.

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
        public abstract void animalSound(); // This method will need to be implemented in child class.
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


    // INTERFACE
    //q: Difference between abstract class and interface?
    //a: Abstract class can have implementation of some methods, interface cannot.

    // Another way to achieve abstraction in C#, is with interfaces.
    // An interface is a completely "abstract class", which can only
    //  contain abstract methods and properties (with empty bodies)

    // By default, members of an interface are abstract and public.
    // Interfaces can contain properties and methods, but not fields.

    // To access the interface methods, the interface must be "implemented"
    //  (kinda like inherited) by another class. To implement an interface,
    //  use the : symbol (just like with inheritance). The body of the interface
    //  method is provided by the child class. Note that you do not have to
    //  use the override keyword when implementing an interface:

    // Notes on Interfaces:
    // Like abstract classes, interfaces cannot be used to create objects (it is not possible to create an "IAnimal" object in the Program/Main class)
    // Interface methods do not have a body - the body is provided by the child class.
    // On implementation of an interface, you must override all of its methods (Override keyword is not necesary however).
    // Interfaces can contain properties and methods, but not fields/variables
    // Interface members are by default abstract and public
    // An interface cannot contain a constructor(as it cannot be used to create objects)

    // Why And When To Use Interfaces?
    // 1) To achieve security - hide certain details and only show the important details of an object (interface).
    // 2) C# does not support "multiple inheritance" (a class can only inherit from one base class).
    //  However, it can be achieved with interfaces, because the class can implement multiple interfaces.
    //  Note: To implement multiple interfaces, separate them with a comma (see example below).

    // Interface (Add a letter 'I' before the name of interface, for better distinction from other classes and methods)
    interface IAnimal
    {
        string Name { get; set; }
        void AnimalSound(); // interface method (does not have a body)
        void Run(); // interface method (does not have a body)
           }

    class Pig_ : IAnimal // Pig "implements" the IAnimal interface
    {
        public string Name { get; set; }

        public void AnimalSound()
        {
            // The body of animalSound() is provided here
            Console.WriteLine("The pig says: wee wee");
        }
        public void Run()
        {
            Console.WriteLine("The pig runs");
        }
               
        // consturctor
        public Pig_(string name)
        {
            Name = name;
        }
    }

    // How it would look like in Program/Main:
    //class Program_
    //{
    //    static void Main(string[] args)
    //    {
    //        Pig_ myPig = new Pig_();  // Create a Pig object
    //        myPig.animalSound();
    //    }
    //}


    // MULTIPLE INTERFACES
    // To implement multiple interfaces, separate them with a comma:
    interface IFirstInterface
    {
        void myMethod(); // interface method
    }

    interface ISecondInterface
    {
        void myOtherMethod(); // interface method
    }

    // Implement multiple interfaces
    class DemoClass : IFirstInterface, ISecondInterface
    {
        public void myMethod()
        {
            Console.WriteLine("Some text..");
        }
        public void myOtherMethod()
        {
            Console.WriteLine("Some other text...");
        }
    }

    // How it would look like in Program/Main:
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        DemoClass myObj = new DemoClass();
    //        myObj.myMethod();
    //        myObj.myOtherMethod();
    //    }
    //}


    // PARTIAL INTERFACES
    // It is possible to split an interface into multiple files. Here are obviously those interfaces in the same file,
    //  but you can put each of those two interfaces below into different file and they would still behave
    //  as one interface.
    partial interface IMyPartialInterface
    {
        string Method1();
    }

    partial interface IMyPartialInterface
    {
        string Method2();
    }

    // Both methods that were defined separately in each partial interface
    //  must be implemented in the class that implements the interface.
    class ClassThatExpectsInterface: IMyPartialInterface
    {
        public string Method1()
        {
            return "Method1";
        }

        public string Method2()
        {
            return "Method2";
        }
    }

    // Partial interface used with partial classes:
    partial interface IMyPartialInterface2
    {
        string Method1();
    }

    partial interface IMyPartialInterface2
    {
        string Method2();
    }

    // Both methods that were defined separately in each partial interface
    //  must be implemented in the class that implements the interface.
    // The interface must be inherited atleast in one of the partial classes.
    //  But it is possible to inherit the same interface it in both of them.
    //  It would work the same way.
    partial class PartialClassThatInheritsInterface : IMyPartialInterface2
    {
        public string Method1()
        {
            return "Method1";
        }
    }

    partial class PartialClassThatInheritsInterface // : IMyPartialInterface2
    {
        public string Method2()
        {
            return "Method2";
        }
    }


    // STATIC CLASS
    // It will not be possible to create an instance of this class.
    // Static class cannot inherit from other classes.
    internal static class Poster
    {
        public static int size = 10;
    }

    // CLASS WITHIN A CLASS
    // Usually serve for helper purpouses for the parent class.
    internal class SomeClass
    {
        // constructor
        public SomeClass() { }
       
        // nested class
        public class SomeNestedClass
        {
           // nested class constructor 
            public SomeNestedClass() { }
           
           // some nested class method
           public void PrintSomeBS()
            {
                Console.WriteLine("Just printing some crap.");
            }
        }
    }

    // -----
    // There are just some classes used for presentation purpouses in ClassesMain. You do not have
    //  to study here anything.
    // ---------------------------------------------------------------------------------------------------
    internal class Book
    {
        // class attributes
        public string title;
        public string author;
        public int numberOfPages;

    }

    internal class Magazine
    {
        // These make the class attributes available outside of a class.
        public string title;
        public string author;
        public int numberOfPages;


        // This below is a CONSTRUCTOR - it is called everytime there
        // is created new instance of a class
        public Magazine(string aTitle, string aAuthor, int aNumberOfPages)
        {
            // Here the variables already declared above have assigned 
            //  values to them.
            title = aTitle;
            author = aAuthor;
            numberOfPages = aNumberOfPages;
        }

        // create just empty construcotr (in practise not used I guess...)
        public Magazine() { }
    }
    // ---------------------------------------------------------------------------------------------------
    
    // PARTIAL CLASSES
    // It is possible to split a class into multiple files. Here are obviously those classes in the same file,
    //  but you can put each of those two classes below into different file and they would still behave
    //  as one class.
    partial class MyPartialClass
    {
        public string Method1()
        {
            return "Method1";
        }
    }

    partial class MyPartialClass
    {
        public string Method2()
        {
            return "Method2";
        }
    }

}



