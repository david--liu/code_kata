using System.Text;

namespace code_kata.SqlGenerator
{
    public class SelectStatement
    {
        private readonly string[] columns;
        private string table;
        private WhereClause whereClause;

        public SelectStatement(string[] columns)
        {
            this.columns = columns;
        }

        public SelectStatement From(string newTable)
        {
            table = newTable;

            return this;
        }


        public string Sql
        {
            get
            {
                var builder = new StringBuilder();
                builder.Append("select ");
                foreach (var column in columns)
                {
                    builder.Append(column).Append(',');
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append(" from ");
                builder.Append(table);

                if (whereClause != null)
                {
                    builder.Append(whereClause.Statement);
                }
                return builder.ToString();
            }
        }


        public SelectStatement Where(string statement)
        {
            whereClause = new WhereClause(statement);
            return this;
        }

        public SelectStatement And(string and)
        {
            whereClause.AddStatement(and);
            return this;
        }
    }
}