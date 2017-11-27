using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//-----------------------------------------------------------------
namespace TimeOperators
{
    class Time
    {
        int hour;
        int minuete;
        int second;

        public Time(int hour = 0, int minuete = 0, int second = 0)
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

            if (TLeft.hour == TRight.hour && TLeft.minuete > TRight.minuete)
                return true;

            if (TLeft.minuete == TRight.minuete && TLeft.second > TRight.second)
                return true;

            return false;
        }

        public static bool operator <(Time TLeft, Time TRight)
        {
            if (!(TLeft > TRight) && (TLeft != TRight))
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
            if (!(TLeft >= TRight) || (TLeft == TRight))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (hour ^ minuete ^ second);
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override string ToString()
        {
            string result = null;

            if (hour < 10)
                result = '0' + hour.ToString();
            else
                result = hour.ToString();

            result += ':';

            if (minuete < 10)
                result += '0' + minuete.ToString();
            else
                result += minuete.ToString();

            result += ':';

            if (second < 10)
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
            {
                T.hour = 0;
                T.minuete = 0;
                T.second = 0;
            }

            return T;                
        }

        public static Time operator --(Time T)
        {
            T.second--;

            if (T.second == -1)
            {
                T.second = 59;
                T.minuete--;
            }

            if (T.minuete == -1)
            {
                T.minuete = 59;
                T.hour--;
            }

            if (T.hour == -1)
            {
                T.hour = 23;
                T.minuete = 59;
                T.second = 59;
            }

            return T;
        }

        public static Time operator -(Time TLeft, Time TRight)
        {
            Time T = new Time();
            int TLeftHour = TLeft.hour;
            int TLeftMinuete = TLeft.minuete;
            int TLeftSecond = TLeft.second;

            int TRightHour = TRight.hour;
            int TRightMinuete = TRight.minuete;
            int TRightSecond = TRight.second;

            if (TLeftHour < TRightHour)
            {
                //if (TLeftSecond < TRightSecond)
                //{
                //    T.second = (TLeftSecond + 60) - TRightSecond;
                //    TLeftMinuete--;
                //}
                //else
                //    T.second = TLeftSecond - TRightSecond;

                //if (TLeftMinuete < TRightMinuete)
                //{
                //    T.minuete = (TLeftMinuete + 60) - TRightMinuete;
                //    TLeftHour--;
                //}
                //else
                //    T.minuete = TLeftMinuete - TRightMinuete;

                //T.hour = TRightHour - TLeftHour;

                T.hour = 0;
                T.minuete = 0;
                T.second = 0;
            }
            else
            {
                if (TLeftSecond < TRightSecond)
                {
                    T.second = (TLeftSecond + 60) - TRightSecond;
                    TLeftMinuete--;
                }
                else
                    T.second = TLeftSecond - TRightSecond;

                if (TLeftMinuete < TRightMinuete)
                {
                    T.minuete = (TLeftMinuete + 60) - TRightMinuete;
                    TLeftHour--;
                }
                else
                    T.minuete = TLeftMinuete - TRightMinuete;

                T.hour = TLeftHour - TRightHour;
            }

            return T;
        }

        public static Time operator +(Time T, int Sec)
        {
            int count = Sec / 60;

			if (count <= 1) // sec
			{
                T.second += Sec;
				if (T.second > 60)
					T.minuete++;
			}

            if (count > 1 && 60 > count) // min
            {
                T.minuete += count;
				if (T.minuete > 60)
					T.hour++;

				T.second += Sec - (count * 60);
				if (T.second > 60)
					T.minuete++;
			}

            if (count >= 60) // hour
            {
                T.hour += Sec / 3600;

                T.minuete += Sec - (count * 60);
				if (T.minuete > 60)
					T.hour++;

				T.second += Sec - 3600;
				if (T.second > 60)
					T.minuete++;
			}

            return T;
        }

        public static Time operator -(Time T, int Sec)
        {
            int timeInSec = (T.hour * 3600 + T.minuete * 60 + T.second) - Sec;

            T.hour = timeInSec / 3600;
            T.minuete = timeInSec / 60;
            T.second = (3600 * 60) - timeInSec;

            return T;
        }
    }
    //-----------------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Time TOne = new Time(11, 1, 14);
            Time TTwo = new Time(1, 21, 31);

            //Time TOne = new Time(1, 1, 1);
            //Time TTwo = new Time(1, 1, 1);

            Time T = new Time(0, 0, 0);

            Console.WriteLine($"{TOne.ToString()} < {TTwo.ToString()} : {TOne < TTwo}");
            Console.WriteLine($"{TOne.ToString()} > {TTwo.ToString()} : {TOne > TTwo}");
            Console.WriteLine();
            Console.WriteLine($"{TOne.ToString()} == {TTwo.ToString()} : {TOne == TTwo}");
            Console.WriteLine($"{TOne.ToString()} != {TTwo.ToString()} : {TOne != TTwo}");
            Console.WriteLine();
            Console.WriteLine($"{TOne.ToString()} <= {TTwo.ToString()} : {TOne <= TTwo}");
            Console.WriteLine($"{TOne.ToString()} >= {TTwo.ToString()} : {TOne >= TTwo}");
            Console.WriteLine();
            Console.WriteLine($"Get hash code: {TOne.GetHashCode()} {TTwo.GetHashCode()}");
            Console.WriteLine();
            Console.WriteLine($"Equals: {TOne.Equals(TTwo)} {TTwo.Equals(TOne)}");
            Console.WriteLine();
            Console.WriteLine($"ToString: {TOne.ToString()}\t{TTwo.ToString()}");
            Console.WriteLine();
            //Console.WriteLine("++");
            //while (true)
            //{
            //    Console.CursorVisible = false;
            //    Console.SetCursorPosition(0, 16);
            //    Console.WriteLine("        ");
            //    Console.SetCursorPosition(0, 16);
            //    Console.WriteLine($"{T++.ToString()}");

            //    if (Console.KeyAvailable)
            //        if (ConsoleKey.Escape == Console.ReadKey().Key)
            //            break;

            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine();
            //Console.WriteLine("--");
            //while (true)
            //{
            //    Console.CursorVisible = false;
            //    Console.SetCursorPosition(0, 18);
            //    Console.WriteLine("        ");
            //    Console.SetCursorPosition(0, 18);
            //    Console.WriteLine($"{T--.ToString()}");

            //    if (Console.KeyAvailable)
            //        if (ConsoleKey.Escape == Console.ReadKey().Key)
            //            break;

            //    Thread.Sleep(1000);
            //}
            //Console.WriteLine();
            Console.WriteLine($"{TOne.ToString()} - {TTwo.ToString()} = {(TOne - TTwo).ToString()}");
            Console.WriteLine($"{TTwo.ToString()} - {TOne.ToString()} = {(TTwo - TOne).ToString()}");
            Console.WriteLine();
            Console.Write("Write seconds for plus: ");
            int.TryParse(Console.ReadLine(), out int sec);
            Console.WriteLine($"{T.ToString()} + {sec}sec = {(T + sec).ToString()}");
        }
    }
}
//-----------------------------------------------------------------