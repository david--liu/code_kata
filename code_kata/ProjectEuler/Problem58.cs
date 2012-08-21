using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem58
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());

            It should_check_is_diagonal = () =>
            {
                IsDiagonal(13, 5).ShouldBeTrue();
                IsDiagonal(17, 5).ShouldBeTrue();
                IsDiagonal(21, 5).ShouldBeTrue();

                IsDiagonal(31, 7).ShouldBeTrue();
                IsDiagonal(37, 7).ShouldBeTrue();
                IsDiagonal(43, 7).ShouldBeTrue();


            };

        }

        static long BruteForce()
        {
            double diagonalCount = 3;
            long len = 3;
            while (diagonalCount / (2*len + 1) >= 0.1d)
            {

                len += 2;

                var sqr = len*len;
                for (long j = 1; j <= 3; j++)
                {
                    if(MathUtils.IsPrime(sqr - j*(len - 1)))
                    {
                       diagonalCount++;
                    }
                }


            }

            return len;
        }

        static bool IsDiagonal(long num, long len)
        {
            return num == (len - 2)*(len - 2) + len - 1 ||
                num == (len - 1)*(len - 1) + 1 ||
                    num == len*len - len + 1;
        }
    }
}
