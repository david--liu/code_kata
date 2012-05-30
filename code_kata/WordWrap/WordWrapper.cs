using System.Collections.Generic;
using System.Text;

namespace code_kata.WordWrap
{
    public class WordWrapper
    {
        private readonly int rowLength;

        public WordWrapper(int rowLength)
        {
            this.rowLength = rowLength;
        }

        public IEnumerable<string> Wrap(string input)
        {
            var builder = new StringBuilder();
            int pos = 0;
            var result = new List<string>();
            foreach (var chr in input)
            {
                if (!(chr == ' ' && pos == 0))
                {
                    builder.Append(chr);
                    ++pos;
                    if (pos == rowLength)
                    {
                        result.Add(builder.ToString());
                        builder.Clear();
                        pos = 0;
                    }
                }
            }

            if(builder.Length > 0)
                result.Add(builder.ToString());

            return result.AsReadOnly();
        }
    }
}