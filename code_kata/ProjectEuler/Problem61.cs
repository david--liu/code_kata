using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem61
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () =>
                Utils.PrintResult(() => BruteForce());

        }


        static int BruteForce()
        {
            var all = new List<FourDigit>();
            var triangle = GetFourDigitNumbers(x => x*(x+1)/2);
            var square = GetFourDigitNumbers(x => x*x);
            var pentagonal = GetFourDigitNumbers(x => x*(3*x - 1)/2);
            var hexagonal = GetFourDigitNumbers(x => x*(2*x - 1));
            var heptagonal = GetFourDigitNumbers(x => x*(5*x - 3)/2);
            var octagonal = GetFourDigitNumbers(x => x*(3*x - 2));
            triangle.ForEach(x => all.Add(new FourDigit(x, NumberType.Triangle)));
            square.ForEach(x => all.Add(new FourDigit(x, NumberType.Square)));
            pentagonal.ForEach(x => all.Add(new FourDigit(x, NumberType.Pentagonal)));
            hexagonal.ForEach(x => all.Add(new FourDigit(x, NumberType.Hexagonal)));
            heptagonal.ForEach(x => all.Add(new FourDigit(x, NumberType.Heptagonal)));
            octagonal.ForEach(x => all.Add(new FourDigit(x, NumberType.Octagonal)));

            var firstMap = new Dictionary<int, List<FourDigit>>();
            var lastMap = new Dictionary<int, List<FourDigit>>();
            all.ForEach(x =>
            {
                if(!firstMap.ContainsKey(x.First))
                {
                    firstMap.Add(x.First, new List<FourDigit>());
                }

                firstMap[x.First].Add(x);
               if(!lastMap.ContainsKey(x.Last))
                {
                    lastMap.Add(x.Last, new List<FourDigit>());
                }

                lastMap[x.Last].Add(x);

            });


            for (int i = 11; i < 100; i++)
            {
                if(!lastMap.ContainsKey(i))
                    continue;

                foreach (var i1 in lastMap[i])
                {
                    if (!firstMap.ContainsKey(i1.Last))
                        continue;
                    foreach (var i2 in firstMap[i1.Last])
                    {
                        if (!firstMap.ContainsKey(i2.Last))
                            continue;
                        if(i2.Type == i1.Type)
                            continue;
                        foreach (var i3 in firstMap[i2.Last])
                        {
                            if (!firstMap.ContainsKey(i3.Last))
                                continue;
                            if(i3.Type == i1.Type || i3.Type == i2.Type)
                                continue;
                            foreach (var i4 in firstMap[i3.Last])
                            {
                                if (!firstMap.ContainsKey(i4.Last))
                                    continue;
                                if(i4.Type == i1.Type || i4.Type == i2.Type || i4.Type == i3.Type)
                                    continue;
                                foreach (var i5 in firstMap[i4.Last])
                                {
                                    
                                    if (!firstMap.ContainsKey(i5.Last))
                                        continue;
                                    if(i5.Type == i1.Type || i5.Type == i2.Type || i5.Type == i3.Type || i5.Type == i4.Type)
                                        continue;

                                    foreach (var i6 in firstMap[i5.Last])
                                    {
                                        if(i6.Type == i1.Type || i6.Type == i2.Type || i6.Type == i3.Type || i6.Type == i4.Type || i6.Type == i5.Type)
                                            continue;
                                        if(i6.Last == i1.First)
                                        {
                                            Console.Out.WriteLine(string.Format("got one! {0} {1} {2} {3} {4} {5}", i1.Value, i2.Value, i3.Value, i4.Value, i5.Value, i6.Value));
                                            return i1.Value + i2.Value + i3.Value + i4.Value + i5.Value + i6.Value;
                                        }
                                    }
                                }
                            } 
                        }
                    }
                }
            }

            return all.Count;





        }

        static List<int> GetFourDigitNumbers(Func<int, int> formula)
        {
            int i = 1;
            int num = 0;
            var result = new List<int>();
            while (num < 10000)
            {
                if(num > 999)
                {
                    result.Add(num);
                }
                num = formula(i);
                i++;
            }

            return result;
        }


        enum NumberType
        {
            Triangle,
            Square,
            Pentagonal,
            Hexagonal,
            Heptagonal,
            Octagonal
        }

        class FourDigit
        {
            int first;
            int last;
            NumberType type;


            public FourDigit(int first, int last, NumberType type)
            {
                this.first = first;
                this.last = last;
                this.type = type;
            }

            public FourDigit(int num, NumberType type) : this(num / 100, num % 100, type)
            {
                
            }

            public int First
            {
                get { return first; }
            }

            public int Last
            {
                get { return last; }
            }

            public NumberType Type
            {
                get { return type; }
            }

            public int Value
            {
                get { return first*100 + last; }
            }
        }

    }
}
