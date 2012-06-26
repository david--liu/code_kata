using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem23
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_abundant_number_is_12 = () =>
            {
                for (int i = 1; i < 13; i++)
                {
                    if (GetSumOfDivisors(i) > i)
                        i.ShouldEqual(12);
                    
                }
            };

            It should_get_the_correct_result = () =>
            {
                var map = GetAllAbundantNumbers();
                var allPossible = new Dictionary<int, object>();
                int sum = 0;

                foreach (var key1 in map.Keys)
                {
                    foreach (var key2 in map.Keys)
                    {
                        var key = key1 + key2;
                        if(!allPossible.ContainsKey(key))
                            allPossible.Add(key, null);
                    }
                }

                for (int i = 1; i < 28123; i++)
                {
                    if (!allPossible.ContainsKey(i))
                        sum += i;
                }

                Console.Out.WriteLine(sum);

            };

            static Dictionary<int, object> GetAllAbundantNumbers()
            {
                var result = new Dictionary<int, object>();
                for (int i = 12; i < 28123; i++)
                {
                    if(GetSumOfDivisors(i) > i)
                    {
                        result.Add(i, null);
                    }
                }

                return result;
            }

            static int GetSumOfDivisors(int number)
            {
                var list = new List<int>();
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        list.Add(i);
                        if (!list.Contains(number / i))
                        {
                            list.Add(number / i);
                        }

                    }
                }

                return list.Sum(x => x) + 1;
            }
 
        }
    }
}
