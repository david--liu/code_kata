using System;
using System.Collections.Generic;
using Machine.Specifications.Runner.Impl;

namespace code_kata.ProjectEuler
{
    public class Permutation : IEquatable<Permutation>
    {
        readonly List<int> set = new List<int>();

        public Permutation(IEnumerable<int> nums)
        {
            nums.ForEach(m => set.Add(m));
        }

        public Permutation(double num)
        {
            set.AddRange(MathUtils.ConvertToDigits(num));
            set.Sort();
        }

        public bool Equals(Permutation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ListEqual(other.set);
        }

        private bool ListEqual(List<int> otherList)
        {
            if (set.Count != otherList.Count)
                return false;
            for (int l = 0; l < set.Count; l++)
            {
                if (set[l] != otherList[l])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Permutation)) return false;
            return Equals((Permutation)obj);
        }

        public override int GetHashCode()
        {
            var result = 0;
            foreach (var digit in set)
            {
                if (result == 0)
                    result = digit;
                else
                {
                    result = (result * 397) ^ digit;
                }
            }

            return result;
        }
    }
}