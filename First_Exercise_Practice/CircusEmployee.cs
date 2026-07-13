using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace First_Exercise_Practice
{
    public abstract class CircusEmployee
    {
        private int id;
        private String name;

        public CircusEmployee(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public abstract int CalculateSalary();
        public abstract bool ContinueToNextShow();

        public override String ToString()
        {
            return "id: " + id + ", " + "name: " + name;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;

            if (obj.GetType() == typeof(CircusEmployee)) // getClass equivalent - bug proof unlike "is" which might take base as true.
            {
                Clown c = (Clown)obj; // unsafe casting.
                return this.ID == c.ID && this.Name.Equals(c.Name);
            }
            return false;
        }

        public int ID { get { return id; } set { id = value; } }
        public String Name { get{return name;} set { name = value; } }
        

    }
}
