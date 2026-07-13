using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
    public class Human
    {
        public virtual void print() // virtual --> dynamic. Can be overriden.
        {
            Console.WriteLine("Human");
        }
    }
}
