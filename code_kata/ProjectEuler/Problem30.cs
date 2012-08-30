using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem30
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It should_get_correct_known_resule = () =>
            {
                GetSumOfPowerOfDigits(4).ShouldEqual(19316);
            };

            It should_get_result = () =>
                Console.Out.WriteLine(GetSumOfPowerOfDigits(5));

        }

        static double GetSumOfPowerOfDigits(int power)
        {
            double result = 0;
            for (double i = 2; i < Math.Pow(10, power + 1) * power; i++)
            {
                double pow = 0;
                foreach (var chr in Convert.ToString(i))
                {
                    pow += Math.Pow(Char.GetNumericValue(chr), power);
                }
                if(i == pow)
                {
                    Console.Out.WriteLine(i);
                    result += i;
                }
                
            }
            return result;
        }
    }
}
