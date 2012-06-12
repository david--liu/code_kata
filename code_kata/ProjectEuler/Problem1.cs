using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    
    public class Problem1
    {
        public abstract class concern : Observes
        {

        }

        public class when_suming_natual_number_3_or_5_below_1000 : concern
        {
            Because b = () =>
            {
                for (int i = 1; i < 1000; i++)
                {
                    if(i % 3 == 0 || i % 5 == 0)
                        result += i;
                    
                }
            };

            It should_get_correct_result = () =>
                Console.Out.WriteLine(result);
            static int result;

                
        }
    }
}
