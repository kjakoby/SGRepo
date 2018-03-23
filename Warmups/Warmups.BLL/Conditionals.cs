using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if ((!aSmile && !bSmile) || (aSmile && bSmile))
                return true;
            else
                return false;

            //all passed
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (!isWeekday || isVacation)
                return true;
            else
                return false;

            //all passed
        }

        public int SumDouble(int a, int b)
        {
            int sum = a + b;
            if (a == b)
                return sum + sum;
            else
                return sum;

            //all passed
        }
        
        public int Diff21(int n)
        {
            int diffSum = n - 21;
            int abs = Math.Abs(diffSum);
            if (n <= 21)
                return abs;
            else
                return abs + abs;

            //all passed
        }
        
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool timetrouble = (hour < 7 || hour > 20);
            if (isTalking && timetrouble)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool Makes10(int a, int b)
        {
            int sum = a + b;
            if ((a == 10) || (b == 10) || (sum == 10))
                return true;
            else
                return false;

            //all passed
        }
        
        public bool NearHundred(int n)
        {
            if ((n <= 100 && n >= 90) || (n >= 100 && n <= 110))
                return true;
            else if ((n <= 200 && n >= 190) || (n >= 100 && n <= 210))
                return true;
            else
                return false;

            //all passed
        }
        
        public bool PosNeg(int a, int b, bool negative)
        {
            bool negA = a < 0;
            bool negB = b < 0;
            if (negA || (negB && !negative))
                return true;
            else if ((negA && negB) && negative)
                return true;
            else
                return false;

            //all passed
        }
        
        public string NotString(string s)
        {
            if (s.Contains("not"))
                return s;
            else
                return "not" + " " + s;

            //all passed
        }
        
        public string MissingChar(string str, int n)
        {
            string newStr = str.Remove(n, 1);
            return newStr;

            //all passed
        }
        
        public string FrontBack(string str)
        {
            var firstChar = str[0];
            var lastChar = str[str.Length - 1];
            if (str.Length < 2)
                return str;
            else
                return lastChar + str.Substring(1, str.Length - 2) + firstChar;

            //all passed
        }
        
        public string Front3(string str)
        {
            if (str.Length < 3)
                return str + str + str;
            else
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);

            //all passed
        }
        
        public string BackAround(string str)
        {
            string last = str.Substring(str.Length - 1, 1);
            return last + str + last;

            //all passed
        }
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool StartHi(string str)
        {
            if (str.Contains("hi" + " ") || (str == "hi") || str.Contains("hi,"))
                return true;
            else
                return false;

            //all passed 
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 < 0 && temp2 > 100) || (temp1 > 100 && temp2 < 0))
                return true;
            else
                return false;

            //believe all passed
        }
        
        public bool Between10and20(int a, int b)
        {
            bool aTrue = (a <= 20 && a >= 10);
            bool bTrue = (b <= 20 && b >= 10);
            if (aTrue || bTrue)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            bool aTrue = (a >= 13 && a <= 19);
            bool bTrue = (b >= 13 && b <= 19);
            bool cTrue = (c >= 13 && c <= 19);
            if (aTrue || bTrue || cTrue)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool SoAlone(int a, int b)
        {
            bool aTrue = a <= 19 && a >= 13;
            bool bTrue = b <= 19 && b >= 13;
            if (aTrue && bTrue)
                return false;
            else if (aTrue || bTrue)
                return true;
            else
                return false;

            //all passed
        }
        
        public string RemoveDel(string str)
        {
            int del = str.IndexOf("del");
            if (del == 1)
                return str.Remove(1, 3);
            else
                return str;

            //all passed
        }
        
        public bool IxStart(string str)
        {
            int ix = str.IndexOf("ix");
            if (ix == 1)
                return true;
            else
                return false;

            //all passed
        }
        
        public string StartOz(string str)
        {
            int o = str.IndexOf("o");
            int z = str.IndexOf("z");
            int oz = str.IndexOf("oz");
            int space = str.IndexOf(" ");
            if (str.Length < 2)
                return "";
            else if (oz == 0)
                return str.Substring(0, 2);
            else if (o == 0 || o == 1)
                return str.Substring(0, 1);
            else if (z == 0)
                return str.Substring(0, 1);
            else if (z == 1)
                return str.Substring(1, 1);
            else
                return str;

            //all passed
        }
        
        public int Max(int a, int b, int c)
        {
            if (a > b && a > c)
                return a;
            else if (b > a && b > c)
                return b;
            else
                return c;

            //all passed
        }
        
        public int Closer(int a, int b)
        {
            int calA = Math.Abs(a - 10);
            int calB = Math.Abs(b - 10);
            if (calA == calB)
                return 0;
            else if (calA > calB)
                return b;
            else
                return a;

            //all passed
        }
        
        public bool GotE(string str)
        {
            int count = 0;
            for (int i=0; i<=str.Length-1;i++)
            {
                if (str.Contains("e") == false)
                    return false;
                if (str.IndexOf('e',i)==i)
                {
                    count++;
                    //startIndex++;
                }
            }
            if (count <= 3)
                return true;
            else
                return false;

            //all passed
        }
        
        public string EndUp(string str)
        {
            if (str.Length < 3)
                return str.ToUpper();
            else
            {
                string last3 = str.Substring(str.Length - 3);
                string before3 = str.Substring(0, str.Length - 3);
                string caps = last3.ToUpper();
                return before3 + caps;
            }

            //all passed
        }
        
        public string EveryNth(string str, int n)
        {
            string secondStr = null;
            string neededLetter = null;
            for (int i=0; i<str.Length;i+=n)
            {
                neededLetter = str.Substring(i, 1);
                secondStr += neededLetter;
            }
            return secondStr;

            //all passed
        }
    }
}
