using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem47
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                GetPrimeFactors(2).Length.ShouldEqual(2);
                GetPrimeFactors(3).ShouldContain(3);
                GetPrimeFactors(3).ShouldContain(5);
            };

            It should_return_correct_prime_factors = () =>
            {
                var primeFactors = GetPrimeFactors(100);
                HasDistinctPrimeFactors(644, primeFactors, 3).ShouldBeTrue();
                HasDistinctPrimeFactors(645, primeFactors, 3).ShouldBeTrue();
                HasDistinctPrimeFactors(646, primeFactors, 3).ShouldBeTrue();
            };

            It should_get_result_for_three = () =>
                BruteForce(3).ShouldEqual(644);

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce(4));

        }

        

        static long BruteForce(int times)
        {
            long i = 2 * 3 * 5 * 7;
            var primeFactors = GetPrimeFactors(100);
            var stack = new Stack<long>();
            while (true)
            {
                if (HasDistinctPrimeFactors(i, primeFactors, times))
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Clear();
                }

                if (stack.Count == times)
                {
                    break;
                }
                i++;

            }
            var count = stack.Count - 1;
            for (int s = 0; s < count; s++)
            {
                stack.Pop();
            }
            return stack.Pop();
        }

        static int[] GetPrimeFactors(int len)
        {
            int i = 0;
            var j = 2;
            var result = new int[len];
            while (i<len)
            {
                if(MathUtils.IsPrime(j))
                {
                    result[i] = j;
                    i++;
                }
                j++;
            }
            return result;
        }

        static bool HasDistinctPrimeFactors(long num, int[] primeFactors, int expected)
        {
            var set = new SortedSet<int>();
            long temp = num;
            foreach (var primeFactor in primeFactors)
            {
                if(temp % primeFactor == 0)
                {
                    temp = Divide(temp, primeFactor);
                    set.Add(primeFactor);
                }

                if(MathUtils.IsPrime(temp))
                {
                    set.Add(Convert.ToInt32(temp));
                }
            }

            return set.Count == expected;
        }

        static long Divide(long num, int prime)
        {
            long result = num;
            while (result % prime == 0)
            {
                result /= prime;
            }
            return result;
        }
    }
}
