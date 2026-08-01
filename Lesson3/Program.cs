using System;

namespace Lesson3
{
    internal class Program
    {
        public static void myClickHandler(Object sender, EventArgs e)
        {
            ((Control)sender).Text = sender.GetType().BaseType.ToString() + " " + "Clicked";
        }

        
        public static void Main()
        {
            // MyForm's Constructor creates a button, our main is sooo clean.
            Application.Run(new MyForm()); // connect to the message loop - it's alive!
        }
    }
}
