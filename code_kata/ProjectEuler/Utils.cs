using System;
using System.Diagnostics;

namespace code_kata.ProjectEuler
{
    public static class Utils
    {
        public static void PrintResult(Func<object> getResult)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = getResult.Invoke();

            Console.WriteLine(string.Format("Result : {0}, took {1}ms." , result , stopwatch.ElapsedMilliseconds));

        }
    }
}