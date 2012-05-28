using System.Text;

namespace code_kata.SqlGenerator
{
    public class DeleteStatement : ISqlStatement
    {
        private readonly string table;
        private WhereClause whereClause;

        public DeleteStatement(string table)
        {
            this.table = table;
        }

        public string Statement
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("delete from ");
                builder.Append(table);
                if (whereClause != null)
                    builder.Append(whereClause.Statement);

                return builder.ToString();
            }
        }

        public DeleteStatement Where(string where)
        {
            whereClause = new WhereClause(where);
            return this;
        }

        public DeleteStatement And(string and)
        {
            whereClause.AddStatement(and);
            return this;
        }
    }
}