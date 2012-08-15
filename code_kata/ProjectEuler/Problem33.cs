using System;
using System.Diagnostics;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace code_kata.ProjectEuler
{
    public class Problem33
    {
        public abstract class concern : Observes
        {

        }

        public class when_observation_name : concern
        {
            It first_observation = () => BruteForce();

        }

         static void BruteForce() {
            Stopwatch clock = Stopwatch.StartNew();

            int denproduct = 1;
            int nomproduct = 1;
                       
            for (int i = 1; i < 10; i++) {    
                for (int den = 1; den < i; den++) {                    
                    for (int nom = 1; nom < den; nom++) {                                                
                        if ((nom * 10 + i) * den == nom * (i * 10 + den)) {
                            denproduct *= den;
                            nomproduct *= nom;                         
                        }
                    }
                }
            }
                                    
            denproduct /= gcd(nomproduct, denproduct);

            clock.Stop();
            Console.WriteLine("The product of denominators {0}", denproduct);
            Console.WriteLine("Solution took {0} ms", clock.ElapsedMilliseconds);
        }

         static  int gcd(int a, int b)
         {
             int y, x;

             if (a > b)
             {
                 x = a;
                 y = b;
             }
             else
             {
                 x = b;
                 y = a;
             }

             while (x % y != 0)
             {
                 int temp = x;
                 x = y;
                 y = temp % x;
             }

             return y;
         }


    }
}
