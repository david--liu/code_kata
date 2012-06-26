using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem25
    {
        public abstract class concern : Observes
        {

        }

        public class when_sum_using_mathutils : concern
        {
            It should_get_correct_result = () =>
            {
                MathUtils.Sum(new List<int> { 9 }, new List<int> { 8 }).Count.ShouldEqual(2);
                MathUtils.Sum(new List<int> { 9 }, new List<int> { 8 })[0].ShouldEqual(7);
                MathUtils.Sum(new List<int> { 9 }, new List<int> { 8 })[1].ShouldEqual(1);
            };
            It should_get_correct_result2 = () =>
            {
                MathUtils.Sum(new List<int> { 9,9 }, new List<int> { 8 })[0].ShouldEqual(7);
                MathUtils.Sum(new List<int> { 9,9 }, new List<int> { 8 })[1].ShouldEqual(0);
                MathUtils.Sum(new List<int> { 9,9 }, new List<int> { 8 })[2].ShouldEqual(1);
            };

            It should_get_correct_result_1000th = () =>
            {
                var previous1 = new List<int> {1};
                var previous2 = new List<int> {1};
                int i = 2;
                while (previous1.Count < 1000)
                {
                    var result = MathUtils.Sum(previous1, previous2);
                    previous2 = previous1;
                    previous1 = result;
                    i++;
                }
                Console.WriteLine(i);

            };


        }


    }

    public static class MathUtils
    {
            public static List<int> Sum(List<int> list1, List<int> list2)
            {
                var result = new List<int>();

                var max = list1.Count > list2.Count ? list1.Count : list2.Count;

                for (int i = 0; i < max; i++)
                {
                    result.Add((list2.Count > i ? list2[i] : 0) + (list1.Count > i ? list1[i] : 0));
                }

                for (int i = 0; i < max; i++)
                {
                    if(result[i] >= 10)
                    {
                        result[i] -= 10;
                        if(i == max -1)
                        {
                            result.Add(1);
                        }
                        else
                        {
                            result[i + 1] += 1;
                        }
                    }
                }

                return result;

            }

    }
}
