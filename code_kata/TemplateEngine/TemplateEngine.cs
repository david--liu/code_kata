using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace code_kata.TemplateEngine
{
    public class TemplateEngine
    {
 
        public static string Evaluate(string template, VariableMap mapOfVariables)
        {
            string result = template;

            foreach (var variable in GetAllVariables(template))
            {
                result = result.Replace(string.Format("{{${0}}}", variable), mapOfVariables.Get(variable));
            }

            
            return result;
        }


        public static List<string> GetAllVariables(string template)
        {
            var strings = template.Split('{');
            var result = new List<string>();
            for (int i = 1; i < strings.Length; i++)
            {
                if(strings[i].StartsWith("$") && strings[i].Contains("}"))
                {
                    result.Add(strings[i].Substring(1, strings[i].IndexOf("}", System.StringComparison.Ordinal) -1));
                }
            }
            return result;

        }
    }
}