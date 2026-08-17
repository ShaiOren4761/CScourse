namespace Exercise5_UserControl_Practice
{

    public delegate void myDel(object sender, MyEventArgs e);
    public class MyEventArgs : EventArgs
    {
        public Control cnt;
        public int min;
        public int max;

        public MyEventArgs(Control cnt) 
        {
            this.cnt = cnt;
        }

        public MyEventArgs(int min, int max)
        {
            this.max = max;
            this.min = min;
        }
    }
}
