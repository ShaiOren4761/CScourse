using System;
using System.Windows.Forms;

public class Program
{
    public static void g(Object o, EventArgs e)
    {
        MessageBox.Show("Hello");
    }
    public static void Main()
    {
        Form f = new Form();
        Button b = new Button();
        b.Text = "Hello";
        f.Controls.Add(b); // f now contains a button thanks to the property "Controls" that has a function to add it.
        b.Click += new EventHandler(g);
        Application.Run(f);
    }
}