
namespace Exercise5_UserControl_Practice
{
    public partial class UserControl1 : UserControl
    {
        Control[] arrLabels = new Control[10];

        public myDel ucDelegate; // Allow other Forms to subscribe to get events
        public myDel ucDelegate2;

        public UserControl1()
        {
            Random rnd = new Random();
            InitializeComponent();

            int pos = 0;
            this.Width = 0;
            for (int i = 0; i < arrLabels.Length; i++)
            {
                if (rnd.Next(2) == 0) arrLabels[i] = new Label();
                else arrLabels[i] = new Button();

                arrLabels[i].Text = rnd.Next(1, 100).ToString();
                arrLabels[i].BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                arrLabels[i].Size = new Size(100, 100); // Instead of Width and Length
                arrLabels[i].Location = new Point(pos, 10);
                arrLabels[i].Click += commonClick;
                pos += arrLabels[i].Width + 2;
                this.Controls.Add(arrLabels[i]);
                this.Width += arrLabels[i].Width + 2;
            }
        }

        private void commonClick(object sender, EventArgs e)
        {
            MyEventArgs ee = new MyEventArgs(sender as Control);

            if (ucDelegate != null) ucDelegate(this, ee);
        }

        private void UserControl1_Click(object sender, EventArgs e)
        {
            int min = 101;
            int max = -1;

            foreach (Control c in this.Controls)
            {
                if (int.Parse(c.Text) < min)
                {
                    min = int.Parse(c.Text);
                }
                if (int.Parse(c.Text) > max)
                {
                    max = int.Parse(c.Text);
                }
            }

            MyEventArgs ee = new MyEventArgs(min, max);
            if (ucDelegate2 != null) ucDelegate2(this, ee);
        }
    }
}
