using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_UserControl_Example
{
    public class MyEventArgs : EventArgs
    {
        private String username;
        private String password;
        private int child;

        public MyEventArgs(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get { return username; }
        }
        public string Password
        {
            get { return password; }
        }

        public int Child
        {
            get { return child; }
            set { child = value; }
        }
    }
}
