using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem73
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
                                           Utils.PrintResult(() => BruteForce(12000));
                                       };
           
        }

        static int BruteForce(int limit)
        {
            int result = 0;


            for (int i = 2; i < limit /2; i++)
            {
                for (int j = i * 2 + 1; j < 3*i && j <= limit ; j++)
                {
                    if (MathUtils.Gcd(i, j) == 1) result++;
                }
            }


            return result;
        }
    }
}
