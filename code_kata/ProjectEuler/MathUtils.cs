using System;
using System.Collections.Generic;

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

            for (int i = 0; i < max; i++)
            {
                if(result[i] >= 10)
                {
                    result[i] -= 10;
                    if(i == max -1)
                    {
                        result.Add(1);
                    }
                    else
                    {
                        result[i + 1] += 1;
                    }
                }
            }

            return result;

        }

        public static bool IsPrime(int num)
        {
            if (num == 2)
                return true;

            if (num % 2 == 0 || num == 1 || num == 0)
                return false;

            int root = (int)Math.Sqrt(num) + 1;
            for (int i = root; i >= 2; i--)
            {
                if (num % i == 0)
                    return false;
            }
            return true;

        }

        public static int Factorial(int number)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }

        public static List<int> ConvertToDigits(int number)
        {
            var result = new List<int>();
            var temp = number;
            while (temp > 0)
            {
                result.Add(temp - (temp / 10) * 10);
                temp = temp/10;
            }
            result.Reverse();

            return result;
        }
    }
}