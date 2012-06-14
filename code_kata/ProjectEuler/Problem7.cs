using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem7
    {
        public abstract class concern : Observes
        {

        }
        
        public class when_find_prime_numbers : concern
        {
            It should_return_13_for_sequence_6 = () =>
                PrimeNumber.GetPrimeNumberOfSequence(6).ShouldEqual(13);

            It should_get_the_correct_result = () =>
                Console.Out.WriteLine(PrimeNumber.GetPrimeNumberOfSequence(10001));

        }
    }

   public class PrimeNumber
    {
        public static long GetPrimeNumberOfSequence(int sequence)
        {
            var map = new List<long>();
            long i = 2;
            map.Add(i);
            while (map.Count < sequence)
            {
                ++i;
                if(!map.Exists(x => i % x ==0))
                {
                    map.Add(i);
                }
            }
            return map[sequence - 1];
        }
        public static long GetSumOfPrimeNumberBelow(int max)
        {
            var map = new List<long>();
            long i = 2;
            map.Add(i);
            while (i < max)
            {
                ++i;
                if(!map.Exists(x => i % x ==0))
                {
                    map.Add(i);
                }
            }
            return map.Sum(x => x);
        }
    }
}
