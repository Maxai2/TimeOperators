using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------
namespace TimeOperators
{
    class Time
    {
        int hour;
        int minuete;
        int second;

        public Time(int hour, int minuete, int second)
        {
            if (hour < 24)
                this.hour = hour;
            else
                this.hour = 0;

            if (minuete < 60)
                this.minuete = minuete;
            else
                this.minuete = 0;

            if (second < 60)
                this.second = second;
            else
                this.second = 0;
        }

        public static bool operator >(Time TLeft, Time TRight)
        {
            if (TLeft.hour > TRight.hour)
                return true;
            else
            if (TLeft.minuete > TRight.minuete)
                return true;
            else
            if (TLeft.second > TRight.second)
                return true;
            else
                return false;
        }

        public static bool operator <(Time TLeft, Time TRight)
        {
            if (!(TLeft > TRight))
                return true;
            else
                return false;
        }

        public static bool operator ==(Time TLeft, Time TRight)
        {
            if ((TLeft.hour == TRight.hour)
            && (TLeft.minuete == TRight.minuete)
            && (TLeft.second == TRight.second))
                return true;
            else
                return false;
        }

        public static bool operator !=(Time TLeft, Time TRight)
        {
            if (!(TLeft == TRight))
                return true;
            else
                return false;
        }

        public static bool operator >=(Time TLeft, Time TRight)
        {
            if (TLeft > TRight || TLeft == TRight)
                return true;
            else
                return false;
        }

        public static bool operator <=(Time TLeft, Time TRight)
        {
            if (!(TLeft >= TRight))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return hour ^ minuete ^ second;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public string ToString()
        {
            string result = null;

            if (hour < 10)
                result = '0' + hour.ToString();
            else
                result = hour.ToString();

            if (minuete < 10)
                result += '0' + minuete.ToString();
            else
                result += minuete.ToString();

            if (minuete < 10)
                result += '0' + second.ToString();
            else
                result += second.ToString();

            return result;
        }

        public static Time operator ++(Time T)
        {
            T.second++;

            if (T.second == 60)
            {
                T.minuete++;
                T.second = 0;
            }

            if (T.minuete == 60)
            {
                T.hour++;
                T.minuete = 0;
            }

            if (T.hour == 24)
                T.hour = 0;

            return T;                
        }

        public static Time operator --(Time T)
        {
            T.second--;

            if (T.second == -1)
                T.second++;

            if (T.minuete == -1)
            {
                T.minuete++;
                T.second = 59;
            }

            if (T.hour == -1)
                T.hour = 0;

            return T;
        }

        public static Time operator -(Time TLeft, Time TRight)
        {
            
        }

        public static Time operator -(Time T, int Sec)
        {

        }

        public static Time operator +(Time T, int Sec)
        {

        }
    }
    //-----------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Time TOne = new Time(1, 23, 12);
            Time TTwo = new Time(3, 5, 43);


        }
    }
}
//-----------------------------------------------------------------