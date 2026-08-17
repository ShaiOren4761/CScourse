using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_ButtonLabel_Transport_UserControl
{
    public partial class UserControl1 : UserControl
    {
        static Random myRand = new Random();
        public Control[] arrControls;
        public UserControl1(int counter, bool full)
        {
            InitializeComponent();
            arrControls = new Control[counter];
            this.Width = counter * 21 + 7;
            int colorIndex;

            if (full)
            {
                for (int i = 0; i < counter; i++)
                {
                    arrControls[i] = new Button();
                    arrControls[i].Size = new Size(20, 30);

                    colorIndex = myRand.Next(3);
                    arrControls[i].BackColor = Form1.arrColors[colorIndex];
                    arrControls[i].Text = myRand.Next(10).ToString();

                    arrControls[i].Location = new Point(2 + 21 * i, 3);
                    this.Controls.Add(arrControls[i]);
                }
            }
        }
    }
}
