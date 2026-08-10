namespace Lesson5_UserControl_Example
{
    partial class Child
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
            loginCtrl1 = new LoginCtrl();
            SuspendLayout();
            // 
            // loginCtrl1
            // 
            loginCtrl1.BackColor = SystemColors.Info;
            loginCtrl1.Location = new Point(22, 26);
            loginCtrl1.Name = "loginCtrl1";
            loginCtrl1.Password = "enter your password";
            loginCtrl1.Size = new Size(302, 211);
            loginCtrl1.TabIndex = 0;
            loginCtrl1.Username = "enter your username";
            loginCtrl1.UseWaitCursor = true;
            // 
            // Child
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 257);
            Controls.Add(loginCtrl1);
            Name = "Child";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private LoginCtrl loginCtrl1;
    }
}
