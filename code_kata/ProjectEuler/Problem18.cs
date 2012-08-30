using System;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem18
    {
        static string value =
                @"75
                |95 64
                |17 47 82
                |18 35 87 10
                |20 04 82 47 65
                |19 01 23 75 03 34
                |88 02 77 73 07 63 67
                |99 65 04 28 06 16 70 92
                |41 41 26 56 83 40 80 70 33
                |41 48 72 33 47 32 37 16 94 29
                |53 71 44 65 25 43 91 52 97 51 14
                |70 11 33 28 77 73 17 78 39 68 17 57
                |91 71 52 38 17 14 91 43 58 50 27 29 48
                |63 66 04 68 89 53 67 30 73 16 69 87 40 31
                |04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
        public abstract class concern : Observes
        {
        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                var node = new BinaryNode(BinaryNode.Parse(value), 0, 0);
                Console.Out.WriteLine(node.MaxSum());
            };

        }


        public class BinaryNode
        {
            public BinaryNode Left { get; set; }
            public BinaryNode Right  { get; set; }
            public int Value { get; set; }

            public BinaryNode(int[,] value, int row, int col)
            {
                var maxRow = value.GetUpperBound(0);
                var maxCol = value.GetUpperBound(1);
                Value = value[row, col];
                if(row + 1 <= maxRow)
                {
                    Left = new BinaryNode(value, row +1, col);
                    if(col +1 <= maxCol)
                    {
                        Right = new BinaryNode(value, row + 1, col + 1);
                    }
                }
            }

            public int MaxSum()
            {
                var leftMax = Left == null ? 0 : Left.MaxSum();
                var rightMax = Right == null ? 0 : Right.MaxSum();
                return Value + (leftMax > rightMax ? leftMax : rightMax);
            }

            public static int[,] Parse(string value)
            {
                var rows  = value.Split('|');
                int i = 0;
                var count = rows.Count();
                var array = new int[count,count];
                foreach (var row in rows)
                {
                    int j = 0;

                    var values = row.Trim().Split(' ');
                    foreach (var s in values)
                    {
                        array[i, j] = Convert.ToInt32(s.TrimStart('0'));
                        ++j;
                    }
                    ++i;
                }

                return array;


            }
        }


    }
}
