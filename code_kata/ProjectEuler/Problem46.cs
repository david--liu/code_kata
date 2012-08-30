using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem46
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                CanBeWrittenByAPrimeAndTwiceASquare(33).ShouldBeTrue();
                CanBeWrittenByAPrimeAndTwiceASquare(31).ShouldBeTrue();
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }


        static long BruteForce()
        {
            long i = 33;
            while (CanBeWrittenByAPrimeAndTwiceASquare(i))
            {
                i = i + 2;
            }

            return i;
        }

        static bool CanBeWrittenByAPrimeAndTwiceASquare(long l)
        {
            for (long i = 0; i < Math.Sqrt(Convert.ToDouble(l)/2); i++)
            {
                if(MathUtils.IsPrime(l - 2 * i * i))
                    return true;
            }
            return false;
        }
    }
}
