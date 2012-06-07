using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using code_kata.ExpressionTree;

namespace code_kata.SpreadSheet
{
    public class Sheet

    {
        private Dictionary<string, string> map = new Dictionary<string, string>();

        private Dictionary<string, int> circularCheck = new Dictionary<string, int>(); 

        public string get(string cell)
        {
            if (map.ContainsKey(cell))
            {
                circularCheck.Clear();
                circularCheck.Add(cell,0);
                try
                {
                    return ProcessValue(map[cell]);
                }
                catch (CircularReferenceException circularReferenceException)
                {
                    return "#Circular";
                }
                catch(Exception ex)
                {
                    return "#Error";
                }
            }
            return string.Empty;
        }

        public void put(string cell, string value)
        {
            if(!map.ContainsKey(cell))
            {
                map.Add(cell, value);
            }
            else
            {
                map[cell] = value;
            }
        }

        private string ProcessValue(string value)
        {
            string result = value;
            int number;

            var isNumber = int.TryParse(value.Trim(), out number);
            if (isNumber)
            {
                result =  number.ToString(CultureInfo.InvariantCulture);
            }

            var isFormula = value.StartsWith("=");
            if(isFormula)
            {

                var formula = value.Substring(1, value.Length - 1).Trim();

                result = Evaluate(formula);
                
            }

            return result;
        }

        private string Evaluate(string formula)
        {
            var newFormula = formula;
            foreach (var cell in map.Keys.Where(x => newFormula.Contains(x)))
            {
                if(circularCheck.ContainsKey(cell))
                {
                    throw new CircularReferenceException();
                }
                newFormula = newFormula.Replace(cell, ProcessValue(map[cell]));
            }


           return new ExpressionConverter().ConstructBinaryTree<int>(newFormula).Eval().ToString(CultureInfo.InvariantCulture);
        }

        public string getLiteral(string cell)
        {
            if (map.ContainsKey(cell))
                return map[cell];
            return string.Empty;
        }

        private class ValueAndLiteral
        {
            public string Literal { get; set; }
        }
    }

    class CircularReferenceException : Exception
    {
    }
}