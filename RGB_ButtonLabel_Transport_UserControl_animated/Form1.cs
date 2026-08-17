using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace RGB_ButtonLabel_Transport_UserControl
{
  

    public partial class Form1 : Form
    {
        private UserControl1[] arrUC_From = new UserControl1[2],
            arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private const int N = 55;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };


        public Form1()
        {
            InitializeComponent();

            arrUC_From[0] = new UserControl1(N, "Full", "Button");
            arrUC_From[1] = new UserControl1(N, "Full", "Label");
            for (int i = 0; i < 2; i++)
            {
                arrUC_From[i].Location = new Point(2, 40 + 55 * i);
                this.Controls.Add(arrUC_From[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                arrUC_Transport[i] = new UserControl1(5, "Empty", "");
                arrUC_Transport[i].Location = new Point(2 + 135 * i, 155);
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(N, "Empty", "");
                arrUC_To[i].Location = new Point(2, 215 + 55 * i);
                this.Controls.Add(arrUC_To[i]);

  
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
        }

      

    }
}
