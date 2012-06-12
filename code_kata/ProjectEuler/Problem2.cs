using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem2
    {
        [Subject(typeof(Fibonacci))]  
        public abstract class concern : Observes
        {

        }

        public class when_adding_even_numbers_for_fibonacci : concern
        {
            It should_get_correct_result_below_10 = () =>
            {
                foreach (var sequence in new Fibonacci(10).Sequences)
                {
                    Console.Out.WriteLine(sequence);
                }
            };
           It should_get_correct_result_below_4million = () =>
            {
                    Console.Out.WriteLine(new Fibonacci(4000000).Sequences.Where(i => i%2 != 0).Sum(x => x));
            };


        }

        public class Fibonacci
        {
            readonly int max;

            public Fibonacci(int max)
            {
                this.max = max;
            }

            public IEnumerable<int> Sequences
            {
                get
                {
                    var list = new LinkedList<int>();
                    list.AddFirst(0);
                    list.AddLast(1);
                    while (list.Last.Value + list.Last.Previous.Value < max)
                    {
                        list.AddLast(list.Last.Value + list.Last.Previous.Value);
                    }
                    return list;
                }
            } 
        }
    }
}
