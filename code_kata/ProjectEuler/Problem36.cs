using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem36
    {
        public abstract class concern : Observes
        {

        }

        public class when_ConvertoNumber : concern
        {
            It first_observation = () =>
                MathUtils.ConvertToNumber(new int[3] {1, 2, 3}).ShouldEqual(123);

        }

        public class when_get_next_palindromics : concern
        {
            It should_get_one_palindromics_for_plus_one_digit = () =>
            {
                var list = GetNextPalindromics(new List<int[]> {new int[1] {1}}, 1);
                list.ShouldContain(new int[2]{1, 1});
            };

            It should_get_all_palindromics_for_plus_one_digit = () =>
            {
                var list = GetNextPalindromics(new List<int[]> { new int[2] { 1, 1 } }, 2);
                list.ShouldContain(new int[3] { 1, 0, 1 });
                list.ShouldContain(new int[3] { 1, 1, 1 });
                list.ShouldContain(new int[3] { 1, 2, 1 });
                list.ShouldContain(new int[3] { 1, 3, 1 });
                list.ShouldContain(new int[3] { 1, 4, 1 });
                list.ShouldContain(new int[3] { 1, 5, 1 });
                list.ShouldContain(new int[3] { 1, 6, 1 });
                list.ShouldContain(new int[3] { 1, 7, 1 });
                list.ShouldContain(new int[3] { 1, 8, 1 });
                list.ShouldContain(new int[3] { 1, 9, 1 });
                list.Count.ShouldEqual(10);
            };

        }

        public class when_check_is_binary_palindromic : concern
        {
            It should_return_true = () =>
            {
                IsBinaryPalindromic(3).ShouldBeTrue();
                IsBinaryPalindromic(585).ShouldBeTrue();
            };

            It should_return_false = () =>
            {
                IsBinaryPalindromic(4).ShouldBeFalse();
            };
        }

        public class solve: concern
        {
            It should_get_result = () =>
            {
                Console.Out.WriteLine(BruteForce());
            };
        }

        static int BruteForce()
        {
            int result = 0;

            var startList = new List<int[]>
            {
                new int[1] {1},
                new int[1] {2},
                new int[1] {3},
                new int[1] {4},
                new int[1] {5},
                new int[1] {6},
                new int[1] {7},
                new int[1] {8},
                new int[1] {9}
            };

            var tempList = startList;
            for (int i = 1; i <= 6; i++)
            {
                foreach (var number in tempList)
                {
                    var toNumber = MathUtils.ConvertToNumber(number);
                    if(IsBinaryPalindromic(toNumber))
                    {
                        Console.WriteLine("Got one: " + toNumber);
                        result += toNumber;
                    }
                }
                tempList = GetNextPalindromics(tempList, i);
            }

            return result;
        }

        static bool IsBinaryPalindromic(int toNumber)
        {
            var s = Convert.ToString(toNumber, 2);

            for (int i = 0; i <= s.Length /2; i++)
            {
                if(s[i] != s[s.Length - i - 1])
                {
                    return false;
                }

            }

            return true;
        }

        static List<int[]> GetNextPalindromics(List<int[]> numbers, int length)
        {
            var result = new List<int[]>();
            var index = length / 2;
            foreach (var number in numbers)
            {
                
                if(length % 2 == 0)
                {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        var newNumber = new int[length + 1];
                        for (int j = 0; j < index; j++)
                        {
                            newNumber[j] = number[j];
                        }

                        newNumber[index] = i;

                        for (int j = index; j < length; j++)
                        {
                            newNumber[j + 1] = number[j];
                        }

                        result.Add(newNumber);

                    }
                }
                else
                {
                    var newNumber = new int[length + 1];
                    for (int j = 0; j <= index; j++)
                    {
                        newNumber[j] = number[j];
                    }


                    for (int j = index; j < length; j++)
                    {
                        newNumber[j + 1] = number[j];
                    }

                    result.Add(newNumber);
                }
            }

            return result;
        }

          
    }
}
