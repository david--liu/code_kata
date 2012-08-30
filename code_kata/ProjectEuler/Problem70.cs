using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem70
    {
        static Dictionary<int, SortedSet<int>> primeMap;

        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() =>BruteForce());
            It should_get_totient = () =>
            {
                GetTotient(9, primeMap[9]).ShouldEqual(6);
                GetTotient(87109, primeMap[87109]).ShouldEqual(79180);

            };

        }

        static int BruteForce()
        {

            var map = new Dictionary<int, double>();

            PopulatePrimeFactors();

            foreach (var x in primeMap.Where(x => x.Value.Count == 2 && x.Key == x.Value.Aggregate(1, (current, i) => current * i)))
            {
                var totient = GetTotient(x.Key, x.Value);
                if (MathUtils.IsPermutation(x.Key, totient))
                {
                    map.Add(x.Key, Convert.ToDouble(x.Key) / totient);
                }

            }
            
            var min = map.Select(x => x.Value).Min();
            Console.Out.WriteLine("min ratio :" + min);
            var pair = map.First(x => x.Value == min);

            return pair.Key;
        }

        static void PopulatePrimeFactors()
        {
            primeMap = new Dictionary<int, SortedSet<int>>();
            var primes = MathUtils.ESieve(3200);
            for (int i = 2; i < 10000000; i++)
            {
                primeMap.Add(i, new SortedSet<int>());

            }

            primeMap.AsParallel().ForAll(x =>
            {
                for (int j = 0; j < primes.Length; j++)
                {
                    if (primes[j] * primes[j] > x.Key)
                        break;
                    if (x.Key % primes[j] == 0)
                    {
                        x.Value.Add(primes[j]);
                        var i = x.Key/primes[j];
                        if(MathUtils.IsPrime(i))
                        {
                            x.Value.Add(i);
                        }
                    }
                }

            });


        }

        public static int GetTotient(int num, IEnumerable<int> set)
        {
            int result = num;
            foreach (var prime  in set)
            {
                result = result - result/prime;
            }

            return result;
        }

    }
}
