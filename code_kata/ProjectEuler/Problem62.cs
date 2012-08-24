using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem62
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());

            It check = () =>
            {
                new Permutation(78402752).Equals(new Permutation(442450728)).ShouldBeFalse();
                
            };

        }




        static double BruteForce()
        {
            var map = new Dictionary<Permutation, List<double>>();
            double i = 345;
            while (true)
            {
                var value = i*i*i;
                var permutation = new Permutation(value);
                if(!map.ContainsKey(permutation))
                {
                    map.Add(permutation, new List<double>());
                }
                map[permutation].Add(value);
                if(map[permutation].Count == 5)
                {
                    foreach (var num in map[permutation])
                    {
                        Console.Out.WriteLine(num);
                    }
                    return map[permutation].Min();
                }
                i++;
            }

            return 0;
        }
        
    }
}
