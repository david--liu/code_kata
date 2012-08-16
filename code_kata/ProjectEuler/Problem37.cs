using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem37
    {
        public abstract class concern : Observes
        {
        }

        public class when_check_is_truncatable_prime : concern
        {
            It should_return_true_for_known_number = () =>
            {
                IsTruncatablePrime(3797).ShouldBeTrue();
                IsTruncatablePrime(3798).ShouldBeFalse();
            };
        }

        public class when_solving : concern
        {
            It should_get_result = () =>
                Console.Out.WriteLine(BruteForce());
        }

        static int BruteForce()
        {
            int count = 0;
            int result = 0;
            int number = 11;
            while (count < 11)
            {
                if(IsTruncatablePrime(number))
                {
                    result += number;
                    count++;
                }

                number += 2;
            }

            return result;
        }

        static bool IsTruncatablePrime(int number)
        {
            if (!MathUtils.IsPrime(number))
            {
                return false;
            }
            var digits = MathUtils.ConvertToDigits(number);
            var count = digits.Count;
            for (var i = 1; i < count; i++)
            {
                var newNum = new int[count - i];
                for (var j = 0; j < count - i; j++)
                {
                    newNum[j] = digits[j];
                }

                if (!MathUtils.IsPrime(MathUtils.ConvertToNumber(newNum)))
                    return false;

                for (var j = i; j < count; j++)
                {
                    newNum[j - i] = digits[j];
                }

                if (!MathUtils.IsPrime(MathUtils.ConvertToNumber(newNum)))
                    return false;
            }

            return true;
        }
    }
}