using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace First_Exercise_Practice
{
    public class LionTamer : CircusEmployee
    {
        private int NumOfLions;

        public LionTamer(int ID, String name, int numOfLaughs) : base(ID, name)
        {
            this.NumOfLions = numOfLaughs;
        }

        public override string ToString()
        {
            return base.ToString() + " LionTamer: " + NumOfLions;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;

            if (obj.GetType() == typeof(LionTamer)) // getClass equivalent - bug proof unlike "is" which might take base as true.
            {
                LionTamer l = (LionTamer)obj; // unsafe casting.
                return NumOfLions == l.NUMOFLIONS && base.Equals(obj); // implement base equals..
            }
            return false;
        }
        public static bool operator==(LionTamer lt1, LionTamer lt2)
        {
            return lt1.Equals(lt2);
        }

        public static bool operator!=(LionTamer lt1, LionTamer lt2)
        {
            return !lt1.Equals(lt2);
        }
        public override int CalculateSalary()
        {
            return NumOfLions * 180;
        }

        public override bool ContinueToNextShow()
        {
            return NumOfLions > 3;
        }

        public int NUMOFLIONS { get { return NumOfLions; } set { NumOfLions = value; } }
    }
}
