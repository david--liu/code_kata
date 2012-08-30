using System;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem72
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {

            It should_get_correct_result = () =>
                Utils.PrintResult(() => BruteForce());

        }

 


        static long BruteForce()
        {
            int limit = 1000000;
            int[] phi = Enumerable.Range(0, limit + 1).ToArray();
            long result = 0;
            for (int i = 2; i <= limit; i++)
            {
                if (phi[i] == i)
                {
                    for (int j = i; j <= limit; j += i)
                    {
                        phi[j] = phi[j] / i * (i - 1);
                    }
                }
                result += phi[i];
            }
            

            return result;
        }
    }
}
