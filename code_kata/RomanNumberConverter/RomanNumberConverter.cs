using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace code_kata.RomanNumberConverter
{
    public static class RomanNumberConverter
    {
        private static Dictionary<int,char> map = new Dictionary<int, char>();

        static RomanNumberConverter()
        {
            map.Add(1, 'I');
            map.Add(5, 'V');
            map.Add(10, 'X');
            map.Add(50, 'L');
            map.Add(100, 'C');
            map.Add(500, 'D');
            map.Add(1000, 'M');
        }

        public static string ConvertToRoman(int numberToConvert)
        {
            if(numberToConvert < 0 || numberToConvert > 8999)
                throw new NotSupportedException();

            if(map.ContainsKey(numberToConvert))
            {
                return map[numberToConvert].ToString(CultureInfo.InvariantCulture);
            }

            var numberInDigits = new NumberInDigits(numberToConvert);

            var builder = new StringBuilder();

            ConvertDigitToRoman(numberInDigits.Thousands, 1000, builder);
            ConvertDigitToRoman(numberInDigits.Hundreds, 100, builder);
            ConvertDigitToRoman(numberInDigits.Tens, 10, builder);
            ConvertDigitToRoman(numberInDigits.Ones, 1, builder);

            return builder.ToString();
        }

        private static void ConvertDigitToRoman(int digit, int key, StringBuilder builder)
        {
            if(map.ContainsKey(digit * key))
            {
                builder.Append(map[digit * key]);
                return;
            }

            if(digit == 4)
            {
                builder.Append(map[key]).Append(map[key*5]);
                return;
            }

            if (digit == 9)
            {
                builder.Append(map[key]).Append(map[key * 10]);
                return;
            }


            for (var i = 1; i <= digit; i++)
            {
                builder.Append(map[key]);
            }
        }

        private class NumberInDigits
        {
            private int thousands;
            private int hundreds;
            private int tens;
            private int ones;

            public NumberInDigits(int number)
            {
                thousands = number/1000;
                hundreds = (number - thousands * 1000)/100;
                tens = (number - thousands*1000 - hundreds*100)/10;
                ones = number - thousands*1000 - hundreds*100 - tens*10;
            }


            public int Thousands
            {
                get { return thousands; }
            }

            public int Hundreds
            {
                get { return hundreds; }
            }

            public int Tens
            {
                get { return tens; }
            }

            public int Ones
            {
                get { return ones; }
            }
        }

        public static int ConvertFromRoman(string romanString)
        {
            int sum = 0;
            int previousKey = 1000;
            foreach (var chr in romanString)
            {
                foreach (KeyValuePair<int, char> keyValue in map)
                {
                    if (chr == keyValue.Value)
                    {
                        //Only one small-value symbol may be subtracted from any large-value symbol.
                        if(previousKey < keyValue.Key)
                        {
                            sum = sum - previousKey - previousKey;
                        }
                        sum += keyValue.Key;
                        previousKey = keyValue.Key;
                    }
                }
            }
            return sum;
        }
    }
}