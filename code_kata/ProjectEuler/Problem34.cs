using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem34
    {
        public abstract class concern : Observes
        {

        }

        public class when_check_factorial : concern
        {
            It first_observation = () =>
                MathUtils.Factorial(5).ShouldEqual(120);

        }

        public class when_convert_to_digits : concern
        {
            It should_convert = () =>
                MathUtils.ConvertToDigits(123)[2].ShouldEqual(3);
        }

        public class when_solving : concern
        {
            It should_get_result = () =>
                BruteForce();
        }

        static void BruteForce()
        {
            int result = 0;
            for (int i = 3; i < MathUtils.Factorial(10); i++)
            {
                if( i == GetSumOfFactorial(i))
                {
                    Console.Out.WriteLine(string.Format("Got {0}", i));
                    result += i;
                }
            }
            Console.Out.WriteLine(result);
        }

        static int GetSumOfFactorial(int number)
        {
            int result = 0;
            foreach (var i in MathUtils.ConvertToDigits(number))
            {
                result += MathUtils.Factorial(i);
            }
            return result;
        }
    }
}
