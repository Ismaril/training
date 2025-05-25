using System.Runtime.InteropServices;

namespace MouseMover
{
    ///----------------------------------------------------------------------------------------------------------------
    ///<inheritdoc/>
    public partial class Form1 : Form
    {
        // OPERATE HERE -----------------------------------------------------------------------------------------------
        static readonly bool ExecuteForever = true;
        // ------------------------------------------------------------------------------------------------------------
        static readonly int TimerTillExitProgramMinutes = 1; // Will not be used if ExecuteForever is true.
        static readonly bool HibernatePC = true; // Will not hibernate if ExecuteForever is true.
        static readonly int HowLongBeforeCursorMovesSeconds = 5;
        // ------------------------------------------------------------------------------------------------------------
        
        const int MILISECONDS_IN_SECOND = 1000;
        const int SECONDS_IN_MINUTE = 60;
        readonly System.Windows.Forms.Timer _timer = new();
        int _counterSeconds = 0;
        readonly int _timerTillExitSeconds = SECONDS_IN_MINUTE * TimerTillExitProgramMinutes;
        readonly int _tickInterval = HowLongBeforeCursorMovesSeconds * MILISECONDS_IN_SECOND;

        bool _isProgramRunning = true;
        bool _hibernated = false; // Flag to check if the PC has been hibernated

        const string ROOT_PATH = @"..\..\..\";
        readonly Icon _redicon = new($"{ROOT_PATH}red.ico");
        readonly Icon _greenicon = new($"{ROOT_PATH}green.ico");
        private Label _timeLabel;

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Set the window to the foreground, at the first position, when pressing ALT+TAB.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        //-------------------------------------------------------------------------------------------------------------
        /// <inheritdoc />
        public Form1()
        {
            InitializeComponent();
            // Bring the window to the foreground
            SetForegroundWindow(this.Handle);
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// What to do when the Form is loaded for the first time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyDown += KeyArrowsDown;
            _timer.Interval = _tickInterval;
            _timer.Tick += TimerTick;
            PrepareInfoWidget();
            _timer.Start();
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Prepare the info widget that will show the time passed and hibernate status.
        /// </summary>
        private void PrepareInfoWidget()
        {
            _timeLabel = new Label
            {
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
            };
            this.Controls.Add(_timeLabel);
            this.ForeColor = Color.White;
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Display the program status in the Form. This includes the time passed and hibernate status.
        /// </summary>
        private void DisplayProgramStatus()
        {
            if (!ExecuteForever)
            {
                int remainingMinutes = (_timerTillExitSeconds - _counterSeconds) / SECONDS_IN_MINUTE;
                int TotalProgramDurationMinutes = _timerTillExitSeconds / SECONDS_IN_MINUTE;
                this.Controls[0].Text = $"Time left: {remainingMinutes} out of {TotalProgramDurationMinutes} " +
                    $"minutes\n" +
                    $"Hibernate: {HibernatePC}\n";
            }
            else
            {
                this.Controls[0].Text = "Executing forever";
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// KeyDown event handler to handle key presses. Meaning, what happens when a certain key is pressed
        /// at keyboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyArrowsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                ChangeWindowsTaskBarIcon();
                WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TerminateApplication(flag: true);
            }
            else if (e.KeyCode == Keys.F1)
            {
                // Show a message box with instructions
                MessageBox.Show("Press P to pause or resume, ESC to exit.");
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Change the icon at the taskbar when the program is running or paused.
        /// </summary>
        private void ChangeWindowsTaskBarIcon()
        {
            if (_isProgramRunning)
            {
                _timer.Stop();
                this.Icon = _redicon;
                _isProgramRunning = false;
            }
            else
            {
                _timer.Start();
                this.Icon = _greenicon;
                _isProgramRunning = true;
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer tick event handler. This method is called every tick of the timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            MoveCursor();
            DisplayProgramStatus();
            HibernatePC_();
            TerminateApplication(flag: _hibernated);
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Move the mouse cursor to a random position on the screen.
        /// </summary>
        private void MoveCursor()
        {
            if (_counterSeconds < _timerTillExitSeconds || ExecuteForever)
            {
                Random random = new();
                int x = random.Next(0, Screen.PrimaryScreen.Bounds.Width);
                int y = random.Next(0, Screen.PrimaryScreen.Bounds.Height);
                Cursor.Position = new Point(x, y);
                if (!ExecuteForever)
                    _counterSeconds += HowLongBeforeCursorMovesSeconds;
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Hinernate the PC if the flags are set. 
        /// </summary>
        /// <remarks>
        /// IMPORTANT! - If you gonna ever adjust this method, always make sure that an application is terminated
        /// after hibernation command. Since the hibernate method is called every tick, you could
        /// end up with hibernation everytime you start the computer and want to login into your account.
        /// </remarks>
        private void HibernatePC_()
        {
            // Hibernate the PC if the flag is set. No timer, hibernate immediately.
            if (HibernatePC
                && !ExecuteForever
                && _counterSeconds >= _timerTillExitSeconds
                && !_hibernated)
            {
                _hibernated = true;
                System.Diagnostics.Process.Start("shutdown", "/h");
            }
        }

        ///------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Terminate the application if the flag is set.
        /// </summary>
        private void TerminateApplication(bool flag)
        {
            if (flag)
            {
                // Write a log to a txt file that application exited
                File.AppendAllText($"{ROOT_PATH}log.txt", $"Application exited at {DateTime.Now}\n");
                Application.Exit();
            }
        }
    }
}
