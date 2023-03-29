using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class ClassesMain
    // It is a good practise that the name of the file and the class have matching name. But
    //  it is not mandatory. Code will work (unlike in Java).


    // ACCESS MODIFIERS
    // public - The code is accessible for all classes
    // private - The code is only accessible within the same class. (Default if you do not specify access modifier)
    // protected - The code is accessible within the same class, or in a class that is inherited from that class.
    // internal The code is only accessible within its own assembly, but not from another assembly.
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("CLASSES");

            // Without constructor, you can asign new values like this below,
            // but it is not good practise:
            ClassesSource_2 book1 = new ClassesSource_2();
            book1.title = "Jak Jarda ztratil pivsona.";
            book1.author = "Jarda";
            book1.numberOfPages = 300;
            Console.WriteLine(book1.title);

            // With constructor, good practise.
            Magazine magazine1 = new Magazine(aTitle: "Playboy",
                                              aAuthor: "Larry",
                                              aNumberOfPages: 30);

            ClassesSource_1 studentDefault = new ClassesSource_1();
            Console.WriteLine(studentDefault.name);

            Console.WriteLine(magazine1.title);

            // Here it is possible to create a new instance of a class
            //  because Magazine class has also second constructor without
            //  defined paramters.
            Magazine magazine2 = new Magazine();

            // OBJECT METHODS
            // aName is a PARAMETER
            // "Tom" is an ARGUMENT
            ClassesSource_1 student1 = new ClassesSource_1(aName: "Tom", aAge: 36, aId: 4590, aEthnicity: "White");
            ClassesSource_1 student2 = new ClassesSource_1(aName: "Bob", aAge: 34, aId: 4591, aEthnicity: "Black");

            Console.WriteLine($"Is older: {student1.IsAboveThirtyFive()}");
            Console.WriteLine($"Is older: {student2.IsAboveThirtyFive()}");

            Console.WriteLine(ClassesSource_1.PlusMethod(10, 30));
            Console.WriteLine(ClassesSource_1.PlusMethod(10.01, 30.56));
            utility.Separator();

            // GETTER
            Console.WriteLine($"Ethnicity of student1: {student1.Ethnicity}");
            Console.WriteLine($"Ethnicity of student2: {student2.Ethnicity}");

            // STATIC CLASS ATTRIBUTES
            Console.WriteLine($"Member of which shool? student1: {ClassesSource_1.memberOfWhichSchool}");
            // It is not possible to access it on an instance of a class:
            // Console.WriteLine($"Member of which shool? student1: {student1.memberOfWhichSchool}");

            // STATIC CLASS METHODS
            ClassesSource_1.WelcomeStudent(name: "Nixon");

            // STATIC CLASSES
            // It is not possible to create an instance of a class.
            // poster1 = Poster(); -> Not possible
            Console.WriteLine(Poster.size);

            // POLYMORPHISM
            // Here where you specify type, it seems that it does not matter if the class matches the "new" object,
            //  seems like you could also in this case put everywhere ClassesStudent as type and it would work also.
            //    |
            //    |
            //    v
            ClassesSource_1 commonStudent_1 = new ClassesSource_1("Mojmir", 20, 4390, "White");
            UniversityStudent univerityStudent_1 = new UniversityStudent("Cenda", 26, 9000, "White", "Arts");
            // ClassesStudent univerityStudent_1 = new UniversityStudent("Cenda", 26, 9000, "White", "Arts"); It seems this is also possible.
            HighShoolStudent highSchoolStudnet_1 = new HighShoolStudent("Ferin", 15, 3456, "White");

            commonStudent_1.DrawCircle();
            univerityStudent_1.DrawCircle();
            highSchoolStudnet_1.DrawCircle();


            // ABSTRACTION
            // Not possible:
            // (Cannot create an instance of the abstract class or interface 'Animal')
            // Animal myObj = new Animal(); // Will generate an error 
             
            // Is possible:
            Pig myPig = new Pig(); // Create a Pig object. Notice that on the left side the type is Pig, not Animal.
            myPig.animalSound();  // Call the abstract method
            myPig.sleep();  // Call the regular method
             


            utility.Separator();
        }
    }
}
