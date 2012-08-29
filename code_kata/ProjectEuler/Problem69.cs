using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem69
    {
        static Dictionary<int, List<int>> primeMap;

        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());

            It should_check_known = () =>
            {
                GetPhiRation(2).ShouldEqual(2);
                GetPhiRation(3).ShouldEqual(1.5d);
                GetPhiRation(9).ShouldEqual(1.5d);
            };
        }


        static int BruteForce()
        {
            int result = 1;
            int[] primes = MathUtils.ESieve(200);
            int i = 0;
            int limit = 1000000;

            while (result * primes[i] < limit)
            {
                result *= primes[i];
                i++;
            }
            return result;
        }

        static void PopulatePrimeFactors()
        {
            primeMap = new Dictionary<int, List<int>>();
            var primes = MathUtils.ESieve(1000);
            for (int i = 2; i <= 1000000; i++)
            {
                primeMap.Add(i, new List<int>());
                for (int j = 0; j < primes.Length; j++)
                {
                    if (primes[j] * primes[j] > i)
                        break;
                    if(i % primes[j] == 0)
                    {
                        primeMap[i].Add(primes[j]);
                    }
                }

            }
        }


        static double GetPhiRation(int num)
        {
            double numberOfPrimes = 1;
            for (int i = 2; i < num; i++)
            {
                if(num % i > 0 && !HasCommonPrime(num, i))
                { 
                    numberOfPrimes ++;
                }


            }

            return num/numberOfPrimes;
        }

        static bool HasCommonPrime(int num, int i)
        {
            return primeMap[num].Any(x => primeMap[i].Any(y => y == x));
        }
    }
}
