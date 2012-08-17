using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem41
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                new Pandigital(2).List.ShouldContain(12);
                new Pandigital(2).List.ShouldContain(21);
            };
            It should_generate_pandigital = () =>
            {
                new Pandigital(3).List.ShouldContain(123);
                new Pandigital(3).List.ShouldContain(213);
                new Pandigital(3).List.ShouldContain(312);
                new Pandigital(3).List.ShouldContain(321);
                new Pandigital(3).List.ShouldContain(132);
                new Pandigital(3).List.ShouldContain(231);
            };

        }

        public class when_generate_nine_digits : concern
        {
            It check = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static int BruteForce()
        {
            for (int i = 0; i < 7; i++)
            {
                foreach (var num in new Pandigital(7 - i).List.OrderByDescending(o => o))
                {
                    if (MathUtils.IsPrime(num))
                    {
                        return num;
                    }
                }
            }
            
            return 0;
        }

        class Pandigital
        {
            private List<int[]> list = new List<int[]>();
            public Pandigital(int max)
            {
                var digits = new int[max];
                for (int i = 1; i <= max; i++)
                {
                    digits[i - 1] = i;
                    var item = new int[max];
                    item[0] = i;
                    list.Add(item);
                }

                for (int i = 1; i < max; i++)
                {
                    PopulateList(digits, i, max);
                }



            }

            void PopulateList(int[] digits, int i, int max)
            {
                var tempList = new List<int[]>();
                foreach (var num in list)
                {
                    var ints = from n in digits
                               where !num.Contains(n)
                               select n;
                    foreach (var j in ints)
                    {
                        var temp = new int[max];
                        for (int k = 0; k < i; k++)
                        {
                            temp[k] = num[k];
                        }

                        temp[i] = j;

                        tempList.Add(temp);
                    }
                }

                list = tempList;
            }

            public List<int> List
            {
                get { return list.Select(o => MathUtils.ConvertToNumber(o)).ToList(); }
            }
        }
    }
    }

    

 
