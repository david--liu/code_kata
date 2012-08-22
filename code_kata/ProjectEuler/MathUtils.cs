using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public static class MathUtils
    {
        public static List<int> Sum(List<int> list1, List<int> list2)
        {
            var result = new List<int>();

            var max = list1.Count > list2.Count ? list1.Count : list2.Count;

            for (int i = 0; i < max; i++)
            {
                result.Add((list2.Count > i ? list2[i] : 0) + (list1.Count > i ? list1[i] : 0));
            }

            FlattenList(result);

            return result;

        }

        public static int[] ESieve(int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            var PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            var numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }


        static void FlattenList(List<int> result, bool shouldReverse = false)
        {
            if (shouldReverse)
                result.Reverse();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] >= 10)
                {
                    var newDigit = result[i] / 10;
                    result[i] %= 10;
                    if (i == result.Count - 1)
                    {
                        result.Add(newDigit);
                    }
                    else
                    {
                        result[i + 1] += newDigit;
                    }
                }
            }
        }

        public static List<int> Multi(List<int> list1, List<int> list2)
        {
            var result = new List<int>();

            for (int i = list2.Count -1; i >=0 ; i--)
            {
                var list = new List<int>(list1);
                for (int j = 0; j < list.Count; j++)
                {
                    list[j] *= list2[i];
                }
                FlattenList(list,true);
                for (int j = i; j < list2.Count -1; j++)
                {
                    list.Insert(0,0);
                }

                result = Sum(list, result);
            }

            result.Reverse();
            return result;
        }

        public static bool IsPrime2(long num)
        {
            if (num == 2)
                return true;

            if (num % 2 == 0 || num == 1 || num == 0)
                return false;

            long root = (long)Math.Sqrt(num) + 1;
            for (var i = root; i >= 2; i--)
            {
                if (num % i == 0)
                    return false;
            }
            return true;

        }

        public static bool IsPrime(long n)


        {
            if (n <= 1) return false;            
            if (n == 2) return true;            
            if (n % 2 == 0) return false;            
            if (n < 9) return true;            
            if (n % 3 == 0) return false;
            
            int counter = 5;
            while ((counter * counter) <= n) {
                if (n % counter == 0) return false;                
                if (n % (counter + 2) == 0) return false;                
                counter += 6;
            }

            return true;
        }

        

        public static long Factorial(int number)
        {
            if (number == 0)
                return 1;
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        public static List<int> ConvertToDigits(double number)
        {
            return Convert.ToString(number).Select(x => Convert.ToInt32(char.GetNumericValue(x))).ToList();
        }

        public static int ConvertToNumber(int[] list)
        {
            int result = 0;
            int pow = 1;
            for (int i = list.Length -1; i >= 0; i--)
            {

                result += pow*list[i];
                pow *= 10;
            }

            return result;
        }
        public static double ConvertToDouble(int[] list)
        {
            double result = 0;
            for (int i = list.Length -1; i >= 0; i--)
            {
                result += Math.Pow(10,list.Length - i -1)*list[i];
            }

            return result;
        }

    }
}