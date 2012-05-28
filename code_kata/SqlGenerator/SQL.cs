using code_kata.SqlGenerator.Test;

namespace code_kata.SqlGenerator
{
    public class SQL
    {
        public static SelectStatement Select(string[] columns)
        {
            return new SelectStatement(columns);
        }

        public static SelectStatement SelectAll
        {
            get { return new SelectStatement(new string[]{"*"}); }
        }

        public static UpdateStatement Update(string table)
        {
            return new UpdateStatement(table);
        }

        public static DeleteStatement Delete(string table)
        {
            return new DeleteStatement(table);
        }

        public static InsertStatement Insert(string table)
        {
            return new InsertStatement(table);
        }
    }
}