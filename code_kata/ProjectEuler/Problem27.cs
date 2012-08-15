using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem27
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                int most = 0;
                int numA = 0;
                int numB = 0;
                for (int i = -999; i <= 999; i++)
                {
                    for (int j = -999; j <= 999; j++)
                    {
                        var mostPrimes = GetMostPrimes(i, j);
                        if(mostPrimes > most)
                        {
                            most = mostPrimes;
                            numA = i;
                            numB = j;
                        }
                    }
                }

                Console.Out.WriteLine(numA * numB);
            };

        }

        public static int GetMostPrimes(int numA, int numB)
        {
            int n = 0;
            while (MathUtils.IsPrime(Math.Abs(n * n + n * numA + numB)))
            {
                n ++;
            }

            return n + 1;
        }

    }
}
