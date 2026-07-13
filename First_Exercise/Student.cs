using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace First_Exercise
{
    public class Student : Human
    {
        private int id;
        private string name;
        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
            
        }

        public Student(int id) : this(id, "NO NAME") {} // instant constructor with less paramters using main constructor

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
                return s.ID == ID && s.name == name;
         
            }
            return false;
        }

        public void print()
        {
            Console.WriteLine("Student name: "+this.name + " id: " + this.id);
        }

        public static Student operator+(Student a, Student b)
        { // has to be static because original operator implementation
            return new Student(a.id + b.id, a.name + "_" + b.name);
        }

        public static Student operator--(Student a)
        { // has to be static because original operator implementation
            return new Student(a.id--, a.name);
        }


        public int ID { get { return id; } set { id = value; } } // this ain't no class variable. This is a property!
        public string Name { get { return name; } set { name = value; } } // no ; at the end of the definition huh

        
    }
}
