using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem50
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                BruteForce(1001, 500).ShouldEqual(21);

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce(1000001, 4000));

        }

        public class when_working_backwards : concern
        {
            It should_get_result_much_faster = () =>
                Utils.PrintResult(() => BruteForce2());
        }

        static int BruteForce(int num, int maxPrime)
        {
            var map = new Dictionary<int, int>();
            var primes = GetPrimesBelow(maxPrime).ToArray();
            var count = primes.Length;
            for (int i = num; i > 100; i = i - 2)
            {
                if(MathUtils.IsPrime(i))
                {
                    if(!map.ContainsKey(i))
                    {
                        map.Add(i, 0);
                    }

                    int max = 0;
                    int j = 0;

                    while (max + j < count)
                    {
                        var temp = primes[j];
                        for (int k = j + 1; k < count; k++)
                        {
                            temp += primes[k];
                            if(temp == i)
                            {
                                var max1 = k - j + 1;
                                max = max > max1 ? max : max1;
                                break;
                            }
                            else if(temp > i)
                            {
                                break;
                            }
                        }

                        j ++;
                    }

                    map[i] = max;

                }
            }

            var times = map.Max(x => x.Value);
            return map.First(x => x.Value == times).Key;
        }

        static int BruteForce2()
        {
            var primesBelow = GetPrimesBelow(4000);
            var count = primesBelow.Count;
            int maxSequence = 0;
            int maxValue = 0;
            for (int i = 0; i < count; i++)
            {
                int temp = 0;
                
                for (int j = i; j < count; j++)
                {
                    temp += primesBelow[j];
                    if(temp >= 1000000)
                        break;
                    if(MathUtils.IsPrime(temp))
                    {
                        if(maxSequence < j - i + 1)
                        {
                            maxSequence = j - i + 1;
                            maxValue = temp;
                        }
                    }
                }
            }

            return maxValue;
        }

        static List<int> GetPrimesBelow(int max)
        {
            var result = new List<int>();
            result.Add(2);
            for (int i = 3; i < max; i = i + 2)
            {
                if(MathUtils.IsPrime(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
