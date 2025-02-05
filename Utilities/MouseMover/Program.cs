using System.Diagnostics;
using System.Runtime.InteropServices;

class Program
{
    // OPERATE HERE ---------------------------------------------------------------------------------------
    static readonly bool ExecuteForever = true;
    static readonly bool HibernatePC = false; // Will not hibernate if ExecuteForever is true.
    static readonly int TimerTillExitProgramMinutes = 10; // Will not be used if ExecuteForever is true.
    static readonly int HowLongBeforeCursorMovesSeconds = 10;
    // ----------------------------------------------------------------------------------------------------

    [DllImport("user32.dll")]
    static extern void SetCursorPos(int x, int y);

    static void Main()
    {
        const int MILISECONDS_IN_SECOND = 1000;
        const int SECONDS_IN_MINUTE = 60;

        const int SCREEN_WIDTH = 1920;
        const int SCREEN_HEIGHT = 1080;

        Random random = new();
        int timerTillExitSeconds = SECONDS_IN_MINUTE * TimerTillExitProgramMinutes;
        int counterSeconds = 0;

        while (counterSeconds < timerTillExitSeconds || ExecuteForever)
        {
            SetCursorPos(random.Next(0, SCREEN_WIDTH), random.Next(0, SCREEN_HEIGHT));
            if (!ExecuteForever)
                counterSeconds += HowLongBeforeCursorMovesSeconds;
            Thread.Sleep(HowLongBeforeCursorMovesSeconds * MILISECONDS_IN_SECOND);
        }

        // Hibernate the PC if the flag is set. No timer, hibernate immediately.
        if (HibernatePC)
            Process.Start("shutdown", "/h");
    }
}
