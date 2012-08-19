using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem52
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
            for (var i = 0; i < int.MaxValue; i++)
            {
                if (IsOk(i))
                    return i;
            }
            return 0;
        }

        static bool IsOk(int num)
        {
            var digits = MathUtils.ConvertToDigits(num);
            var count = digits.Distinct().Count();
            if(count == 0 || digits[0] > 1)
            {
                return false;
            }
            if (count > 1 && digits[1] > 6)
                return false;
            for (int i = 2; i < 7; i++)
            {
                
                if (MathUtils.ConvertToDigits(num * i).Union(digits).Count() > count)
                    return false;
            }
            return true;
        }
    }
}