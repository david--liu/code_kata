using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem39
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());

        }
        // a < b < c
        // a + b > c
        // a2 + b2 = c2
        // a + b + c <= 1000

        static int BruteForce()
        {
            var map = new Dictionary<int, int>();
            for (int a = 0; a < 1000 /3; a++)
            {
                for (int b = a + 1; b < 1000/2; b++)
                {
                    for (int c = b + 1; c < 1000/2; c++)
                    {
                        if(IsTriangle(a, b, c))
                        {
                            var sum = a + b + c;
                            if(!map.ContainsKey(sum))
                            {
                                map.Add(sum, 0);
                            }
                            map[sum] ++;
                        }
                    }
                }
            }
            var max = map.Max(obj => obj.Value);
            return map.First(v => v.Value == max).Key;
        }

        static bool IsTriangle(int a, int b, int c)
        {
            return a*a + b*b == c*c;
        }
    }
}
