using System;
using System.Collections.Generic;
using System.Diagnostics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem35
    {
        public abstract class concern : Observes
        {

        }

        public class when_check_cicular_prime : concern
        {
            It should_return_true = () =>
            {
                List<int> list;
                IsCicularPrime(97, out list).ShouldBeTrue();
                IsCicularPrime(197, out list).ShouldBeTrue();
                IsCicularPrime(87, out list).ShouldBeFalse();
            };

            It should_get_known_result = () =>
            {
                GetResult(100).ShouldEqual(13);
            };
            It should_get_result = () =>
            {
                var stopwatch = Stopwatch.StartNew();
                Console.Out.WriteLine(GetResult(1000000));
                Console.Out.WriteLine(stopwatch.ElapsedMilliseconds + " ms.");
            };

            static int GetResult(int number)
            {
                var result = new SortedSet<int>();
                for (int i = 3; i < number; i = i + 2)
                {
                    if(result.Contains(i))
                        continue;

                    List<int> list;
                    if(IsCicularPrime(i, out list))
                    {
                        foreach (var element in list)
                        {
                            result.Add(element);
                        }
                    }
                }

                return result.Count + 2;
            }


            static bool IsCicularPrime(int number, out List<int> list)
            {
                list = new List<int>();
                if(!MathUtils.IsPrime(number))
                {
                    return false;
                }

                list.Add(number);

                var digits = MathUtils.ConvertToDigits(number);

                if (ContainsEvenOrFile(digits))
                    return false;

                var count = digits.Count;
                for (int i = 1; i < count; i++)
                {
                    if(digits[i] % 2 == 0)
                    {
                        return false;
                    }

                    double newNumber = 0;
                    for (int j = 0; j < count; j++)
                    {
                        var index = i + j;
                        if(index > count -1)
                        {
                            index = index - count;
                        }
                        newNumber += digits[index] * Math.Pow(10, count - j -1);
                    }

                    var num = Convert.ToInt32(newNumber);
                    if(!MathUtils.IsPrime(num))
                    {
                        return false;
                    }

                    list.Add(num);

                }
                return true;
            }

            static bool ContainsEvenOrFile(List<int> digits)
            {
                return digits.Any(o => o == 5 || o%2 == 0);
            }
        }
    }
}
