using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem40
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static int BruteForce()
        {
            int pointer = 9;
            int result = 1*1;
            int i = 10;
            while (pointer < 1000000)
            {
                var digits = MathUtils.ConvertToDigits(i);
                var count = digits.Count;
                result = Result(result, digits, pointer, 100, count);
                result = Result(result, digits, pointer, 1000, count);
                result = Result(result, digits, pointer, 10000, count);
                result = Result(result, digits, pointer, 100000, count);
                result = Result(result, digits, pointer, 1000000, count);

                
                pointer += count;
                i++;
            }
            return result;
        }

        static int Result(int result, List<int> digits, int pointer, int number, int count)
        {
            if (pointer < number && (pointer + count) >= number)
            {
                result *= digits[number - pointer - 1];
            }
            return result;
        }
    }
}
