using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeAssignment1_Example
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        public Form1()
        {
            InitializeComponent();
            Random rnd = new Random();
            int count = 1;
            for(int i = 0; i < buttons.GetLength(0); i++)
            {
                for(int j=0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Text += count++;
                    buttons[i, j].Width = 100;
                    buttons[i, j].Height = 100;
                    buttons[i, j].Location = new Point(5 + (100) * i, 5 + (100) * j); // grid magic
                    buttons[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    buttons[i, j].BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    buttons[i, j].Click += btClick; // Click is a delegate!
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void btClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            Random rnd = new Random();
            b.Text = rnd.Next(100) + "";
        }
    }
}
