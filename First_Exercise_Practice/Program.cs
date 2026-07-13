namespace First_Exercise_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clown c = new Clown(1111, "funny", 5);
            LionTamer t = new LionTamer(2222, "rawr", 7);

            Console.WriteLine(c.ToString());
            Console.WriteLine(t.ToString());
        }
    }
}
