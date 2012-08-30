using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem24
    {
        public abstract class concern : Observes
        {

        }

        public class when_getting_lexicographic_permutation : concern
        {
            It should_return2_for_1 = () =>
            {
                GetAllPermutations(new List<char> { '0', '1' }).Count.ShouldEqual(2);
            };
            It should_return6_for_2 = () =>
            {
                GetAllPermutations(new List<char> { '0', '1', '2' }).Count.ShouldEqual(6);
            };

            It should_get_correct_result = () =>
            {
                var allPermutations = GetAllPermutations(new List<char> {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'});
                var stringList = new List<string>();
                var stringBuilder = new StringBuilder();
                foreach (var allPermutation in allPermutations)
                {
                    stringBuilder.Clear();

                    foreach (var chr in allPermutation)
                    {
                        stringBuilder.Append(chr);
                    }
                    stringList.Add(stringBuilder.ToString());
                }

                stringList.Sort();

                Console.Out.WriteLine(stringList[999999]);

            };

            static List<List<char>> GetAllPermutations(List<char> chars)
            {
                var list = new List<List<char>>();

                if (chars.Count == 1)
                {
                    return new List<List<char>>{new List<char>{chars[0]}};
                }

                for (int i = 0; i < chars.Count; i++)
                {
                    var array = chars.Where(x => x != chars[i]).ToList();
                    foreach (var permutation in GetAllPermutations(array))
                    {
                        permutation.Add(chars[i]);
                        list.Add(permutation);
                    }
                }

                return list;
            }
        }
    }
}
