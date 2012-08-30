using System;
using System.Collections.Generic;
using System.Numerics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem56
    {
        public abstract class concern : Observes
        {

        }

        public class when_multiple_two_lists : concern
        {
            It should_get_correct_result = () =>
            {
                MathUtils.ConvertToNumber(MathUtils.Multi(new List<int> {4}, new List<int> {4}).ToArray()).ShouldEqual(
                    16);
                MathUtils.ConvertToNumber(MathUtils.Multi(new List<int> {4, 4}, new List<int> {4, 4}).ToArray()).
                    ShouldEqual(1936);
                MathUtils.ConvertToNumber(MathUtils.Multi(new List<int> {9, 9, 9, 9}, new List<int> {8, 8, 8}).ToArray())
                    .ShouldEqual(8879112);
                MathUtils.ConvertToNumber(MathUtils.Multi(new List<int> {2, 7}, new List<int> {3}).ToArray()).
                    ShouldEqual(81);
            };

            It should_get_correct_power = () =>
                MathUtils.ConvertToNumber(GetPower(3, 4).ToArray()).ShouldEqual(81);

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForceCustom());

            It should_get_result_using_big_integer = () =>
                Utils.PrintResult(() => BruteForce());

            It big_integer_test = () =>
                Utils.PrintResult(() => BigInteger.Pow(99, 95).ToString());
        }


        static int BruteForce()
        {
            int result = 0;
            for (int a = 2; a < 100; a++)
            {
                for (int b = 2; b < 100; b++)
                {
                    var power = BigInteger.Pow(a, b);
                    var sum = Convert.ToInt32(power.ToString().Sum(x => char.GetNumericValue(x)));
                    result = result > sum ? result : sum;
                }
            }

            return result;
 
        }


        static int BruteForceCustom()
        {
            int result = 0;
            for (int a = 2; a < 100; a++)
            {
                for (int b = 2; b < 100; b++)
                {
                    var power = GetPower(a, b);
                    var sum = power.Sum();
                    result = result > sum ? result : sum;
                }
            }

            return result;
        }

        static List<int> GetPower(int a, int b)
        {
            var list = MathUtils.ConvertToDigits(a);
            var result = new List<int>(list);
            for (int i = 0; i < b -1; i++)
            {
                result = MathUtils.Multi(result, list);
            }

            return result;

        }

    }
}
