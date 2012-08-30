using System;
using System.Numerics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem63
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

        static object BruteForce()
        {
            int result = 0;
            for (int i = 4; i < 10; i++)
            {
                int pow = 2;
                while (IsOk(i, pow))
                {
                    result++;
                    pow++;
                }
            }
            
            return result;
        }

 
        static bool IsOk(int num, int pow)
        {
            BigInteger temp = num;
            for (int i = 1; i < pow; i++)
            {
                temp *= num;
            }

            var isOk = temp.ToString().Length == pow;
            if(isOk)
            {
                Console.Out.WriteLine(string.Format("{0} {1}, {2}", num, pow, temp));
            }
            return isOk;
        }
    }
}
