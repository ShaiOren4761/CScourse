namespace Exercise5_UserControl_Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UserControl1 uc1 = new UserControl1();
            UserControl1 uc2 = new UserControl1();

            uc1.ucDelegate += fromUC;
            uc2.ucDelegate += fromUC;

            uc1.ucDelegate2 += fromUC2;
            uc2.ucDelegate2 += fromUC2;

            uc1.Location = new Point(10, 10);
            uc2.Location = new Point(10, uc1.Height+30);

            this.Controls.Add(uc1);
            this.Controls.Add(uc2);
        }

        public void fromUC(object sender, MyEventArgs e)
        {
            label1.Text = e.cnt.Text + " - " + e.cnt.GetType().Name;
            label1.BackColor = e.cnt.BackColor;
            
        }

        public void fromUC2(object sender, MyEventArgs e)
        {
            label1.Text = e.max.ToString();
            label2.Text = e.min.ToString();
        }
    }
}
