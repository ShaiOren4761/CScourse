using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise_Practice
{
    public class Clown : CircusEmployee
    {
        private int NumOfLaughs;

        public Clown(int ID, String name, int numOfLaughs) : base(ID, name)
        {      
            this.NumOfLaughs = numOfLaughs;
        }

        public override string ToString()
        {
            return base.ToString() + " Clown: " + NumOfLaughs;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;

            if (obj.GetType() == typeof(Clown)) // getClass equivalent - bug proof unlike "is" which might take base as true.
            {
                Clown c = (Clown)obj; // unsafe casting.
                return NumOfLaughs == c.NumOfLaughs && base.Equals(obj);
            }
            return false;
        }


        public static bool operator==(Clown c1, Clown c2){
            return c1.Equals(c2);
        }

        public static bool operator!=(Clown c1, Clown c2)
        {
            return !c1.Equals(c2);
        }
        public override int CalculateSalary()
        {
            return NumOfLaughs * 100;
        }

        public override bool ContinueToNextShow()
        {
            return NumOfLaughs > 0;
        }

        public int NUMOFLAUGHS { get { return NumOfLaughs; } set { NumOfLaughs = value; } }
    }
}
