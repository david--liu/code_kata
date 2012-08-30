using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem12
    {
        public abstract class concern : Observes
        {

        }

        public class when_finding_the_triangle_number : concern
        {
            It should_find_6_divisor_for_7th_number = () =>
            {
                GetNumberOfDivisors(28).ShouldEqual(6);
            };

            It should_get_correct_result = () =>
            {
                long triangle = 1;
                long i = 1;
                while (GetNumberOfDivisors(triangle) < 500)
                {
                    ++i;
                    triangle += i;

                }
                Console.Out.WriteLine(string.Format("i ={0}, triangle = {1}", i, triangle));

            };

            static int GetNumberOfDivisors(long value)
            {
                int total = 2;
                for (long i = 2; i < Math.Sqrt(value); i++)
                {
                    if (value % i == 0)
                        total = total + 2;
                    
                }

                return total;
            }
        }


    }
}
