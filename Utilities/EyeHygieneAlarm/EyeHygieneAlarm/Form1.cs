using System;
using System.Drawing.Configuration;

namespace EyeHygieneAlarm
{
    public partial class AlarmForm : Form
    {
        private int _counter;
        private System.Windows.Forms.Timer _timer;

        private readonly Label _label = new();
        private readonly Color _backgroundColorFormVisible;
        private readonly Color _foregroundColor = Color.White;
        private readonly Color _backgroundColorFormHidden = Color.Black;

        private int _dispalyTimeFirst;
        private int _dispalyTimeMiddle;
        private int _dispalyTimeLast;

        private int _offTime1;
        private int _offTime2;

        /// <summary>
        /// Ctor of the AlarmForm class.
        /// </summary>
        /// <param name="timeTillAlarm">Time till alarms pops up. Currently 900s = 15min</param>
        /// <param name="backgroundColor">Background color. Supported "r" "g" "b" only</param>
        public AlarmForm(int timeTillAlarm = 900, string backgroundColor = "b")
        {
            _backgroundColorFormVisible = ResolveBackgroundColor(backgroundColor);

            InitializeComponent();
            InitializeTimer();
            SetDisplayTimes(timeTillAlarm);
            FatalErrorLabel();
            FormBorderStyle = FormBorderStyle.None;
            HideForm();
        }

        /// <summary>
        /// Set the background color of the form.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private static Color ResolveBackgroundColor(string backgroundColor)
        {
            return backgroundColor switch
            {
                "r" => Color.Red,
                "g" => Color.Green,
                _ => Color.Blue,
            };
        }

        /// <summary>
        /// Set the times when the screen should flicker.
        /// </summary>
        /// <param name="lengthTillAlarm"></param>
        private void SetDisplayTimes(int lengthTillAlarm)
        {
            _dispalyTimeFirst = lengthTillAlarm;
            _dispalyTimeMiddle = lengthTillAlarm + 2;
            _dispalyTimeLast = lengthTillAlarm + 4;

            _offTime1 = lengthTillAlarm + 1;
            _offTime2 = lengthTillAlarm + 3;
        }

        /// <summary>
        /// Initialize the timer.
        /// </summary>
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
            // Display alarm screen
            if (_counter == _dispalyTimeFirst || _counter == _dispalyTimeMiddle || _counter == _dispalyTimeLast)
            {
                ShowForm();
            }

            // Hide whole form and create efect of slow flicker.
            // This else if block cooperates with the first if block.
            else if (_counter == _offTime1 || _counter == _offTime2)
            {
                HideForm();
            }

            else if (_counter > _dispalyTimeLast)
            {
                HideForm();
                _counter = 0;
            }

            else if (_counter < _dispalyTimeFirst)
            {
                HideForm();
            }
            _counter++;
        }

        /// <summary>
        /// A label which shows some white text in the main window.
        /// </summary>
        private void FatalErrorLabel()
        {
            _label.Text = "A fatal error has occured. To continue: \n\n" +
                "Press Enter to return to Windows, or\n\n" +
                "Press CTRL+ALT+DEL to restart your computer. If you do this,\n" +
                "you will lose any unsaved information in all open applications.\n\n" +
                "Error: OE : O16F : BLOW_IT_OUT_YOUR_ASS";
            _label.Font = new Font("Bahnschrift SemiBold", 20);
            _label.ForeColor = _foregroundColor;
            _label.BackColor = _backgroundColorFormVisible;
            _label.Size = new Size(1920, 1080);
            _label.Location = new Point(400, 400);
            Controls.Add(_label);
        }

        /// <summary>
        /// Hide the form by changing it's colors to the color of black.
        /// This is used not to spoil the alarm screen till the actual alarm time comes.
        /// </summary>
        private void HideForm()
        {
            WindowState = FormWindowState.Minimized;
            _label.ForeColor = _backgroundColorFormHidden;
            _label.BackColor = _backgroundColorFormHidden; // Background color of the label.
            BackColor = _backgroundColorFormHidden; // Background color of the form.
        }

        /// <summary>
        /// Show the form and give it main focus.
        /// </summary>
        private void ShowForm()
        {
            WindowState = FormWindowState.Maximized;
            _label.ForeColor = _foregroundColor;
            _label.BackColor = _backgroundColorFormVisible; // Background color of the label.
            BackColor = _backgroundColorFormVisible; // Background color of the form.
        }
    }
}