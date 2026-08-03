using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3_Dynamic_Button_Creation
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<Button> movingButtons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Text = label_Counter.Text;
            if (radiobutton_red.Checked)
            {
                b.BackColor = Color.Red;
            }
            else b.BackColor = Color.Blue;

            b.Location = new Point(r.Next(this.ClientRectangle.Width), r.Next(this.ClientRectangle.Height));
            this.Controls.Add(b);

            if (checkBox_moveCopy.Checked)
            {
                movingButtons.Add(b);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Counter.Text = int.Parse(label_Counter.Text) + 1 + "";
            foreach (Button b in movingButtons)
            {
                b.Left += 5; // Instead of b.Location.X
            }
        }
    }
}
