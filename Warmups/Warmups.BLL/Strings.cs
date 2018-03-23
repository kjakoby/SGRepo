using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";

            //all passed
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;

            //all passed
        }

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";

            //all passed
        }

        public string InsertWord(string container, string word)
        {
            string c1 = (container.Substring(0, 2));
            string c2 = (container.Substring(2, 2));
            return c1 + word + c2;

            //all passed
        }

        public string MultipleEndings(string str)
        {
            string s1 = str;
            string s2 = str.Substring(s1.Length - 2);
            return s2 + s2 + s2;

            //all passed
        }

        public string FirstHalf(string str)
        {
            int s1 = (str.Length / 2);
            string half = str.Substring(0, s1);
            return half;

            //all passed
        }

        public string TrimOne(string str)
        {
            string s1 = str.Substring(1, str.Length - 2);
            return s1;

            //all passed
        }

        public string LongInMiddle(string a, string b)
        {
            int sA = a.Length;
            int sB = b.Length;
            if (sA > sB)
                return b + a + b;
            else
                return a + b + a;

            //all passed
        }

        public string RotateLeft2(string str)
        {
            string firstHalf = str.Substring(0, 2);
            string secondHalf = str.Substring(2);
            int word = str.Length;
            if (word <= 2)
                return str;
            else
                return secondHalf + firstHalf;

            //all passed
        }

        public string RotateRight2(string str)
        {
            string second = str.Substring(str.Length - 2, 2);
            string first = str.Substring(0, str.Length - 2);
            int text = str.Length;
            if (text <= 2)
                return str;
            else
                return second + first;

            //all passed
        }

        public string TakeOne(string str, bool fromFront)
        {
            string letter1 = str.Substring(0, 1);
            string letter2 = str.Substring(str.Length - 1, 1);
            if (fromFront == false)
                return letter2;
            else
                return letter1;

            //all passed
        }

        public string MiddleTwo(string str)
        {
            int length1 = str.Length;
            int halfOfLength = length1 / 2;
            string half1 = str.Substring(0, halfOfLength);
            string half2 = str.Substring(halfOfLength, halfOfLength);
            string lastOf1 = half1.Substring(half1.Length - 1, 1);
            string firstOf2 = half2.Substring(0, 1);
            return lastOf1 + firstOf2;

            //all passed
        }

        public bool EndsWithLy(string str)
        {
            if (str.Contains("ly"))
                return true;
            else
                return false;

            //all passed
        }

        public string FrontAndBack(string str, int n)
        {
            string frontHalf = str.Substring(0, n);
            string backHalf = str.Substring(str.Length - n, n);
            return frontHalf + backHalf;

            //all passed
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            string odd = str.Substring(0, 2);
            int string1 = str.Length;
            if (string1 <= n + 1)
                return odd;
            else
                return str.Substring(n, 2);

            //all passed
        }

        public bool HasBad(string str)
        {
            int wordStart = str.IndexOf("bad");
            if (wordStart == 0)
                return true;
            if (wordStart == 1)
                return true;
            else
                return false;

            //all passed
        }

        public string AtFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "@@";
            else if (str.Length < 2)
                return str.Substring(0, 1) + "@";
            else
                return str.Substring(0, 2);

            //all passed
        }

        public string LastChars(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                return "@" + "@";
            else if (string.IsNullOrEmpty(b))
                return a.Substring(0, 1) + "@";
            else if (string.IsNullOrEmpty(a))
                return "@" + b.Substring(0, 1);
            else
                return a.Substring(0, 1) + b.Substring(b.Length - 1, 1);

            //all passed
        }

        public string ConCat(string a, string b)
        {
            string combined = a + b;
            if (string.IsNullOrEmpty(a))
                return b;
            if (string.IsNullOrEmpty(b))
                return a;
            if (a.Substring(a.Length - 1, 1) == b.Substring(0, 1))
                return (a.Substring(0)) + (b.Substring(1));
            else
                return combined;

            //all passed
        }

        public string SwapLast(string str)
        {
            string placeHolder = "~";
            //string last = str.Substring(str.Length - 1, 1);
            //string secondToLast = str.Substring(str.Length - 2, 1);
            if (str.Length < 2)
                return str;
            else
                //return str.Replace(last, placeHolder).Replace(secondToLast, last).Replace(placeHolder, secondToLast);
                return str.Replace(str.Substring(str.Length - 1, 1), placeHolder).Replace(str.Substring(str.Length - 2, 1), str.Substring(str.Length - 1, 1)).Replace(placeHolder, str.Substring(str.Length - 2, 1));

            //all passed
        }

        public bool FrontAgain(string str)
        {
            string front = str.Substring(0, 2);
            string back = str.Substring(str.Length - 2, 2);
            if (front == back)
                return true;
            else
                return false;

            //all passed
        }

        public string MinCat(string a, string b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            if (a.Length != b.Length)
                if (string.IsNullOrEmpty(a) || (string.IsNullOrEmpty(b)))
                    return string.Empty;
                if (aLength > bLength)
                    return a.Substring(aLength - bLength) + b;
                if (bLength > aLength)
                    return a + b.Substring(bLength - aLength);
            else
                return a + b;
            
            //all passed
        }

        public string TweakFront(string str)
        {
            int aIndex = str.IndexOf("a");
            int bIndex = str.IndexOf("b");
            if (aIndex == 0 && bIndex == 1)
                return str;
            else if (str == "")
                return "";
            else if (aIndex != 0 && bIndex != 1)
                return str.Substring(2);
            else if (aIndex == 0)
                return str.Remove(1, 1);
            else
                return str.Remove(0, 1);

            //all passed
        }

        public string StripX(string str)
        {
            int indexOfX = str.IndexOf('x');
            int lastIndex = str.LastIndexOf('x');
            if (str=="" || str=="x")
            {
                return "";
            }
            if (indexOfX == 0 && lastIndex == str.Length - 1)
                return str.Substring(1, str.Length - 2);
            else if (indexOfX == 0)
                return str.Substring(1);
            else if (lastIndex == str.Length - 1)
                return str.Substring(0, str.Length - 1);
            else
                return str;
            
            //all passed
        }
    }
}
