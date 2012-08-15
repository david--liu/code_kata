using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem32
    {
        public abstract class concern : Observes
        {

        }

        public class when_check_is_pandigital : concern
        {
            It should_return_true = () =>
                IsPandigital(1, 23, 456789).ShouldBeTrue();
           It should_return_false_contains_zero = () =>
                IsPandigital(1, 23, 4567890).ShouldBeFalse();
           It should_return_false = () =>
                IsPandigital(1, 23, 4567889).ShouldBeFalse();

        }

        public class when_check_has_same_digit_or_zero : concern
        {
            It should_return_true = () =>
            {
                HasSameDigitOrZero(0, 1).ShouldBeTrue();
                HasSameDigitOrZero(1, 12345).ShouldBeTrue();
            };

            It should_return_false = () =>
            {
                HasSameDigitOrZero(123, 456).ShouldBeFalse();
                HasSameDigitOrZero(456, 789).ShouldBeFalse();
            };
        }

        public class when_solving : concern
        {
            It should_get_result = () =>
                Console.Out.WriteLine(GetSumOfProductThatIsPandigital());
        }


        static int GetSumOfProductThatIsPandigital()
        {
            var list = new SortedSet<int>();

            for (int i = 1; i < 50; i++)
            {
                for (int j = 1; j < 2000; j++)
                {
                    if(HasSameDigitOrZero(i, j))
                        continue;
                    var product = i*j;
                    if(IsPandigital(i,j, product))
                    {

                        Console.Out.WriteLine(string.Format("got one ! i ={0} j = {1} product ={2}", i,j,product));
                        list.Add(product);
                    }
                }
            }

            return list.Sum();
        }

        static bool HasSameDigitOrZero(int x, int y)
        {
            if(x == 0 || y == 0)
                return true;
            var map = new Dictionary<int, int>();
            map.Add(0, 0);
            int pow = 10;
            for (int i = 0; i < 5; i++)
            {
                if (x > 0)
                {
                    var a = x - (x/pow)*pow;
                    if (map.ContainsKey(a))
                    {
                        return true;
                    }
                    map.Add(a, 0);
                    x = x/pow;
                }
                if (y > 0)
                {
                    var b = y - (y/pow)*pow;
                    if (map.ContainsKey(b))
                    {
                        return true;
                    }
                    map.Add(b, 0);
                    y = y/pow;
                }
            }

            return false;
        }

        static bool IsPandigital(int multiplicand, int multiplier, int product)
        {
            var list =
                Enumerable.Concat(Convert.ToString(multiplicand), Convert.ToString(multiplier)).Concat(Convert.ToString(product)).
                    ToList();
            return !list.Contains('0') && list.Count == 9 && list.Distinct().Count() == 9;
        }
    }
}
