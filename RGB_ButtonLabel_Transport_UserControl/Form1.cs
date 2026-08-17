using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace RGB_ButtonLabel_Transport_UserControl
{
    public delegate void myAddDelegate(UserControl1 UC_To, int counter_To, UserControl1 UC_From, int index_From);
    public delegate void myRemoveDelegate(UserControl1 UC, int i);

    public partial class Form1 : Form
    {
        private UserControl1 ucSource;
        private UserControl1[] ucDestination = new UserControl1[3];

        private const int N = 55;
        public static Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };
        private Thread[] arrThreads = new Thread[3];
        private int[] arrPositionDestination = new int[3];

        public Form1()
        {
            InitializeComponent();

            ucSource = new UserControl1(N, true);
            ucSource.Location = new Point(2, 40);
            Controls.Add(ucSource);
            
            for (int i = 0; i < 3; i++)
            {
                ucDestination[i] = new UserControl1(N, false);
                ucDestination[i].Location = new Point(2, 215 + 60 * i);
                this.Controls.Add(ucDestination[i]);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                arrThreads[i] = new Thread(ToDestinationSorted);
                arrThreads[i].Start(i);
            }
        }

        private void ToDestination(object o)
        {
            int indexColor = (int)o;
            int destIndex = 0;
            for (int i=0; i<ucSource.arrControls.Length; i++)
            {
                Control tmp = ucSource.arrControls[i];
                if (tmp == null) continue;
                if (tmp.BackColor == arrColors[indexColor])
                {
                    this.Invoke(new myAddDelegate(Add), ucDestination[indexColor], destIndex++, ucSource, i);
                    this.Invoke(new myRemoveDelegate(Remove), ucSource, i);
                    Thread.Sleep(200);
                }
            }
        }

        private void ToDestinationSorted(object o)
        {
            int indexColor = (int)o;
            int destIndex = 0;

            while (true)
            {
                int i = findMin(indexColor);
                if (i < 0) break;

                this.Invoke(new myAddDelegate(Add), ucDestination[indexColor], destIndex++, ucSource, i);
                this.Invoke(new myRemoveDelegate(Remove), ucSource, i);
                Thread.Sleep(100);
            }
        }

        private int findMin(int indexColor)
        {
            int minIndex = -1;
            int minValue = 1000;

            for (int i = 0; i < ucSource.arrControls.Length; i++)
            {
                Control tmp = ucSource.arrControls[i];
                if (tmp == null) continue;
                if (tmp.BackColor == arrColors[indexColor])
                {
                    if (int.Parse(tmp.Text) < minValue)
                    {
                        minValue = int.Parse(tmp.Text);
                        minIndex = i;
                    }
                }
            }

            return minIndex;
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
