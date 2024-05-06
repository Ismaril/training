using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

class Program
{
    [DllImport("user32.dll")]
    static extern void SetCursorPos(int x, int y);

    static void Main()
    {
        Random random = new Random();
        while (true)
        {
            SetCursorPos(random.Next(0, 1920), random.Next(0, 1080));
            Thread.Sleep(10_000);
        }
    }
}
