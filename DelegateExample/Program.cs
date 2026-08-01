namespace DelegateExample
{
    public delegate int AddDlg(int x, int y);
    public class Program
    {
        public static int add(int x, int y)
        {
            return x + y;
        }
        public static int sub(int x, int y)
        {
            return x - y;
        }
        static void Main(string[] args)
        {
            AddDlg ptr = new AddDlg(add);
            ptr += new AddDlg(sub);

            Console.WriteLine(ptr(2, 3));
            Console.WriteLine(ptr.Invoke(2, 3));

            //Delegate[]all = ptr.GetInvocationList();
            //for (int i = 0; i < all.Length; i++)
            //{
            //    Console.WriteLine(all[i].Method); // Property of a method
            //}
        }
    }
}
