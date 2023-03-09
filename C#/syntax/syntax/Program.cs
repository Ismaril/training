using syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_
{
    internal class Program
    {
        // Looks like there can be only one Main function in complete project.
        // Check if I am right.
        static void Main(string[] args)
        {
            // Automatically format a document in visual studio.
            // CTRL+K then press CTRL+D (no caps lock needed)

            DataTypes.Main__();
            Variables.Main__();
            Strings.Main__();
            Numbers.Main__();
            Arrays.Main__();
            Functions.Main__();
            // UserInput.Main__();
            Conditions.Main__();
            Switch.Main__();
            Loops.Main__();
            Exceptions.Main__();
            Classes.Main__();   


            // ------------------------------------------------------------------------
            // Without this line console window would just immediatelly close,
            //  after we executed the code.
            // It actually waits for user input, but when you just hit enter. The
            // program will terminate, if there is no other code, which follows this.
            Console.ReadLine();

        }



    }
}
