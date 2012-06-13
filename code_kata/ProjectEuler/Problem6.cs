using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem6
    {
        public abstract class concern : Observes
        {

        }

        public class when_finding_the_difference_between_the_sum_of_square_and_the_square_of_the_sum : concern
        {
            It should_return_2640_for_number_range_1_to_10 = () =>
                SquareAndSum.GetDifferenceBetweenSumOfSquareAndSquareOfTheSum(1, 10).ShouldEqual(2640);

            It should_get_the_correct_result = () =>
                Console.Out.WriteLine(SquareAndSum.GetDifferenceBetweenSumOfSquareAndSquareOfTheSum(1, 100));
        }
    }

    class SquareAndSum
    {
        public static long GetDifferenceBetweenSumOfSquareAndSquareOfTheSum(int from, int to)
        {
            double sumOfSquare = 0;
            double sum = 0;
            for (int i = from; i <= to; i++)
            {
                sumOfSquare += Math.Pow(i, 2);
                sum += i;
            }

            return Math.Abs((long) (sumOfSquare - Math.Pow(sum, 2)));
        }
    }
}
