using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem55
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It should_check_is_palindromic  = () =>
            {
                IsPalindromic(new List<int>{1,2,2,1}).ShouldBeTrue();
                IsPalindromic(new List<int>{1,2,3,1}).ShouldBeFalse();
                IsPalindromic(new List<int>{1,2,3,2,1}).ShouldBeTrue();
            };

            It should_convert_number_to_digit_list = () =>
            {
                var list = MathUtils.ConvertToDigits(10218);
                list.Count.ShouldEqual(5);
                list[0].ShouldEqual(1);
                list[1].ShouldEqual(0);
                list[2].ShouldEqual(2);
                list[3].ShouldEqual(1);
                list[4].ShouldEqual(8);
            };

            It should_get_correct_result = () =>
                Utils.PrintResult(() => BruteForce());

        }

        static int BruteForce()
        {
            int result = 0;
            for (int i = 0; i < 10000; i++)
            {
                if (IsLychrelNumber(i))
                    result++;
            }

            return result;
        }


        static bool IsLychrelNumber(double num)
        {
            var list = MathUtils.ConvertToDigits(num);
            for (int i = 0; i < 50; i++)
            {
                list = MathUtils.Sum(list, ReverseList(list));
                if(IsPalindromic(list))
                    return false;
            }

            return true;
        }


        static List<T> ReverseList<T>(List<T> list)
        {
            var newList = new List<T>(list);
            newList.Reverse();
            return newList;
        }

        static bool IsPalindromic(List<int> list)
        {
            var count = list.Count;
            for (int i = 0; i < count / 2; i++)
            {
                if (list[i] != list[count -1 - i])
                    return false;
            }

            return true;
        }
    }
}
