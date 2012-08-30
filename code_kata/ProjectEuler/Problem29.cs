using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem29
    {
        static List<KeyValuePair<int, int>> map = new List<KeyValuePair<int, int>>();  
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It should_get_duplicate = () =>
            {
                map.Clear();
                CheckDuplicate(3, 12);
                map.ShouldContain(new KeyValuePair<int, int>(9, 6));
                map.ShouldContain(new KeyValuePair<int, int>(27, 4));
                map.ShouldContain(new KeyValuePair<int, int>(81, 3));
            };

            It should_brute_forece = () =>
            {
                var set = new SortedSet<double>();

                for (int a = 2; a <= 100; a++)
                {
                    for (int b = 2; b <= 100; b++)
                    {
                        double result = Math.Pow(a, b);
                        set.Add(result);
                    }
                }

                Console.Out.WriteLine(set.Count);
            };

            It should_get_rsult = () =>
            {
                map.Clear();
                int result = 0;
                for (int i = 2; i <= 100; i++)
                {
                    for (int j = 2; j <= 100; j++)
                    {
                            CheckDuplicate(i, j);
         
                    }
                }
                Console.Out.WriteLine(map.Distinct().Count());
            };


        }

        static void CheckDuplicate(int row, int pow)
        {


            for (int i = 2; i < pow; i++)
            {
                if(pow % i == 0)
                {
                    var key = Math.Pow(row, i);
                    if(key <=100)
                    {
                        map.Add(new KeyValuePair<int, int>(Convert.ToInt32(key), pow / i));
                    }
                }
            }

        }
    }
}
