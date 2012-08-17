using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem45
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                HasMatching(40755, 0, 290, GetTriangle).ShouldBeTrue();
                HasMatching(40755, 0, 290, GetPentagonal).ShouldBeTrue();
                HasMatching(40755, 0, 290, GetHexagonal).ShouldBeTrue();
                HasMatching(40756, 0, 290, GetHexagonal).ShouldBeFalse();
                HasMatching(49999, 0, 3, GetHexagonal).ShouldBeFalse();
            };

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce());
        }

        static long BruteForce()
        {
            int hexIndex = 144;
            while (true)
            {
                var hex = GetHexagonal(hexIndex);

                if (HasMatching(hex, hexIndex, 2 * hexIndex, GetPentagonal))
                {
                    return hex;
                }


                hexIndex++;
            }

        }

        static bool HasMatching(double value, int minIndex, int maxIndex, Func<long, long> getValue)
        {
            var index = (maxIndex + minIndex)/2;

            if(index == minIndex || index == maxIndex)
                return false;

            var indexValue = getValue(index);
            if(indexValue == value)
            {
                Console.Out.WriteLine(index + " " + value + " " + indexValue);
                return true;
            }
            if(indexValue > value)
            {
                return HasMatching(value, minIndex, index, getValue);
            }
            else
            {
                return HasMatching(value, index, maxIndex, getValue);
            }
            
        }

        static long GetTriangle(long i)
        {
            return (i*(i + 1))/2;
        }

        static long GetPentagonal(long i)
        {
            return i*(3*i - 1)/2;
        }

        static long GetHexagonal(long i)
        {
            return i*(2*i - 1);
        }
    }
}