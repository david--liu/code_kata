using System;
using System.Numerics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem57
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It should_get_correct_result = () =>
                Utils.PrintResult(() => BruteForce());

            It should_check_known = () =>
            {
                new Div(3, 2).Next.Numerator.ShouldEqual(7);
                new Div(3, 2).Next.Denominator.ShouldEqual(5);

                new Div(7, 5).Next.Numerator.ShouldEqual(17);
                new Div(7, 5).Next.Denominator.ShouldEqual(12);


                new Div(99, 70).Next.Numerator.ShouldEqual(239);
                new Div(99, 70).Next.Denominator.ShouldEqual(169);

                new Div(577, 408).Next.Numerator.ShouldEqual(1393);
                new Div(577, 408).Next.Denominator.ShouldEqual(985);

                new Div(577, 408).Next.NumeratorHasMoreDigitThanDenominator.ShouldBeTrue();

            };
        }

        static int BruteForce()
        {
            int result = 0;
            var div = new Div(3, 2);
            for (int i = 0; i < 999; i++)
            {
                div = div.Next;
                if(div.NumeratorHasMoreDigitThanDenominator)
                {
                    result++;
                }
            }

            return result;
        }

 
        class Div
        {
            BigInteger numerator;
            BigInteger denominator;

            public Div(BigInteger numerator, BigInteger denominator)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            public BigInteger Numerator
            {
                get { return numerator; }
            }

            public BigInteger Denominator
            {
                get { return denominator; }
            }

            public bool NumeratorHasMoreDigitThanDenominator
            {
                get { return Convert.ToString(numerator).Length > Convert.ToString(denominator).Length; }
            }

            public Div Next
            {
                get{return new Div(numerator + denominator + denominator, numerator + denominator);}
            }
        }
    }
}