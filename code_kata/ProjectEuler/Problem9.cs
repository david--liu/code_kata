using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem9
    {
        public abstract class concern : Observes
        {

        }

        public class when_finding_Pythagorean_triplet : concern
        {
            It should_return345_for_12 = () =>
            {
                var pythagorean = GetPythagorean(12);
                pythagorean.A.ShouldEqual(3);
                pythagorean.B.ShouldEqual(4);
                pythagorean.C.ShouldEqual(5);
            };

            It should_get_the_correct_result = () =>
            {
                var pythagorean = GetPythagorean(1000);
                if(pythagorean != null)
                {
                    Console.Out.WriteLine("a : "+ pythagorean.A);
                    Console.Out.WriteLine("b : "+ pythagorean.B);
                    Console.Out.WriteLine("c : "+ pythagorean.C);
                    Console.Out.WriteLine("procut : "+ pythagorean.A * pythagorean.B * pythagorean.C);
                }
            };

            static Pythagorean GetPythagorean(int total)
            {

                for (int c = total; c  > 1; c--)
                {
                    for (int b = c -1; b > 2 ; b--)
                    {
                        for (int a = 1; a < b; a++)
                        {
                            if(a + b + c == total && ( a*a + b*b == c*c))
                            {
                                return new Pythagorean(a, b, c);
                            }
                        }
                    }
                }


                return null;

            }
        }
    }

    class Pythagorean
    {
        int a, b, c;

        public Pythagorean(int a, int b, int c)
        {
            this.a = a;
            this.c = c;
            this.b = b;
        }

        public int A
        {
            get { return a; }
        }

        public int B
        {
            get { return b; }
        }

        public int C
        {
            get { return c; }
        }
    }
}
