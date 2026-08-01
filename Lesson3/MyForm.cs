using System;

namespace Lesson3
{
    internal class MyForm : Form
    {
        private Button b;
        Random r = new Random();
        public MyForm()
        {
            this.Click += new EventHandler(myClickHandler);
            int x = 10, y = 0;
            for (int i = 0; i < 15; i++)
            {
                Button b = new Button();
                b.Text = (i+1).ToString();
                if (i % 3 == 0)
                {
                    x = 10;
                    y += b.Height + 5;
                }
                b.Location = new Point(x, y);
                x += b.Width + 5;
                b.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                b.ForeColor = Color.FromArgb(0, 0, 0);
                b.Click += new EventHandler(myClickHandler);
                this.Controls.Add(b); //this == Our form!!
            }
        }

        public void myClickHandler(Object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                MessageBox.Show(((Button)sender).Text + " " + "Clicked!");
            }
        }
    }


}
