using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem14
    {
        public abstract class concern : Observes
        {

        }

        public class when_iterating_collatz : concern
        {
            static ConcurrentDictionary<long, long> map = new ConcurrentDictionary<long, long>();
            It should_return_10_when_starting_with_13 = () =>
            {
                for (int i = 2; i <= 13; i++)
                {
                    map.AddOrUpdate(i, 0, (x,y) => 0);
                }

                for (int i = 2; i <= 13; i++)
                {
                    map[i] = GetCollatzSequences(i);
                }
                map[13].ShouldEqual(10);
            };

            It OBSERVATION_NAME = () =>
                GetCollatzSequences(999167);

            It should_get_result = () =>
            {
                map.Clear();
                for (long i = 2; i <= 1000000; i++)
                {
                    map.AddOrUpdate(i, 0, (x, y) => 0);
                }
                
                map.Keys.AsParallel().ForAll(x => map[x] = GetCollatzSequences(x));

                var value = map.Values.Max(x => x);
                Console.Out.WriteLine(value);
                Console.Out.WriteLine(map.First(x => x.Value == value));
            };
            static long GetCollatzSequences(long value)
            {
                int count = 0;
                long running = value;

                if (map.ContainsKey(running) && map[running] > 0)
                {
                    return map[running];
                }

 //               Console.Out.WriteLine(value);

                while (running != 1 && running > 0)
                {

                    if (running % 2 == 0)
                    {
                        running /= 2;
                    }
                    else
                    {
                        running = 3*running + 1;
                    }

                    ++count;

                    //if (map.ContainsKey(running))
                    //{
                    //    if (map[running] == 0)
                    //    {
                    //        map[running] = GetCollatzSequences(running);
                    //    }
                    //    return map[running] + count;

                    //}

                    if(count > 1000)
                        Console.Out.WriteLine(value);

                   }
                return count + 1;
            }
        }
    }
}
