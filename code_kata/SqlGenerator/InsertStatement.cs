using System.Collections.Generic;
using System.Text;

namespace code_kata.SqlGenerator
{
    public class InsertStatement : ISqlStatement
    {
        private readonly string table;
        private Dictionary<string,object> map = new Dictionary<string, object>();

        public InsertStatement(string table)
        {
            this.table = table;
        }

        public string Statement
        {
            get { var builder = new StringBuilder();
                builder.Append("insert into ");
                builder.Append(table);
                builder.Append("(");

                foreach (var column in map.Keys)
                {
                    builder.Append(column);
                    builder.Append(",");
                }

                builder.Remove(builder.Length - 1, 1);
                builder.Append(") values(");

                foreach (var value in map.Values)
                {
                    builder.Append(value);
                    builder.Append(",");
                        
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append(")");

                return builder.ToString();
            }
        }

        public InsertStatement Column(string column, object value)
        {
            map.Add(column, value);
            return this;
        }
    }
}