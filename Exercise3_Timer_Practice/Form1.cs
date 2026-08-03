using System;
using System.Drawing;
using System.Windows.Forms;

namespace Exercise3_Timer_Practice
{
    public partial class Form1 : Form
    {
        int direction = 5;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (direction > 0)
            {
                if (label1.Location.X + label1.Width + direction < this.ClientRectangle.Width)
                {
                    label1.Location = new Point(label1.Location.X + direction, label1.Location.Y);
                }
                else direction *= -1;
            }
            else {
                if (label1.Location.X + direction > this.ClientRectangle.Location.X)
                {
                    label1.Location = new Point(label1.Location.X + direction, label1.Location.Y);
                }
                else direction *= -1;
            }
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            direction = -5;
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            direction = 5;
        }

        private void randomBtn_Click(object sender, EventArgs e)
        {
            label1.Location = new Point(r.Next(this.ClientRectangle.Width), r.Next(this.ClientRectangle.Height));
        }

        private void fasterBtn_Click(object sender, EventArgs e)
        {
            if (timer1.Interval > 100) timer1.Interval -= 100;
            // Can also change direction size to increase step
        }

        private void clickable_label_Click(object sender, EventArgs e)
        {
            clickable_label.Text = int.Parse(clickable_label.Text) + 1 + "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Orange;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            // can't get coords of a mouse here. Gotta get the mouseClick!!
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Text = e.Location.ToString();
        }
    }
}
