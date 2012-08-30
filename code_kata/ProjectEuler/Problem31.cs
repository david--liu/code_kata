using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem31
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It should_brute_force = () =>
                Console.Out.WriteLine(BruteForce());

            It should_use_dynamic_programming = () =>
                Console.Out.WriteLine(DynamicProgramming());
        }

        static int DynamicProgramming()
        {
            int target = 200;
            int[] coinSizes = { 1, 2, 5, 10, 20, 50, 100, 200 };
            int[] ways = new int[target + 1];
            ways[0] = 1;

            for (int i = 0; i < coinSizes.Length; i++)
            {
                for (int j = coinSizes[i]; j <= target; j++)
                {
                    ways[j] += ways[j - coinSizes[i]];
                }
            }

            for (int i = 0; i < 201; i++)
            {
                Console.Out.WriteLine(i + " : " +ways[i]);
            }

            return ways[200];
        }

        static int BruteForce()
        {
            var target = 200;
            var ways = 0;

            for (var a = target; a >= 0; a -= 200)
            {
                for (var b = a; b >= 0; b -= 100)
                {
                    for (var c = b; c >= 0; c -= 50)
                    {
                        for (var d = c; d >= 0; d -= 20)
                        {
                            for (var e = d; e >= 0; e -= 10)
                            {
                                for (var f = e; f >= 0; f -= 5)
                                {
                                    for (var g = f; g >= 0; g -= 2)
                                    {
                                        ways++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ways;
        }
    }
}