using System.Collections.Generic;
using System.Text;

namespace code_kata.SqlGenerator
{
    public class WhereClause : IWhereClause
    {
        private readonly List<string> statements = new List<string>();

        public WhereClause(string statement)
        {
            statements.Add(statement);
        }

        public string Statement
        {
            get
            {
                var builder = new StringBuilder();

                builder.Append(" where ");
                foreach (var statement in statements)
                {
                    builder.Append(statement);
                    builder.Append(" and ");
                }

                builder.Remove(builder.Length - 5, 5);
                return builder.ToString();
            }
        }

        public void AddStatement(string statement)
        {
            statements.Add(statement);
        }
    }
}