using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if (((cigars > 40) && (cigars < 60)) || isWeekend)
                return true;
            else
                return false;

            //all passed
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle <= 2 || dateStyle <= 2)
                return 0;
            else if (yourStyle >= 8 || dateStyle >= 8)
                return 2;
            else
                return 1;

            //all passed
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if (temp >= 60 && temp <= 90)
                return true;
            else if (temp >= 60 && temp <= 100 && isSummer)
                return true;
            else
                return false;

            //all passed
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            if (speed <= 60 && !isBirthday)
                return 0;
            else if (isBirthday && speed <= 65)
                return 0;
            else if (speed >= 61 && speed <= 80 && !isBirthday)
                return 1;
            else
                return 2;

            //all passed
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if (sum >= 10 && sum <= 19)
                return 20;
            else
                return sum;

            //all passed
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (day >= 1 && day <= 5 && !vacation)
                return "7:00";
            else if (day == 0 || day == 6 && !vacation)
                return "10:00";
            else if (day >= 1 && day <= 5 && vacation)
                return "10:00";
            else
                return "0";

            //all passed
        }
        
        public bool LoveSix(int a, int b)
        {
            if (a == 6 || b == 6)
                return true;
            else if (a + b == 6)
                return true;
            else if (a % b == 6)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (n >= 1 && n <= 10)
                return true;
            else if ((outsideMode && n <= 1) || (n >= 10 && outsideMode))
                return true;
            else
                return false;

            //all passed
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0)
                return true;
            else if (n % 11 == 1)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool Mod20(int n)
        {
            if (n % 20 == 1 || n % 20 == 2)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0 && n % 5 == 0)
                return false;
            else if (n % 3 == 0 || n % 5 == 0)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isMorning && !isMom && !isAsleep)
                return false;
            else if (isAsleep)
                return false;
            else
                return true;

            //all passed
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c)
                return true;
            else if (b + c == a)
                return true;
            else if (a + c == b)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (b > a && c > b || bOk == true)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a < b && b < c)
                return true;
            else if (equalOk)
                return true;
            else
                return false;

            //all passed
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int a2 = a % 10;
            int b2 = b % 10;
            int c2 = c % 10;
            if (a2 == b2 || b2 == c2 || a2 == c2)
                return true;
            else
                return false;

            //all passed
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            int sum = die1 + die2;
            if (noDoubles && die2 == die1)
                return sum + 1;
            else
                return sum;

            //all passed
        }

    }
}
