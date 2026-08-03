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
    public partial class MdiForm : Form
    {
        public MdiForm()
        {
            InitializeComponent();
            this.Width = 0;

            ChildForm f1 = new ChildForm();
            f1.MdiParent = this;
            this.Width += f1.Width;

            ChildForm f2 = new ChildForm();
            f2.MdiParent = this;
            this.Width += f2.Width;
            
            f1.Show();
            f2.Show();

        }

        private void MdiForm_Load(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
