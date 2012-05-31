using System;

namespace code_kata.Range
{
    public class Range<T> : IEquatable<Range<T>> where T : struct , IComparable<T>
    {
        private readonly T lowerBound;
        private readonly T upperBound;

        public Range(T lowerBound, T upperBound)
        {
            ValidateBounds(lowerBound, upperBound);
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            
        }

        private static void ValidateBounds(T lowerBound, T upperBound)
        {
            if (upperBound.CompareTo(lowerBound) < 0)
                throw new NotSupportedException();
        }


        public bool IsInRange(T value)
        {
            return lowerBound.CompareTo(value) <=0  && upperBound.CompareTo(value) >=0;
        }

        public Range<T> Intersect(Range<T> other)
        {
            var maxLowerBound = lowerBound.CompareTo(other.lowerBound) < 0 ? other.lowerBound : lowerBound;
            var minUpperBound = upperBound.CompareTo(other.upperBound) > 0 ? other.upperBound : upperBound;
            if (maxLowerBound.CompareTo(minUpperBound) > 0)
            {
                return null;
            }
            return new Range<T>(maxLowerBound, minUpperBound);
        }

        public bool Equals(Range<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.lowerBound.Equals(lowerBound) && other.upperBound.Equals(upperBound);
        }

        public override string ToString()
        {
            return string.Format("Range {0}-{1}", lowerBound, upperBound);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Range<T>)) return false;
            return Equals((Range<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (lowerBound.GetHashCode()*397) ^ upperBound.GetHashCode();
            }
        }
    }
}