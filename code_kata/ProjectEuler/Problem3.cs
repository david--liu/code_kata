using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    [Subject(typeof(PrimeFactor))]
    public class Problem3
    {
        public abstract class concern : Observes
        {

        }

        public class when_find_the_prime_factor : concern
        {
            It the_max_one_should_be_29_for_13195 = () =>
                new PrimeFactor(13195).Max.ShouldEqual(29);

            It should_get_the_correct_result = () =>
                Console.Out.WriteLine(new PrimeFactor(600851475143).Max);

        }
    }

    public class PrimeFactor
    {
        readonly long value;

        public PrimeFactor(long value)
        {
            this.value = value;
        }

 
        public long Max
        {
            get { var max = GetFactor(value);
                while (max != GetFactor(max))
                {
                    max = GetFactor(max);
                }

                return max;
            }
        }

        private long GetFactor(long value)
        {
            for (long i = 2; i <= value; i++)
            {
                if (value % i == 0)
                    return i > value/i ? i : value/i;
            }
            return value;
        }
    }
}
