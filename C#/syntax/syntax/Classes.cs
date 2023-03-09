using C_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syntax
{
    internal static class Classes
    {
        internal static void Main__()
        {
            Utilities utility = new Utilities();
            utility.Title("CLASSES");

            // Without constructor, you can asign new values like this below,
            // but it is not good practise:
            ClassesBook book1 = new ClassesBook();
            book1.title = "Jak Jarda ztratil pivsona.";
            book1.author = "Jarda";
            book1.numberOfPages = 300;
            Console.WriteLine(book1.title);

            // With constructor, good practise.
            Magazine magazine1 = new Magazine(aTitle: "Playboy",
                                              aAuthor: "Larry",
                                              aNumberOfPages: 30);
            Console.WriteLine(magazine1.title);

            // Here it is possible to create a new instance of a class
            //  because Magazine class has also second constructor without
            //  defined paramters.
            Magazine magazine2 = new Magazine();

            // OBJECT METHODS
            ClassesStudent student1 = new ClassesStudent(aName: "Tom", aAge: 36, aId: 4590, aEthnicity: "White");
            ClassesStudent student2 = new ClassesStudent(aName: "Bob", aAge: 34, aId: 4591, aEthnicity: "skjiolk");

            Console.WriteLine($"Is older: {student1.IsAboveThirtyFive()}");
            Console.WriteLine($"Is older: {student2.IsAboveThirtyFive()}");
            Console.WriteLine();

            // GETTER
            Console.WriteLine($"Ethnicity of student1: {student1.Ethnicity}");
            Console.WriteLine($"Ethnicity of student2: {student2.Ethnicity}");

            // STATIC CLASS ATTRIBUTES
            Console.WriteLine($"Member of which shool? student1: {ClassesStudent.memberOfWhichSchool}");
            // It is not possible to access it on an instance of a class:
            // Console.WriteLine($"Member of which shool? student1: {student1.memberOfWhichSchool}");

            // STATIC CLASS METHODS
            ClassesStudent.WelcomeStudent(name: "Nixon");

            // STATIC CLASSES
            // It is not possible to create an instance of a class.
            // poster1 = Poster(); -> Not possible
            Console.WriteLine(Poster.size);

            utility.Separator();
        }
    }
}
