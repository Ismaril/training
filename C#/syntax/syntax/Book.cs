using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
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

        // You can also make two or more constructors at the same time.
        // Since there are no paramteres specified, you can create a new
        //  instance of a class without anything in the brackets.
        public Magazine()
        {
        }
    }

    // STATIC CLASS
    // It will not be possible to create an instance of this class.
    // Static class cannot inherit from other classes.
    internal static class Poster
    {
        public static int size = 10;
    }
}
