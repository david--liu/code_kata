using System;
using System.Collections.Generic;
using System.Numerics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem65
    {
        static List<int> list = new List<int>();

        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                GetFactor(1).ShouldEqual(2);
                GetFactor(2).ShouldEqual(1);
                GetFactor(3).ShouldEqual(2);
                GetFactor(4).ShouldEqual(1);
                GetFactor(9).ShouldEqual(6);
                GetFactor(10).ShouldEqual(1);
            };

            It should_get_convergent = () =>
            {
                GetConvergent(10).ShouldEqual(1457);
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static BigInteger GetConvergent(int i)
        {
            var nums = new BigInteger[101];
            for (int j = 0; j < i; j++)
            {
                
                if (j == 0)
                {
                    nums[j] = 2;
                }
                else if(j == 1)
                {
                    nums[j] = 3;
                }
                else
                {
                    var factor = GetFactor(j + 1);
                    nums[j] = factor * nums[j - 1] + nums[j - 2];
                }
            }

            return nums[i - 1];
        }

        static double BruteForce()
        {
            var s = GetConvergent(100).ToString();
            Console.Out.WriteLine(s);
            return s.Select(x => char.GetNumericValue(x)).Sum();
        }

        static int GetFactor(int seq)
        {
            if (list.Count == 0)
                PopulateFactors();
            return list[seq - 1];
        }

        static void PopulateFactors()
        {
            var k = 0;
            for (var i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    list.Add(2);
                }
                else
                {
                    if ((i + 1)%3 == 0)
                    {
                        k += 2;
                        list.Add(k);
                    }
                    else
                    {
                        list.Add(1);
                    }
                }
            }
        }

        class Convergent
        {
            BigInteger num;
            BigInteger div;

            public Convergent(BigInteger num, BigInteger div)
            {
                this.num = num;
                this.div = div;
            }

            public BigInteger Num
            {
                get { return num; }
            }

            public BigInteger Div
            {
                get { return div; }
            }
        }
    }
}