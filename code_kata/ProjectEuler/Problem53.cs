using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem53
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                GetCombinatoricsGreaterThanOneMillion(23).ShouldBeGreaterThanOrEqualTo(1);

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static int BruteForce()
        {
            int result = 0;

            for (int i = 23; i <= 100; i++)
            {
                result += GetCombinatoricsGreaterThanOneMillion(i);
            }

            return result;
        }

        static int GetCombinatoricsGreaterThanOneMillion(int n)
        {
            int result = 0;
            

            for (int i = 1; i < n; i++)
            {
                var factorial = Factorial(n, i);
                if(factorial < 1000000)
                    continue;

                var l = Factorial(n - i, 1);
                
                if(factorial/l > 1000000)
                    result ++;
            }

            return result;
        }

        static double Factorial(int max, int min)
        {
            double result = 1;
            for (int i = min + 1; i <= max; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
