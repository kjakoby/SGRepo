using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string result = "";
            for (int i = 1; i<=n; i++)
            {
                result = result + str;
            }
            return result;

            //all passed
        }

        public string FrontTimes(string str, int n)
        {
            string s1 = str.Substring(0, 3);
            string result = "";
            for (int i = 1; i<=n; i++)
            {
                result += s1;
            }
            return result;

            //all passed
        }

        public int CountXX(string str)
        {
            //int count = 0;
            //for(int i=str.IndexOf("xx"); i!=-1; str.IndexOf("xx",i+1))
            //{
            //    count++;
            //}
            //return count;
            int count = 0;
            for (int i=0; i<str.Length-1; i++)
            {
                if (str.Contains("xx"))
                {
                    if (str.IndexOf("xx", i) == i)
                    {
                        count++;
                    }
                }
                else
                    break;
            }
            return count;

            //all passed
        }

        public bool DoubleX(string str)
        {
            //if (str.Contains("xx"))
            //    return true;
            //else
            //    return false;
            if (str.Contains("x"))
            {
                if (str.IndexOf("xx") == str.IndexOf("x"))
                    return true;
                else
                    return false;
            }
            else
                return false;

            //all passed
        }

        public string EveryOther(string str)
        {
            string result = "";
            for (int i=0; i<str.Length; i+=2)
            {
                result += str.Substring(i, 1);
            }
            return result;

            //all passed
        }

        public string StringSplosion(string str)
        {
            string result = "";
            for (int i=0; i<str.Length; i++)
            {
                result += str.Substring(0, i + 1);
            }
            return result;

            //all passed
        }

        public int CountLast2(string str)
        {
            string last = str.Substring(str.Length - 2);
            string first = str.Substring(0, str.Length - 2);
            int count = 0;
            for (int i=0;i<=first.Length-2; i++)
            {
                if (last[0] == first[i] && last[1] == first[i + 1])
                    count++;
            }
            return count++;

            //all passed
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i=0; i<numbers.Length; i++)
            {
                if (numbers[i] == 9)
                    count++;
            }
            return count;

            //all passed
        }

        public bool ArrayFront9(int[] numbers)
        {
            string numbers2 = numbers.ToString();
            if (numbers.Length < 4)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i]==9)
                        return true;
                }
                return false;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i]==9)
                        return true;
                }
                return false;
            }

            //all passed
        }

        public bool Array123(int[] numbers)
        {
            for (int i=0; i<(numbers.Length-2); i++)
            {
                if ((numbers[i] == 1) && (numbers[i + 1] == 2) && (numbers[i + 2] == 3))
                    return true;
            }
            return false;

            //all passed
        }

        public int SubStringMatch(string a, string b)
        {
            int sum=0;
            if (a.Length < b.Length)
            {
                for (int i = 0; i < a.Length - 1; i++)
                {
                    if (a[i] == b[i] && a[i + 1] == b[i + 1])
                        sum += 1;
                }
                return sum;
            }
            else
            {
                for (int i = 0; i < b.Length - 1; i++)
                {
                    if (a[i] == b[i] && a[i + 1] == b[i + 1])
                        sum += 1;
                }
                return sum;
            }

            //all passed
        }

        public string StringX(string str)
        {
            //int index = str.IndexOf('x');
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && i==0)
                {
                    continue;
                }
                else if (str[i] == 'x' && i == str.Length-1)
                {
                    continue;
                }
                if (str[i] == 'x' && (i!=0 || i==str.Length-1)) /*&& index != 0 && index != str.Length - 1)*/
                {
                    str = str.Remove(i,1);
                    i = 0;
                }
            }
            return str;

            //all passed
        }

        public string AltPairs(string str)
        {
            if (str.Length >= 10)
                return str.Substring(0, 2) + str.Substring(4, 2) + str.Substring(8, 2);
            else if (str.Length == 9)
                return str.Substring(0, 2) + str.Substring(4, 2) + str.Substring(8, 1);
            else if (str.Length >= 6 && str.Length < 9)
                return str.Substring(0, 2) + str.Substring(4, 2);
            else if (str.Length == 5)
                return str.Substring(0, 2) + str.Substring(4, 1);
            else if (str.Length >= 2 && str.Length < 5)
                return str.Substring(0, 2);
            else if (str.Length == 1)
                return str.Substring(0, 1);
            else
                return "";

            //all passed
        }

        public string DoNotYak(string str)
        {
            string minusYak = str.Replace("yak", "");
            return minusYak;

            //all passed
        }

        public int Array667(int[] numbers)
        {
            int count = 0;
            for (int i=0; i<numbers.Length-1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                    count++;
            }
            return count;

            //all passed
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i=0; i<numbers.Length-2; i++)
            {
                if (numbers[i] == numbers[i + 1] && numbers[i] == numbers[i + 2])
                    return false;
            }
            return true;

            //all passed
        }

        public bool Pattern51(int[] numbers)
        {
            for (int i=0; i<numbers.Length-2;i++)
            {
                if ((numbers[i] + 5 == numbers[i + 1]) && (numbers[i + 2] - (numbers[i] - 1)) <= 2)
                    return true;
            }
            return false;

            //all passed
        }

    }
}
