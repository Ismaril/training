using MouseMover;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Fyi: Main grid and main matrix in comments are the same thing in this project.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }


}
