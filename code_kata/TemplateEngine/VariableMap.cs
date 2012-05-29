using System.Collections.Generic;

namespace code_kata.TemplateEngine
{
    public class VariableMap
    {
        private readonly Dictionary<string, string> map = new Dictionary<string, string>();

        public void Put(string name, string value)
        {
            map.Add(name, value);
        }

        public string Get(string name)
        {
            if(map.ContainsKey(name))
            {
                return map[name];
            }

            throw new MissingValueException();
        }

        public IEnumerable<KeyValuePair<string, string>> AllVariables
        {
            get { return map;}
        }
    }
}