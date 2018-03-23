using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            int firstNumber = numbers[0];
            int lastNumber = numbers[numbers.Length - 1];
            if (firstNumber == 6 || lastNumber == 6)
                return true;
            else
                return false;

            //all passed
        }

        public bool SameFirstLast(int[] numbers)
        {
            int firstNumber = numbers[0];
            int lastNumber = numbers[numbers.Length - 1];
            if (firstNumber == lastNumber)
                return true;
            else
                return false;

            //all passed
        }

        public int[] MakePi(int n)
        {
            //first way i solved it

            double pi = Math.PI;
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = (int)Math.Floor(pi);
                pi -= result[i];
                pi *= 10;
            }
            return result;


            //int[] pi = new int[n];
            //double withDecimal = Math.PI;
            //string piString = withDecimal.ToString();
            //for (int i = 0; i<n; i++)
            //{
            //    string withoutDecimal = piString.Remove(1, 1);
            //    string firstHalf = withoutDecimal.Substring(i, 1);
            //    int firstNumber = int.Parse(firstHalf);
            //    pi[i] = firstNumber;
            //}
            //return pi;

            //all passed
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[a.Length - 1] == b[b.Length - 1])
                return true;
            else
                return false;

            //all passed
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            foreach (int element in numbers)
                sum += element;
            return sum;

            //all passed
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int[] rotated = { numbers[1], numbers[2], numbers[0] };
            return rotated;

            //all passed
        }
        
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;

            //all passed
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int[] higher1st = { numbers[0], numbers[0], numbers[0] };
            int[] higher2nd = { numbers[2], numbers[2], numbers[2] };
            if (numbers[0] > numbers[2])
                return higher1st;
            else if (numbers[0] < numbers[2])
                return higher2nd;
            else
                return numbers;

            //all passed
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int number1 = a[1];
            int number2 = b[1];
            int[] combined = { number1, number2 };
            return combined;

            //all passed
        }
        
        public bool HasEven(int[] numbers)
        {
            int number1 = numbers[0];
            int number2 = numbers[1];
            if (number1 % 2 == 0 || number2 % 2 == 0)
                return true;
            else
                return false;

            //all passed
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int lengthOfArray = numbers.Length;
            int doubled = lengthOfArray * 2;
            int lastNumber = numbers[numbers.Length - 1];
            int[] doubledArray = new int[doubled];
            doubledArray[doubledArray.Length - 1] = lastNumber;
            return doubledArray;
            
            //all passed
        }
        
        public bool Double23(int[] numbers)
        {
            int count2s = 0;
            int count3s = 0;
            for (int i=0; i<=numbers.Length-1;i++)
            {
                if (numbers[i] == 2)
                {
                    count2s++;
                    continue;
                }
                if (numbers[i] == 3)
                {
                    count3s++;
                    continue;
                }
                else
                    continue;
            }
            if (count2s <= 2 && count3s <= 2)
                return true;
            else
                return false;

            //all passed
        }
        
        public int[] Fix23(int[] numbers)
        {
            int indexOf3 = Array.IndexOf(numbers, 3);
            int indexOf2 = Array.IndexOf(numbers, 2);
            //if numbers at index i is 2 and index i+1 is 3, replace 3 with 0
            if (indexOf2 == indexOf3 - 1)
            {
                numbers.SetValue(0, indexOf3);
            }
            return numbers;

            //all passed
        }
        
        public bool Unlucky1(int[] numbers)
        {
            int indexOf1 = Array.IndexOf(numbers, 1);
            int indexOf3 = Array.IndexOf(numbers, 3);
            if (indexOf1 == (indexOf3) - 1)
            {
                return true;
            }
            else
                return false;

            //all passed
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] secondArray = new int[2];
            int bScale = 0;
            for (int i = 0; i < secondArray.Length; i++)
            {
                if (a.Length == ' ')
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[j] ==0)
                        {
                            continue;
                        }
                        else
                            secondArray[j] = a[j];
                    }
                }

                if (secondArray[i] == 0)
                {
                    secondArray[i] = b[bScale];
                    bScale++;
                    continue;
                }
                else
                    continue;
            }
            return secondArray;

            //all passed
        }

    }
}
