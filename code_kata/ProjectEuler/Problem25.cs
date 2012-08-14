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
}
