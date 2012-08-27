using System;
using System.Collections.Generic;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Linq;

namespace code_kata.ProjectEuler
{
    public class Problem68
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
            {
                Utils.PrintResult(() => BruteForce());
            };

        }

        static string BruteForce()
        {
            var fiveGon = new FiveGon(1, 2, 3, 4, 5);

            fiveGon.Calculate();

            if (fiveGon.IsValid)
            {
                return fiveGon.Max;
            }

            return "";
        }

        static int[] all = new[]{1, 2, 3,4, 5, 6, 7, 8, 9, 10};

        class FiveGon
        {
            readonly List<int> nums;
            List<Line[]> list = new List<Line[]>();
            public FiveGon(params int[] nums)
            {
                this.nums = nums.OrderBy(x => x).ToList();
            }

            public List<Line[]> List
            {
                get { return list; }
            }

            public void Calculate()
            {
                {
                    var x1 = nums[0];
                    
                    for (int i = 1; i < nums.Count; i++)
                    {
                        var x2 = nums[i];
                        foreach (var x3 in nums.Where(x => x != x1 && x != x2))
                        {
                            foreach (var x4 in nums.Where(x => x != x1 && x != x2 && x != x3))
                            {
                                var x5 = nums.Find(x => x != x1 && x != x2 && x != x3 && x != x4);
                                var lines = new Line[5];
                                lines[0] = new Line(x1, x2);
                                lines[1] = new Line(x2, x3);
                                lines[2] = new Line(x3, x4);
                                lines[3] = new Line(x4, x5);
                                lines[4] = new Line(x5, x1);

                                lines[0].Next = lines[1];
                                lines[1].Next = lines[2];
                                lines[2].Next = lines[3];
                                lines[3].Next = lines[4];
                                lines[4].Next = lines[0];

                                if(lines.Select(x => x.InnerTotal).Distinct().Count() < 5)
                                    continue;

                                var min = lines.Min(x => x.InnerTotal);

                                bool isOk = true;
                                foreach (var num in all.Except(nums))
                                {
                                    var first = lines.FirstOrDefault(x => x.InnerTotal + num == min + 10);
                                    if(first == null)
                                    {
                                        isOk = false;
                                        break;
                                    }

                                    first.Insert(num);
                                }

                                if(isOk)
                                {
                                    
                                    list.Add(lines);
                                }
                            }
                        }
                    }

                }
            }

            public bool IsValid
            {
                get { return list.Count > 0; }
            }

            public string Max
            {
                get { 
                    var map = list.ToDictionary(x => x.Min(o => o.Total));
                    var max = map.Max(x => x.Key);
                    var stringBuilder = new StringBuilder();
                    var first = map[max].First(x => x.Total == max);
                    stringBuilder.Append(first);
                    stringBuilder.Append(first.Next);
                    stringBuilder.Append(first.Next.Next);
                    stringBuilder.Append(first.Next.Next.Next);
                    stringBuilder.Append(first.Next.Next.Next.Next);
                    return stringBuilder.ToString();
                }
            }
        }
    }

    class Line
    {
        readonly int x1;
        readonly int x2;
        int x;
        public int Total{ get { return x*100 + x1*10 + x2; }}

        public Line(int x1, int x2)
        {
            this.x1 = x1;
            this.x2 = x2;
        }

        public int InnerTotal
        {
            get { return x1 + x2; }
        }

        public int Insert(int x)
        {
            this.x = x;
            return x + x1 + x2;
        }

        public override string ToString()
        {
            return Convert.ToString(Total);
        }

        public Line Next { get; set; }
    }
}
