using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace First_Exercise
{
    public class Student2 : Person
    {
        private int id;
        private string name;
        public Student2(int id, string name)
        {
            this.id = id;
            this.name = name;

        }

        public Student2(int id) : this(id, "NO NAME") { } // instant constructor with less paramters using main constructor

        public override string ToString() // Capital letter for method name! Overrides Object
        {
            return name + ", " + id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            //if (obj is Student) // instanceof equivalent

            Student s = obj as Student; // safe casting, no error throwing when incompatiable types get casted.
            if (s == null) return false;

            if (obj.GetType() == typeof(Student)) // getClass equivalent - bug proof unlike "is" which might take base as true.
            {
                s = (Student)obj; // unsafe casting.
                return s.ID == ID && s.Name == Name;

            }
            return false;
        }

        public override void show() // must override and implement because of abstract inheritence
        {
            Console.WriteLine("(show) Student name: " + this.name + " id: " + this.id);
        }

        public int ID { get { return id; } set { id = value; } } // this ain't no class variable. This is a property!
        public string Name { get { return name; } set { name = value; } } // no ; at the end of the definition huh


    }
}
