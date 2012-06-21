using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem21
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It should_return_284_for_amicalble_of_220 = () =>
            {
                GetSecondAmicableNumbers(220).ShouldEqual(284);
            };

            It should_return_correct_result = () =>
                Console.Out.WriteLine(GetSumOfAmicableNumber(10000));

            static int GetSumOfAmicableNumber(int number)
            {
                var list = new List<int>();
                for (int i = 1; i <= number; i++)
                {
                    if(list.Contains(i))
                        continue;
                    
                    int secondAmicableNumbers = GetSecondAmicableNumbers(i);
                    if( secondAmicableNumbers != 0 )
                    {
                        list.Add(i);
                        list.Add(secondAmicableNumbers);
                    }
                }
                return list.Sum(x => x);
            }

            static int GetSecondAmicableNumbers(int number)
            {
                int sumOfAmicableNumber = GetSumOfDivisors(number);
                if (number != sumOfAmicableNumber && number == GetSumOfDivisors(sumOfAmicableNumber))
                {
                    return sumOfAmicableNumber;
                }
                return 0;
            }

            static int GetSumOfDivisors(int number)
            {
                var list = new List<int>();
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if(number % i == 0)
                    {
                        list.Add(i);
                        if(!list.Contains(number / i))
                        {
                            list.Add(number/i);
                        }

                    }
                }

                return list.Sum(x => x) + 1;
            }
        }
    }
}
