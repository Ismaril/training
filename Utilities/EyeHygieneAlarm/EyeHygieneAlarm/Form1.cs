using System;

namespace EyeHygieneAlarm
{
    public partial class AlarmForm : Form
    {
        private const int LENGTH_TILL_ALARM = (15*60); // 15 x 60 seconds = 15 minutes.
        private System.Windows.Forms.Timer _timer;
        private int _counter;
        private Label _label = new();
        private int _dispalyTimeFirst = (LENGTH_TILL_ALARM); 
        private int _dispalyTimeMiddle = (LENGTH_TILL_ALARM) + 2;
        private int _dispalyTimeLast = (LENGTH_TILL_ALARM) + 4;
        private int _offTime1 = (LENGTH_TILL_ALARM) + 1;
        private int _offTime2 = (LENGTH_TILL_ALARM) + 3;

        // Ctor
        public AlarmForm()
        {
            // Call all below when new instance is created.
            InitializeComponent();
            InitializeTimer();
            FatalErrorLabel();
            FormBorderStyle = FormBorderStyle.None;
            HideBlueLabeling();
        }

        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // 1000 miliseconds.
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }


        /// <summary>
        /// Tick in the speed of _timer.Interval (currently 1000ms).
        /// This means every 1second do action in function body.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            FlickerScreen();
        }

        /// <summary>
        /// Condition when the screen should disappear entirely and when
        ///     to for example signalize active alarm by flickering screen.
        /// </summary>
        private void FlickerScreen()
        {
            // Display blue screen
            if (_counter == _dispalyTimeFirst
                || _counter == _dispalyTimeMiddle
                || _counter == _dispalyTimeLast)
            {
                WindowState = FormWindowState.Maximized;
                _label.ForeColor = Color.White;
                _label.BackColor = Color.Blue;
                BackColor = Color.Blue;
            }

            // Hide whole form and create efect of slow flicker.
            // This else if block cooperates with the first if block.
            else if (_counter == _offTime1 || _counter == _offTime2)
            {
                WindowState = FormWindowState.Minimized;
            }

            else if (_counter > _dispalyTimeLast)
            {
                HideBlueLabeling();
                _counter = 0;
            }

            else if (_counter < _dispalyTimeFirst)
            {
                HideBlueLabeling();
            }
            _counter++;
        }

        /// <summary>
        /// Blue label which shows some white text in the main window.
        /// </summary>
        private void FatalErrorLabel()
        {
            _label.Text = "A fatal error has occured. To continue: \n\n" +
                "Press Enter to return to Windows, or\n\n" +
                "Press CTRL+ALT+DEL to restart your computer. If you do this,\n" +
                "you will lose any unsaved information in all open applications.\n\n" +
                "Error: OE : O16F : BLOW_IT_OUT_YOUR_ASS";
            _label.Font = new Font("Bahnschrift SemiBold", 20);
            _label.ForeColor = Color.White;
            _label.BackColor = Color.Blue;
            _label.Size = new Size(800, 800);
            _label.Location = new Point(400, 400);
            Controls.Add(_label);
        }

        /// <summary>
        /// Hide blue label by changing it's colors to the color of background.
        /// This is used not to spoil the blue screen of death till the actual
        ///     alarm time comes.
        /// </summary>
        private void HideBlueLabeling()
        {
            BackColor = Color.Black;
            WindowState = FormWindowState.Minimized;
            _label.ForeColor = Color.Black;
            _label.BackColor = Color.Black;
        }
    }
}