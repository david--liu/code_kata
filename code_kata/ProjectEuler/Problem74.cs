using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem74
    {
        static Dictionary<int, SortedSet<int>> primeMap;

        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                //BruteForce(8).ShouldEqual(3);
                GetFactorial(145).ShouldEqual(145);
            };

            It should_get_result = () => Utils.PrintResult(() => BruteForce(1000000));

        }

        static int BruteForce(int limit)
        {
            int result = 0;

            var map = new Dictionary<long, Dictionary<long, int>>();

            for (int i = 69; i < limit; i++)
            {
                if(!map.ContainsKey(i))
                {
                    map.Add(i, new Dictionary<long, int>());
                }

                var f = GetFactorial(i);
                var gotvalue = false;
                while (!map[i].ContainsKey(f) && f != i)
                {
                    map[i].Add(f, 0);
                    if (map.ContainsKey(f))
                    {
                        foreach (var pair in map[f])
                        {
                            if(map[i].ContainsKey(pair.Key))
                            {
                                break;
                            }
                            map[i].Add(pair.Key, 0);
                        }
                        break;
                    }
                    f = GetFactorial(f);
                }

                if(map[i].Count == 59)
                {
                    result ++;
                }

            }

            

            return result;
        }

        static long GetFactorial(long num)
        {
            return MathUtils.ConvertToDigits(num).Select(MathUtils.Factorial).Sum();
        }
    }
}