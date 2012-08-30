using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem5
    {
        public abstract class concern : Observes
        {

        }

        public class when_find_the_smallest_number_can_divide : concern
        {
            It should_return_2520_for_range_1_to_10 = () =>
                GetSmallestDividableNumber(1, 10).ShouldEqual(2520);

            It get_the_correct_result_for_range_1_to_20 = () =>
                Console.Out.WriteLine(GetSmallestDividableNumber(1, 20));

            static long GetSmallestDividableNumber(int from, int to)
            {
                long result = 1;
                var list = new List<int>();
                for (int i = from; i <= to; i++)
                {
                    if (result % i != 0)
                    {
                        result *= i;
                        foreach (var mod in list.FindAll(x => i%x == 0))
                        {
                            result /= mod;
                            list.Remove(mod);
                        }
                        list.Add(i);
                    }
                }

                return result;
            }
        }
    }
}
