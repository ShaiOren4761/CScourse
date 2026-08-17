namespace Lesson6_Form_Multi_Thread_Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void myThread()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("Hello" + i++);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread t = new(myThread);
            //t.Start();
            myThread(); // Can't create a form while the thread is busy. Bam.
        }
    }
}
