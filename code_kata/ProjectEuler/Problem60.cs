using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem60
    {
        static int[] primes;

        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                IsOk(3, 7, 109, 673).ShouldBeTrue();
                IsOk(3, 5, 109, 673).ShouldBeFalse();
            };

            It should_brute_force = () =>
                Utils.PrintResult(() => BruteForce());
        }


        static public int BruteForce()
        {

            int result = int.MaxValue;
            primes = MathUtils.ESieve(30000);

            var pairs = new HashSet<int>[primes.Length];

            for (int a = 1; a < primes.Length; a++)
            {
                if (primes[a] * 5 >= result) break;
                if (pairs[a] == null) pairs[a] = MakePairs(a);
                for (int b = a + 1; b < primes.Length; b++)
                {
                    if (primes[a] + primes[b] * 4 >= result) break;
                    if (!pairs[a].Contains(primes[b])) continue;
                    if (pairs[b] == null) pairs[b] = MakePairs(b);

                    for (int c = b + 1; c < primes.Length; c++)
                    {
                        if (primes[a] + primes[b] + primes[c] * 3 >= result) break;
                        if (!pairs[a].Contains(primes[c]) ||
                            !pairs[b].Contains(primes[c])) continue;
                        if (pairs[c] == null) pairs[c] = MakePairs(c);

                        for (int d = c + 1; d < primes.Length; d++)
                        {
                            if (primes[a] + primes[b] + primes[c] + primes[d] * 2 >= result) break;
                            if (!pairs[a].Contains(primes[d]) ||
                                !pairs[b].Contains(primes[d]) ||
                                !pairs[c].Contains(primes[d])) continue;
                            if (pairs[d] == null) pairs[d] = MakePairs(d);

                            for (int e = d + 1; e < primes.Length; e++)
                            {
                                if (primes[a] + primes[b] + primes[c] + primes[d] + primes[e] >= result) break;
                                if (!pairs[a].Contains(primes[e]) ||
                                    !pairs[b].Contains(primes[e]) ||
                                    !pairs[c].Contains(primes[e]) ||
                                    !pairs[d].Contains(primes[e])) continue;

                                if (result > primes[a] + primes[b] + primes[c] + primes[d] + primes[e])
                                    result = primes[a] + primes[b] + primes[c] + primes[d] + primes[e];

                                Console.WriteLine("{0} + {1} + {2} + {3} + {4} = {5}", primes[a], primes[b], primes[c], primes[d], primes[e], result);
                                break;
                            }
                        }
                    }
                }
            }

            return result;
        }

 
        static private HashSet<int> MakePairs(int a)
        {
            var pairs = new HashSet<int>();
            for (int b = a + 1; b < primes.Length; b++)
            {
                if (MathUtils.IsPrime(concat(primes[a], primes[b])) &&
                    MathUtils.IsPrime(concat(primes[b], primes[a])))
                    pairs.Add(primes[b]);
            }
            return pairs;
        }

        static private int concat(int a, int b)
        {
            int c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }

            return a + b;
        }

        static bool IsOk(params int[] primes)
        {
            foreach (var prime in primes)
            {
                var digits = MathUtils.ConvertToDigits(prime);
                foreach (var i in primes)
                {
                   if(prime == i)   
                       continue;

                    var ints = MathUtils.ConvertToDigits(i);

                    if (!(MathUtils.IsPrime(MathUtils.ConvertToNumber(digits.Concat(ints).ToArray()))
                         && MathUtils.IsPrime(MathUtils.ConvertToNumber(digits.Concat(ints).ToArray()))))
                    {
                        return false;
                    }
                }
            }

            foreach (var prime in primes)
            {
                Console.Out.WriteLine(prime);
                
            }
            return true;
        }
    }
}
