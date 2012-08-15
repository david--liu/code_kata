using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem28
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                GetSumOfDiagonals(5).ShouldEqual(101);
            };

            It should_get_the_result = () =>
            {
                Console.Out.WriteLine(GetSumOfDiagonals(1001));
            };
        }

        static int GetSumOfCornerPoints(int dimension)
        {
            return 4*dimension*dimension - 6*(dimension - 1);
        }

        static int GetSumOfDiagonals(int dimension)
        {
            int result = 0;
            for (var i = 3; i <= dimension; i = i + 2)
            {
                result += GetSumOfCornerPoints(i);
            }

            return result + 1;
        }
    }
}
