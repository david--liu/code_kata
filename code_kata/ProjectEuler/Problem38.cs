using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem38
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It should_return_true_for_known_number = () =>
            {
                int result;
                IsConcatenatePandigital(9, out result).ShouldBeTrue();
                result.ShouldEqual(918273645);
            };

        }

        public class when_solving : concern
        {
            It should_get_result = () =>
            {
                Console.Out.WriteLine(BruteForce());
            };
        }

        static int BruteForce()
        {
            int result = 0;
            for (int i = 0; i < 10000; i++)
            {
                if(Convert.ToString(i).StartsWith("9"))
                {
                    int temp;
                    if(IsConcatenatePandigital(i, out temp))
                    {
                        result = result < temp ? temp : result;
                    }
                }
            }

            return result;
        }


        static bool IsConcatenatePandigital(int number, out int result)
        {
            int i = 1;
            var list = new List<int>();

            while (list.Count < 9)
            {
                list.AddRange(MathUtils.ConvertToDigits(number * i));
                i ++;
            }

            result = 0;
            var isConcatenatePandigital = list.Count == 9 && list.Contains(1) && list.Contains(2) && list.Contains(3) &&
                list.Contains(4) && list.Contains(5) && list.Contains(6) && list.Contains(7) && list.Contains(8) &&
                    list.Contains(9);

            if(!isConcatenatePandigital)
                return false;

            result = MathUtils.ConvertToNumber(list.ToArray());
            return true;

        }
    }
}
