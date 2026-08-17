namespace Lesson6_Multi_Threading_Example
{
    internal class Program
    {
        public static int d = 0; // He is not safe. All threads push his value up.
        public static void f(object o)
        {
            int c = 0;
            while (true)
            {
                Console.Write(" "+(o as string) +"(" +c++ +"," + d++ +")");
            }
        }
        public static void g(object o)
        {
            while (true)
            {
                Console.WriteLine(o as string);
            }
        }

        static void Main(string[] args)
        {
            /*
            ParameterizedThreadStart d1 = new ParameterizedThreadStart(f); // Accepts void functions only 
            ParameterizedThreadStart d2 = new ParameterizedThreadStart(g);
            
            Thread tf = new Thread(d1); // Add functions to a Thread
            Thread tg = new Thread(d1);

            //Thread tf = new Thread(f) //Also works, just creates a Delete in the constructor
            //Thread tf = new(f) also also works, type is inferred!
            tf.Start("F"); // Start the thread.
            tg.Start("G"); // Doesn't actually run the method.. it takes it and places it in the thread list.


            while (true)
            {
                Console.WriteLine("Main");
            }
            */
            ParameterizedThreadStart d1 = new ParameterizedThreadStart(f); // Accepts void functions only 

            for (int i = 0; i<20; i++)
            {
                new Thread(d1).Start((char)(i + 65) + "");
            }

            throw new Exception(); // Just to see output..
        }
    }
}
