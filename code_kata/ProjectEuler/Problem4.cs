using System;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem4
    {
        public abstract class concern : Observes
        {
        }

        public class when_testing_a_number_is_palindromic : concern
        {
            It should_succeed = () =>
            {
                191.IsNumberPalindromic().ShouldEqual(true);
                192.IsNumberPalindromic().ShouldEqual(false);
                190.IsNumberPalindromic().ShouldEqual(false);
            };

            It get_the_correct_result = () =>
            {
                int result = 0;
                for (int i = 1; i < 1000; i++)
                {
                    for (int j = 1; j < 1000; j++)
                    {
                        var number = (i*j);
                        if(number.IsNumberPalindromic())
                        {

                            result = result > number ? result : number;
                        }
                    }
                }

                Console.Out.WriteLine(result);
            };
        }
    }

    public static class IntExtensions
    {
        public static bool IsNumberPalindromic(this int number)
        {
            return number == Convert.ToInt32(
                new string(Convert.ToString(number).Reverse().ToArray()));
        }
    }
}