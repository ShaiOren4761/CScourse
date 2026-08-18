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
        public delegate void myAddDelegate(UserControl1 UC_To, int counter_To, UserControl1 UC_From, int index_From);
        public delegate void myRemoveDelegate(UserControl1 UC, int i);

        private UserControl1[] arrUC_From = new UserControl1[2],
            arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private const int N = 55;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };

        Thread[] arrThreads = new Thread[3];
        Thread[] arrTransThreads = new Thread[3];

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
            for(int i=0; i<3; i++)
            {
                arrThreads[i] = new Thread(ToTransport);
                arrTransThreads[i] = new Thread(fromTransport);
                arrThreads[i].Start(i);
                arrTransThreads[i].Start(i);
            }
        }

        private void ToTransport(Object o)
        {
            int indexColor = (int)o;
            int transportCount = 0;

            for (int i=0; i< arrUC_From.Length; i++)
            {
                for (int j=0; j < arrUC_From[i].arrControls.Length; j++)
                {
                    Control tmp = arrUC_From[i].arrControls[j];
                    if (tmp == null) continue;
                    if((tmp.BackColor.R > 0 && indexColor==0) || (tmp.BackColor.G > 0 && indexColor == 1) || (tmp.BackColor.B > 0 && indexColor == 2))
                    {
                        this.Invoke(new myAddDelegate(Add), arrUC_Transport[indexColor], transportCount++, arrUC_From[i], j);
                        this.Invoke(new myRemoveDelegate(Remove), arrUC_From[i], j);
                        Thread.Sleep(300);

                        if (transportCount == 5) Thread.Sleep(1000000000); // We haven't learned monitors yet..
                    }
                }
            }
        }

        private void fromTransport(object o)
        {
            int indexColor = (int)o;
            int destCounter = 0;
            Thread.Sleep(11000);
            for(int i=0; i<5; i++)
            {
                Control temp = arrUC_Transport[indexColor].arrControls[i];
                this.Invoke(new myAddDelegate(Add), arrUC_To[indexColor], destCounter++, arrUC_Transport[indexColor], i);
                this.Invoke(new myRemoveDelegate(Remove), arrUC_Transport[indexColor], i);
                Thread.Sleep(300);
            }

        }

        private void Add(UserControl1 UC_To, int counter_To, UserControl1 UC_From, int index_From)
        {
            UC_To.arrControls[counter_To] = UC_From.arrControls[index_From];
            UC_To.Controls.Add(UC_From.arrControls[index_From]);
            UC_To.arrControls[counter_To].Location = new Point(2 + 21 * counter_To, 3);
        }

        private void Remove(UserControl1 UC, int index)
        {
            UC.Controls.Remove(UC.arrControls[index]);
            UC.arrControls[index] = null;
        }
    }
}
