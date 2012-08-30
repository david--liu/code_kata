using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace code_kata.ProjectEuler
{
    public class Problem15
    {
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It should_return_6_for_2x2 = () =>
            {
                var sum = GetTotalRoute(2);
                sum.ShouldEqual(6);
            };

            It should_return_result = () =>
            {
                Console.Out.WriteLine(GetTotalRoute(2));
                Console.Out.WriteLine(GetTotalRoute(3));
                Console.Out.WriteLine(GetTotalRoute(4));
                Console.Out.WriteLine(GetTotalRoute(5));
                Console.Out.WriteLine(GetTotalRoute(6));
                Console.Out.WriteLine(GetTotalRoute(7));
                Console.Out.WriteLine(GetTotalRoute(8));
                Console.Out.WriteLine(GetTotalRoute(9));
                double value = 6;
                for (double i = 3; i <= 20; i++)
                {
                    value = (3) * value + (i - 2) / i * value;
                    Console.Out.WriteLine(value);
                }
            };

            static int GetTotalRoute(int max)
            {
                var route = new Route(0, 0, max);
                return route.Count + 1;
            }

            static int leftRow;
            static int leftCol;
            static int rightRow;
            static int rightCol;
            static int GetNextSteps(int row, int col, int max)
            {
                if (row == max && col == max)
                    return 0;
                if (row == max || col == max)
                {
                    return 1;
                }

                {
                    leftRow = row;
                    leftCol = col + 1;
                    rightRow = row + 1;
                    rightCol = col;
                    return 2;
                }

            }


            class Route
            {
                public Route(int row, int col, int max)
                {
                    var positions = GetNextSteps(row, col, max);
                    var leftR = leftRow;
                    var leftC = leftCol;
                    var rightR = rightRow;
                    var rightC = rightCol;
                    if(positions == 2)
                    {
                        LeftRoute = new Route(leftR, leftC, max);
                        RightRoute = new Route(rightR, rightC, max);
                    }
                }

                Route LeftRoute { get; set; }
                Route RightRoute { get; set; }

                public int Count
                {
                    get
                    {
                        int count = 0;
                        if(LeftRoute != null && LeftRoute != null)
                        {
                            ++count;
                            count = count + LeftRoute.Count;
                            count = count + RightRoute.Count;
                        }

                        return count;
                    }
                }

            }

            class Position
            {
                public Position(int row, int col)
                {
                    this.Row = row;
                    this.Col = col;
                }

                public Position()
                {
                   
                }

                public int Row { get; set; }

                public int Col { get;  set; }
            }
        }
    }
}