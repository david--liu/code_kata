using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem43
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                var array = MathUtils.ConvertToDigits(1406357289).ToArray();
                IsMatching(array,3).ShouldBeTrue();
                IsMatching(array,4).ShouldBeTrue();
                IsMatching(array,5).ShouldBeTrue();
                IsMatching(array,6).ShouldBeTrue();
                IsMatching(array,7).ShouldBeTrue();
                IsMatching(array,8).ShouldBeTrue();
                IsMatching(array,9).ShouldBeTrue();
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }


        static double BruteForce()
        {
            return new Pandigital(10).List.Where(IsMatching).Sum(o => MathUtils.ConvertToDouble(o));
        }


        static bool IsMatching(int[] nums, int index)
        {
            if (index ==3 && MathUtils.ConvertToNumber(new int[3] { nums[1], nums[2], nums[3] }) % 2 != 0)
                return false;
            if (index == 4 && MathUtils.ConvertToNumber(new int[3] { nums[2], nums[3], nums[4] }) % 3 != 0)
                return false;
            if (index == 5 && MathUtils.ConvertToNumber(new int[3] { nums[3], nums[4], nums[5] }) % 5 != 0)
                return false;
            if (index == 6 && MathUtils.ConvertToNumber(new int[3] { nums[4], nums[5], nums[6] }) % 7 != 0)
                return false;
            if (index == 7 && MathUtils.ConvertToNumber(new int[3] { nums[5], nums[6], nums[7] }) % 11 != 0)
                return false;
            if (index == 8 && MathUtils.ConvertToNumber(new int[3] { nums[6], nums[7], nums[8] }) % 13 != 0)
                return false;
            if (index == 9 && MathUtils.ConvertToNumber(new int[3] { nums[7], nums[8], nums[9] }) % 17 != 0)
                return false;

            return true;
        }

        class Pandigital
        {
            List<int[]> list = new List<int[]>();

            public Pandigital(int max)
            {
                var digits = new int[max];
                for (var i = 0; i < max; i++)
                {
                    digits[i] = i;
                    if (i > 0)
                    {
                        var item = new int[max];
                        item[0] = i;
                        for (int j = 1; j < max; j++)
                        {
                            item[j] = -1;
                        }
                        list.Add(item);
                    }
                }

                for (var i = 1; i < max; i++)
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
                        for (var k = 0; k < i; k++)
                        {
                            temp[k] = num[k];
                        }

                        temp[i] = j;

                        for (int k = i + 1; k < max; k++)
                        {
                            temp[k] = -1;
                        }


                        if(IsMatching(temp, i))
                            tempList.Add(temp);
                    }
                }

                list = tempList;
            }

            public List<int[]> List
            {
                get { return list; }
            }
        }
    }
}