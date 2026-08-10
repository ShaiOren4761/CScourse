using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson5_UserControl_Example
{
    public delegate void LoginDlg(object sender, MyEventArgs e); // Holds functions without parameters

    public partial class LoginCtrl : UserControl
    {
        public event LoginDlg loginD;

        public LoginCtrl()
        {
            InitializeComponent();
            this.button1.Click += new EventHandler(UCFunc);
        }

        public string Username // reveal username to Form1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string Password
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public void UCFunc(object sender, EventArgs e)
        {
            if (loginD != null) loginD(this, new MyEventArgs(Username, Password));
        }
    }
}
