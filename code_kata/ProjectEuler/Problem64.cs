using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem64
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It should_generate_correct_formula  = () =>
            {
                var sqr = new Sqrt(23);
                sqr.First.Sequence.ShouldEqual(4);
                sqr.First.Div.ShouldEqual(-4);
                var formula1 = sqr.First.Next;
                formula1.Sequence.ShouldEqual(1);
                formula1.Num.ShouldEqual(7);
                formula1.Div.ShouldEqual(-3);

                var formula2 = formula1.Next;
                formula2.Sequence.ShouldEqual(3);
                formula2.Num.ShouldEqual(2);
                formula2.Div.ShouldEqual(-3);

                var formula3 = formula2.Next;
                formula3.Sequence.ShouldEqual(1);
                formula3.Num.ShouldEqual(7);
                formula3.Div.ShouldEqual(-4);

                var formula4 = formula3.Next;
                formula4.Sequence.ShouldEqual(8);
                formula4.Num.ShouldEqual(1);
                formula4.Div.ShouldEqual(-4);

                var formula5 = formula4.Next;
                formula5.Sequence.ShouldEqual(1);
                formula5.Num.ShouldEqual(7);
                formula5.Div.ShouldEqual(-3);

                var formula6 = formula5.Next;
                formula6.Sequence.ShouldEqual(3);
                formula6.Num.ShouldEqual(2);
                formula6.Div.ShouldEqual(-3);

                var formula7 = formula6.Next;
                formula7.Sequence.ShouldEqual(1);
                formula7.Num.ShouldEqual(7);
                formula7.Div.ShouldEqual(-4);

            };

            It should_get_period = () =>
            {
                GetPeriod(23).ShouldEqual(4);

                GetPeriod(2).ShouldEqual(1);
                GetPeriod(3).ShouldEqual(2);
                GetPeriod(5).ShouldEqual(1);
                GetPeriod(6).ShouldEqual(2);
                GetPeriod(7).ShouldEqual(4);
                GetPeriod(8).ShouldEqual(2);
                GetPeriod(10).ShouldEqual(1);

            };

            It should_get_result_for_13 = () =>
                BruteForce(13).ShouldEqual(4);

            It should_get_result = () =>
                Utils.PrintResult(() => BruteForce(10000));
        }

        static int BruteForce(int upper)
        {
            int result = 0;
            for (int i = 2; i <= upper; i++)
            {
                if((int)Math.Pow(Math.Floor(Math.Sqrt(i)),2) == i)
                    continue;
                var period = GetPeriod(i);
                if (period % 2 > 0)
                    result++;
            }

            return result;
        }


        static int GetPeriod(int num)
        {
            var map = new Dictionary<Formula, int>();
            var formula = new Sqrt(num).First;
            int count = 0;
            while (!map.ContainsKey(formula))
            {
                count++;
                map.Add(formula, 0);
                formula = formula.Next;
            }

            return count - map[formula] -1;
        }

        class Sqrt
        {
            int num;

            public Sqrt(int num)
            {
                this.num = num;
            }

            public int Num
            {
                get { return num; }
            }

            public int Floor
            {
                get { return Convert.ToInt32(Math.Floor(Math.Sqrt(num))); }
            }

            public Formula First
            {
                get
                {
                    return new Formula(1, -1 * Floor, this, Floor);
                }
            }
        }

        class Formula
        {
            int num;
            int div;
            Sqrt sqrt;
            int sequence;

            public Formula(int num, int div, Sqrt sqrt, int sequence)
            {
                this.num = num;
                this.div = div;
                this.sqrt = sqrt;
                this.sequence = sequence;
            }

            public int Sequence
            {
                get { return sequence; }
            }

            public int Num
            {
                get { return num; }
            }

            public int Div
            {
                get { return div; }
            }

            public Sqrt Sqrt
            {
                get { return sqrt; }
            }



            public Formula Next
            {
                get
                {
                    int newNum = (sqrt.Num - div*div)/num;
                    var seq = (sqrt.Floor - div)/newNum;
                    
                    return new Formula(newNum, -(newNum * seq + div), sqrt, seq);
                }
            }

            public bool Equals(Formula other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return other.num == num && other.div == div && other.sequence == sequence;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof(Formula)) return false;
                return Equals((Formula) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int result = num;
                    result = (result*397) ^ div;
                    result = (result*397) ^ sequence;
                    return result;
                }
            }
        }
    }
}