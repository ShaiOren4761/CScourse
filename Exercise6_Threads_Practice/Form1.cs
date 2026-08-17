namespace Exercise6_Threads_Practice
{
    public delegate void myDel(Label myLabel, string text);

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(updateLabel);
            t1.Start(label1);
            
            Thread t2 = new Thread(updateLabel);
            t2.Start(label2);
            
            Thread t3 = new Thread(updateLabel);
            t3.Start(label3);
        }

        public void updateLabel(object o)
        {
            Label myLabel = (Label)o;
            int n = int.Parse(textBox1.Text);
            this.Invoke(new myDel(setLabelText1), myLabel, "");

            for (int i = 1; i <= n; i++)
            {
                this.Invoke(new myDel(setLabelText1), myLabel, myLabel.Text + i.ToString() + " ");
                Thread.Sleep(200);
            }

            // 26 invokes into the queue
        }
     
        void setLabelText1(Label myLabel, string text)
        {
            myLabel.Text = text;
        }
        
    }
}
