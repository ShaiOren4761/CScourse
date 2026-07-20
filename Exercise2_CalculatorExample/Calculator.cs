using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise2_CalculatorExample
{
    public partial class Calculator : Form //Partial == This is the continuation of "From" Class.
    {
        String opt;
        double num1, num2;
        public Calculator()
        {
            InitializeComponent();

            int count = 1;
        }

        // 0, 1, .. 9
        private void NumberClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            textBox1.Text += b.Text;
        }
        // Clear button C
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            num2 = double.Parse(textBox1.Text);
            switch (opt)
            {
                case "+": textBox1.Text = num1 + num2 + ""; break;
                case "-": textBox1.Text = num1 - num2 + ""; break;
                case "*": textBox1.Text = num1 * num2 + ""; break;
                case "/": textBox1.Text = num1 / num2 + ""; break;
                case "^": textBox1.Text = Math.Pow(num1,num2) + ""; break;
                case "Sin": textBox1.Text = Math.Sin(num1) + ""; break;
                case "Cos": textBox1.Text = Math.Cos(num1) + ""; break;
                case "tan": textBox1.Text = Math.Tan(num1) + ""; break;
                case "mod": textBox1.Text = num1%num2 + ""; break;
                case "sqrt": textBox1.Text = Math.Sqrt(num1) + ""; break;
                case "!": textBox1.Text ="No way I'm coding this"; break;
            }
        }

        private void Radio_Button_1_CheckedChange(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                button18.Visible = true;
                button19.Visible = true;
                button20.Visible = true;
                button21.Visible = true;
                button22.Visible = true;
                button23.Visible = true;
                button24.Visible = true;
                button25.Visible = true;
            }
            
        }
        private void Radio_Button_2_CheckedChange(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                button18.Visible = false;
                button19.Visible = false;
                button20.Visible = false;
                button21.Visible = false;
                button22.Visible = false;
                button23.Visible = false;
                button24.Visible = false;
                button25.Visible = false;
            }

        }


        // +, -, *, /
        private void OptClick(object sender, EventArgs e)
        {
            Button b = sender as Button;
            opt = b.Text;
            num1 = double.Parse(textBox1.Text);
            textBox1.Text = "";
        }
    }
}
