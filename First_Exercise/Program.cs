using System.Security.Cryptography;

namespace First_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new int[4] { 3, 4, 5, 6 };

            //int[,] m = new int[3, 4] { { 1, 2, 3, 4 }, { 2, 2, 3, 4 }, { 1, 2, 3, 8 } };

            //int[][] m2 = new int[2][]; // pointer array! - we can do jagged arrays
            //m2[0] = new int[4] { 1, 2, 3, 4 };
            //m2[1] = new int[2] { 1, 2 };


            //for (int i=0; i<A.Length; i++)
            //{
            //    Console.WriteLine(A[i]);
            //}

            //Array.Sort(A);
            //foreach (int x in A)
            //{
            //    Console.WriteLine(x);
            //}

            //// print 2D array - gotta get the length of each dimension

            //for(int i = 0; i < m.GetLength(0); i++)
            //{
            //    for(int j=0; j<m.GetLength(1); j++)
            //    {
            //        Console.WriteLine(m[i, j]);
            //    }
            //}

            //foreach(int x in m) //no need for a double loop
            //{
            //    Console.WriteLine(x);
            //}

            //List<int> list = new List<int>(); // or BigInteger
            //list.Add(3);
            //list.Add(6);
            //list.Add(1);
            //list.Sort();

            //foreach(int x in list){
            //    Console.WriteLine(x);
            //}


            //list.Sort((x, y) => y - x); //Define your own compare! Lambda expression
            //// the cmp function will receive x,y and will do (Arrow) y-x to compare, despite x-y being the default.
            //// y-x > 0 ; y is bigger, but x will be moved.



            //Student s = new Student(11111);
            //Console.WriteLine(s.ID); // no need for s.getID etc, we just s.ID as the get is implemented in the property.

            //List<Student> students = new List<Student>();
            //students.Add(new Student(1111, "aaaaaa"));
            //students.Add(new Student(8888, "bbbbbb"));
            //students.Add(new Student(2222, "ccccccaaa"));
            //students.Add(new Student(4444, "dadaaaaa"));
            //students.Sort((x, y) => x.ID - y.ID); // lambda expression, cmp function that is sent to be used in sort
            //students.Sort((x, y) => x.Name.Length - y.Name.Length); // by name length
            //students.Sort((x, y) => x.Name.CompareTo(y.Name));
            //foreach (Student x in students)
            //{
            //    Console.WriteLine(x);
            //}

            //Console.ReadKey(); // prevent output from closing before you can read..


            Student s1 = new Student(1111);
            //s2.print();

            Student s2 = new Student(1111);
            //s2.print();

            Human h = new Student(2222);
            //h.print();

            Student2 s3 = new Student2(1212);
            //s3.show();

            Student s4 = s1 + s2; // let's override the operator '+' to make this work!
            s4--;

            Student s5 = s1 + s2 + s4;

        }
    }
}
