using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem48
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                Utils.PrintResult(() => BruteForce(10));
                Utils.PrintResult(() => BruteForce(1000));

            };

        }

        static string BruteForce(int num)
        {
            long mod = 10000000000;
            long result = 0;
            for (int i = 1; i <= num; i++)
            {
                long temp = i;
                for (int j = 1; j <i; j++)
                {
                    temp *= i;
                    if (temp >= long.MaxValue / 1000)
                    {
                        temp %= mod;
                    }
                }

                result += temp;
                result %= mod;
            }

            return result.ToString();
        }
    }
}
