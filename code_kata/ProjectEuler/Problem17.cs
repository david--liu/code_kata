using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem17
    {
        public abstract class concern : Observes
        {
        }

        public class when_spelling_numbers : concern
        {
            It should_return_one_for_1 = () =>
                new NumberSpeller().Spell(1).ShouldEqual("One");
            It should_return_two_for_2 = () =>
                new NumberSpeller().Spell(2).ShouldEqual("Two");
            It should_return_one_hundred_for_100 = () =>
                new NumberSpeller().Spell(100).ShouldEqual("One hundred");
            It should_return_one_thousand_for_1000 = () =>
                new NumberSpeller().Spell(1000).ShouldEqual("One thousand");
            It should_return_fourty_two_for_42 = () =>
                new NumberSpeller().Spell(42).ShouldEqual("Forty-two");
            It should_return_three_hundred_and_fourty_two_for_342 = () =>
                new NumberSpeller().Spell(342).ShouldEqual("Three hundred and forty-two");
            It should_return_one_hundred_and_fifteen_for_115 = () =>
                new NumberSpeller().Spell(115).ShouldEqual("One hundred and fifteen");
        }

        public class when_solving_the_problem : concern
        {
            It should_return_19_when_count_5 = () => 
               GetCountOfSpelledNumber(5).ShouldEqual(19);
            It should_get_correct_result = () =>
            {
                Console.WriteLine(GetCountOfSpelledNumber(1000));
            };

            It count_should_return_23_for_342 = () =>
                CountWithoutSpaceAndHyphen(new NumberSpeller().Spell(342)).ShouldEqual(23);
          It count_should_return_23_for_142 = () =>
                CountWithoutSpaceAndHyphen(new NumberSpeller().Spell(115)).ShouldEqual(20);

           static int GetCountOfSpelledNumber(int number)
            {
                int count = 0;
                var numberSpeller = new NumberSpeller();
                for (int i = 1; i <= number; i++)
                {
                    var spell = numberSpeller.Spell(i);

                    count += CountWithoutSpaceAndHyphen(spell);
                }

                return count;
            }

            static int CountWithoutSpaceAndHyphen(string spell)
            {
                return spell.Count(x => x != ' ' && x != '-');
            }
        }
    }

    class NumberSpeller
    {
        static Dictionary<int, string> map = new Dictionary<int, string>
        {
            {0, string.Empty},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"}
        };

        public string Spell(decimal check)
        {
            var dollars = (int) Math.Floor(check);
            var cents = (check - dollars)*100;

            if (cents != 0)
            {
                if (dollars == 0)
                {
                    return FormatCents(cents);
                }
                else
                {
                    return string.Format("{0} and {1}", GetDisplay(dollars), FormatCents(cents));
                }
            }
            else
            {
                return string.Format("{0}", GetDisplay(dollars).Trim());
            }
        }

        static string GetDisplay(int dollars)
        {
            if (map.ContainsKey(dollars))
                return map[dollars];

            if (dollars == 0)
                return string.Empty;

            if (dollars >= 1000*1000)
            {
                throw new NotSupportedException("To be completed");
            }

            if (dollars >= 1000)
            {
                return GetDisplayForThousands(dollars);
            }
            if (dollars >= 100)
            {
                return GetDisplayForHundreds(dollars);
            }
            return GetDisplayForDollarLessThanOneHundred(dollars);
        }

        static string GetDisplayForDollarLessThanOneHundred(int dollars)
        {
            if (map.ContainsKey(dollars))
                return map[dollars];
            var tens = (int) Math.Floor(dollars/10m)*10;
            return string.Format("{0}-{1}", map[tens], map[dollars - tens].ToLower());
        }

        static string GetDisplayForHundreds(int dollars)
        {
            var hundreds = (int) Math.Floor(dollars/100m);
            var tens = dollars - hundreds*100;

            return string.Format("{0} hundred {1}", map[hundreds],
                                 tens == 0 ? string.Empty : "and " + GetDisplayForDollarLessThanOneHundred(tens).ToLower());
        }

        static string GetDisplayForThousands(int dollars)
        {
            var thousands = (int) Math.Floor(dollars/1000m);
            return string.Format("{0} thousand {1}", GetDisplay(thousands),
                                 GetDisplay(dollars - thousands*1000).ToLower());
        }

        static string FormatCents(decimal cents)
        {
            return string.Format("{0:F0}/100 Dollars", cents);
        }
    }
}

