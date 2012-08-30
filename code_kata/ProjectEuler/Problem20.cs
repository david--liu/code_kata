using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem20
    {
        public abstract class concern : Observes
        {

        }

        public class when_figuring_problem_20 : concern
        {
            It should_get_correct_number = () =>
            {
                GetNumber(5).ShouldEqual(3);
                Console.WriteLine(GetNumber(99));
            };

            static int GetNumber(int count)
            {
                var list = new List<int> { 1 };
                for (int i = count + 1; i >= 2; i--)
                {
                    int j = 0;
                    int tens = 0;
                    while (j < list.Count)
                    {
                        var value = list[j] * (i -1);
                        value += tens;
                        tens = value / 10;
                        if (tens > 0)
                        {
                            list[j] = value - tens * 10;
                            if (j == list.Count - 1)
                            {
                                list.Add(0);
                            }
                        }
                        else list[j] = value;

                        j++;
                    }
                }


                return list.Sum(x => x);
            }

        }
    }
}
