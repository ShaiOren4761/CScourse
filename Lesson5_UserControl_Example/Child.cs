namespace Lesson5_UserControl_Example
{
    public delegate void LoginReadyDlg(Object sender, ChildEventArgs e);

    public partial class Child : Form
    {
        public event LoginReadyDlg logD; // not the same as LoginCtrl's! But same purpose. Climb hierarchy
        private int no; //id for the child
        public Child(int no)
        {
            InitializeComponent();
            // this doesn't work
            // loginCtrl1.textbox1
            // Form1 does not have access to private Controls of LoginCtrl
            // Let's define properties! Now we can edit them in the Designer even.

            loginCtrl1.loginD += new LoginDlg(myFunc);
            this.no = no;
        }
        public void myFunc(object sender, MyEventArgs e)
        {
            if (logD != null) logD(this, new ChildEventArgs(e.Username, e.Password, this.no));
        }

        public int No { get { return no; } }
    }
}
