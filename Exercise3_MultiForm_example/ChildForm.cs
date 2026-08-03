using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3_MultiForm_example
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            Random r = new Random();
            InitializeComponent();
            int x=5, y=5;
            for (int i=0; i<10; i++)
            {
                Label myLabel = new Label();
                myLabel.Text = i.ToString();
                myLabel.Location = new Point(x, y);
                myLabel.BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                myLabel.Width -= 50;
                myLabel.Click += myLabelClick;
                x += myLabel.Width + 5;
                this.Controls.Add(myLabel);
            }
        }

        private void myLabelClick(object sender, EventArgs e)
        {
            this.MdiParent.Text = (sender as Label).Text;
            foreach(ChildForm child in this.MdiParent.MdiChildren)
            {
                if (!ReferenceEquals(child, this))
                {
                    child.label1.Text = (sender as Label).Text;
                }
            }
        }
    }
}
