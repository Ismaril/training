namespace EyeHygieneAlarm
{
    partial class AlarmForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmForm));
            SuspendLayout();
            // 
            // AlarmForm
            // 
            ClientSize = new Size(1920*4, 1080*4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AlarmForm";
            Text = "EyeHygieneAlarmForm";
            ResumeLayout(false);
        }

        #endregion
    }
}