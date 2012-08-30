using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem44
    {
        public abstract class concern : Observes
        {

        }

        public class when_get_pentagonal : concern
        {
            It first_observation = () =>
            {
                var pentagonal = GetPentagonal(3);
                pentagonal.ShouldContain(1);
                pentagonal.ShouldContain(5);
                pentagonal.ShouldContain(12);
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());

        }


        static int BruteForce()
        {
            var len = 2500;
            var pentagonal = GetPentagonal(len);
            var map = pentagonal.ToDictionary(x => x);
            //x = 3m + 1
            for (int i = 0; i < pentagonal.Length - 1; i++)
            {
                var small = pentagonal[i];
                var max = (small - 1)/3;
                max = len > max ? max : len;
                for (int j = i + 1; j < max; j++)
                {
                    var sub = pentagonal[j] - small;
                    if(map.ContainsKey(small + pentagonal[j]) && map.ContainsKey(sub))
                    {
                        return sub;
                    }
                }
            }

            return 0;
        }

        static int[] GetPentagonal(int len)
        {
            var result = new int[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = ((i + 1)*(3*i + 2))/2;
            }

            return result;
        }

    }
}
