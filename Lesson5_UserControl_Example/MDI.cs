namespace Lesson5_UserControl_Example
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
            for (int i = 1; i <= 2; i++)
            {
                Child c = new Child(i);
                c.MdiParent = this;
                c.Show();
                c.logD += new LoginReadyDlg(mdiFunc);
            }
        }

        public void mdiFunc(object sender, ChildEventArgs e)
        {
            this.Text = e.Child + " : " + e.Username + " : " + e.Password;
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
