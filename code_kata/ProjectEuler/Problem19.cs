using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem19
    {
        public abstract class concern : Observes
        {
        }

        public class when_adding_days : concern
        {
            It should_get_correct_date = () =>
            {
                var date = new Date(1900, 1, 1).AddDays(32);
                date.Month.ShouldEqual(2);
                date.Day.ShouldEqual(2);
            };

            It should_get_the_result = () =>
            {
                var total = 0;
                var firstSunday = new Date(1900, 1, 7);

                var sunday = firstSunday;
                while (sunday.Year < 2001)
                {
                    if (sunday.Day == 1 && sunday.Year > 1900)
                        ++total;
                    sunday = sunday.AddDays(7);
                }
                Console.WriteLine(total);
            };


            class Date
            {
                public int Day { get; set; }
                public int Month { get; set; }
                public int Year { get; set; }

                public Date(int year, int month, int day)
                {
                    Year = year;
                    Month = month;
                    Day = day;
                }

                public Date()
                {
                }

                public Date AddDays(int days)
                {
                    var date = new Date();
                    if (Day + days > MaxDaysOfTheMonth)
                    {
                        date.Day = Day + days - MaxDaysOfTheMonth;
                        if (Month == 12)
                        {
                            date.Month = 1;
                            date.Year = Year + 1;
                        }
                        else
                        {
                            date.Month = Month + 1;
                            date.Year = Year;
                        }
                    }
                    else
                    {
                        date.Day = Day + days;
                        date.Month = Month;
                        date.Year = Year;
                    }

                    return date;
                }

                int MaxDaysOfTheMonth
                {
                    get
                    {
                        if (Month == 2)
                        {
                            if (IsLeapYear)
                                return 29;
                            return 28;
                        }
                        switch (Month)
                        {
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                return 30;
                            default:
                                return 31;
                        }
                    }
                }

                bool IsLeapYear
                {
                    get { return Year%4 == 0 && (Year%100 != 0 || Year%400 == 0); }
                }
            }
        }
    }
}