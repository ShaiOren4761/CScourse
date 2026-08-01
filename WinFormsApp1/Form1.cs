namespace WinFormsApp1
{
    public partial class Form1 : Form //Form1 continues Form
    {
        private Point? prev;
        public Form1()
        {
            InitializeComponent(); // Apply the Designer file, UI creation

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = this.CreateGraphics();
                g.DrawLine(Pens.Brown, prev.Value, e.Location);
                prev = e.Location;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text + " " + textBox2.Text);
        }
    }
}
