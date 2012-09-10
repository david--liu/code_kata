using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem75
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            private It should_bruteForce = () => Utils.PrintResult(() => BruteForce());
        }

        private static int BruteForce()
        {
            //read Pythagorean Triplets on wikipedia

            var map = new Dictionary<int, int>();
            var sqrt = Math.Sqrt(750000);

            for (var m = 2; m < sqrt; m++)
            {
                for (var n = 1; n < m; n++)
                {
                    if ((m + n)%2 > 0 && MathUtils.Gcd(m, n) == 1)
                    {
                        var a = m*m - n*n;
                        var b = 2*m*n;
                        var c = m*m + n*n;

                        var d = a + b + c;
                        while (d <= 1500000)
                        {
                            if (!map.ContainsKey(d))
                            {
                                map.Add(d, 0);
                            }
                            map[d]++;
                            d += a + b + c;
                        }
                    }
                }
            }

            return map.Count(x => x.Value == 1);
        }
    }
}