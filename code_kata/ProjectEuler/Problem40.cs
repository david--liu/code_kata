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
            for (int i = 10; i < 500000; i++)
            {
                var digits = MathUtils.ConvertToDigits(i);
                result = Result(result, digits, pointer, 100);
                result = Result(result, digits, pointer, 1000);
                result = Result(result, digits, pointer, 10000);
                result = Result(result, digits, pointer, 100000);
                result = Result(result, digits, pointer, 1000000);
                
                pointer += digits.Count;
                if(pointer > 1000000)
                    break;
            }
            return result;
        }

        static int Result(int result, List<int> digits, int pointer, int number)
        {
            if (pointer < number && (pointer + digits.Count) >= number)
            {
                result *= digits[number - pointer - 1];
            }
            return result;
        }
    }
}
