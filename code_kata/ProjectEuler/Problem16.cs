using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem16
    {
        public abstract class concern : Observes
        {

        }

        public class when_computing_2_pow_1000 : concern
        {
            It should_get_26_for_15 = () =>
            {
                GetSumOfPowOfTwo(15).ShouldEqual(26);
            };

            It should_get_the_correct_result = () =>
                Console.Out.WriteLine(GetSumOfPowOfTwo(1000));

            static int GetSumOfPowOfTwo(int pow)
            {
                var list = new List<int> {1};
                for (int i = 1; i <= pow; i++)
                {
                    bool hasTen = false;
                    int j = 0;
                    while (j < list.Count)
                    {
                        var value = list[j]*2;
                        value += hasTen ? 1 : 0;
                        hasTen = value > 9;
                        if (hasTen)
                        {
                            list[j] = value - 10;
                            if(j == list.Count -1)
                            {
                                list.Add(0);
                            }
                        }
                        else list[j] = value;

                        j++;
                    }
                }

                Print(list);

                return list.Sum(x => x);

            }

            static void Print(List<int> list)
            {
                list.Reverse();
                foreach (var chr in list)
                {
                    Console.Out.Write(chr);
                }

                Console.WriteLine();

            }
        }
    }
}
