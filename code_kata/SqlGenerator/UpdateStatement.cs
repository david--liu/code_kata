using System.Collections.Generic;
using System.Text;

namespace code_kata.SqlGenerator
{
    public class UpdateStatement : ISqlStatement
    {
        private readonly string table;
        Dictionary<string, object> setMap = new Dictionary<string, object>();
        private WhereClause whereClause;

        public UpdateStatement(string table)
        {
            this.table = table;
        }

        public string Statement
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("update ");
                builder.Append(table);
                builder.Append(" set ");

                foreach (var set in setMap)
                {
                    builder.Append(set.Key);
                    builder.Append(" = ");
                    builder.Append(set.Value);
                    builder.Append(", ");
                }

                builder.Remove(builder.Length - 2, 2);

                if(whereClause != null)
                {
                    builder.Append(whereClause.Statement);
                }

                return builder.ToString();

            }
        }

        public UpdateStatement Set(string column, object value)
        {
            setMap.Add(column, value);
            return this;
        }

        public UpdateStatement Where(string where)
        {
            whereClause = new WhereClause(where);
            return this;
        }


        public UpdateStatement And(string where)
        {
            whereClause.AddStatement(where);
            return this;
        }
    }
}