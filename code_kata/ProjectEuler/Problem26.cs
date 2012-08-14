 using System;
 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{   

    public class Problem26
    {
        public abstract class concern 
        {
        
        }

        public class when_work_with_known_result : concern
        {
            It should_return_one_for_3 = () =>
            
                new Divisor(3).RecurringCycle.ShouldEqual(1);
            

            It should_return_six_for_7 = () => new Divisor(7).RecurringCycle.ShouldEqual(6);
                

        }

        public class when_solving : concern
        {
            It should_get_result = () =>
            {
                int max = 0;
                int maxNumber = 0;
                for (int i = 2; i < 1000; i++)
                {
                    Console.Out.WriteLine("Processing " + i);
                    var recurringCycle = new Divisor(i).RecurringCycle;
                    if(recurringCycle > max)
                    {
                        maxNumber = i;
                        max = recurringCycle;
                    }
                }

                Console.Out.WriteLine(max);
                Console.Out.WriteLine(maxNumber);
            };

        }
    }

    class Divisor
    {
        readonly int divisor;
        private readonly List<int> result =new List<int>();
        int recurringCycle = 0;
        public Divisor(int divisor)
        {
            this.divisor = divisor;
            Divide(GetBiggerRemainder(1));
        }

        private void Divide(int div)
        {
            while (!result.Exists(x => x == div))
            {
                result.Add(div);
                var remainder = div - (div/divisor)*divisor;
                if(remainder == 0)
                    break;

                Divide(GetBiggerRemainder(remainder));
            }

            recurringCycle = result.Count - result.IndexOf(div);
        }

        private int GetBiggerRemainder(int remainder)
        {
            int result = remainder;
            while (result < divisor)
            {
                result *= 10;
            }

            return result;
        }

        public int RecurringCycle
        {
            get { return recurringCycle; }
        }
    }
}
