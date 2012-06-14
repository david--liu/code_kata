using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem10
    {
        public abstract class concern : Observes
        {

        }

        public class when_sum_all_prime_numbers_below_2million : concern
        {
            It should_get_correct_result = () =>
                Console.Out.WriteLine(PrimeNumber.GetSumOfPrimeNumberBelow(2000000));

        }
    }
}
