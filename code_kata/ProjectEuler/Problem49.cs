using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem49
    {
        public abstract class concern : Observes
        {
        }

        public class when_check_permutations : concern
        {
            It should_check_equal = () =>
            {
                var permutation1 = new Permutation(new int[3] {1, 2, 3});
                var permutation2 = new Permutation(new int[3] {3, 2, 1});
                permutation1.ShouldEqual(permutation2);
                permutation1.GetHashCode().ShouldEqual(permutation2.GetHashCode());
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static string BruteForce()
        {
            var map = new Dictionary<Permutation, List<int>>();
            for (var i = 1000; i < 10000; i++)
            {
                if (MathUtils.IsPrime(i))
                {
                    var digits = MathUtils.ConvertToDigits(i);
                    {
                        var permutation = new Permutation(digits);
                        if (!map.ContainsKey(permutation))
                        {
                            map.Add(permutation, new List<int>());
                        }
                        var value = map[permutation];
                        value.Add(i);
                    }
                }
            }

            foreach (var result in map.Where(x => x.Value.Count >= 3))
            {
                var value = result.Value;
                if (value.Count == 3)
                {
                    if (IsArithmeticSequence(value))
                    {
                        Print(value);
                    }
                }
                else
                {
                    for (int i = 0; i < value.Count - 3; i++)
                    {
                        for (int j = i + 1; j < value.Count - 1; j++)
                        {
                            
                            for (int k = j + 1; k < value.Count; k++)
                            {
                                var list = new List<int>();
                                list.Add(value[i]);
                                list.Add(value[j]);
                                list.Add(value[k]);
                                if (IsArithmeticSequence(list))
                                {
                                    Print(list);
                                }
                            }
                        }
                    }
                }
            }

            return "";
        }

        static void Print(List<int> list)
        {
            for (var i = 0; i < 3; i++)
            {
                Console.Out.Write(list[i]);
            }
            Console.WriteLine();
        
        }

        static bool IsArithmeticSequence(List<int> list)
        {
            return list[2] - list[1] == list[1] - list[0];
        }

        
    }
}