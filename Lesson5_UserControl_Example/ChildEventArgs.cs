using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5_UserControl_Example
{
    public class ChildEventArgs : MyEventArgs
    {
        private int child;
        public ChildEventArgs(string username, string password, int child) : base(username, password)
        {
            this.child = child;
        }
        public int Child
        {
            get { return child; }
            set { child = value; }
        }
    }
}
