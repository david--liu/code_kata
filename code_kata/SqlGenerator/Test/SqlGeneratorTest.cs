using NUnit.Framework;

namespace code_kata.SqlGenerator.Test
{
    public class SqlGeneratorTest
    {
        //SQL.Select(column[]).From(string).Where...
        [TestFixture]
        public class SqlSelectTest
        {
            [Test]
            public void ShouldGenerateSimpliestSql()
            {
                Assert.AreEqual("select column from table", SQL.Select(new[] {"column"}).From("table").Sql);
            }

            [Test]
            public void ShouldHandleMultipleColumns()
            {
                Assert.AreEqual("select column1,column2 from table", SQL.Select(
                    new[]
                        {
                            "column1", "column2"
                        }).From("table").Sql);
            }

            [Test]
            public void ShouldSupportWhereStatement()
            {
                Assert.AreEqual("select column from table where column = 'abc'",
                                SQL.Select(new[] {"column"}).From("table").Where("column = 'abc'").Sql);
            }

            [Test]
            public void ShouldSupportWhereAndStatement()
            {
                Assert.AreEqual("select column from table where column = 'abc' and column2 = 2",
                                SQL.Select(new[] {"column"}).From("table").Where("column = 'abc'").And("column2 = 2").
                                    Sql);
                Assert.AreEqual("select column from table where column = 'abc' and column2 = 2 and column3 = 3",
                                SQL.Select(new[] {"column"}).From("table").Where("column = 'abc'").And("column2 = 2")
                                    .And("column3 = 3").Sql);
            }

            [Test]
            public void ShouldSupportStar()
            {
                Assert.AreEqual("select * from table", SQL.SelectAll.From("table").Sql);
            }
        }


        [TestFixture]
        public class SqlUpdateTest
        {
            [Test]
            public void ShouldUpdateAll()
            {
                Assert.AreEqual("update table set column = 1", SQL.Update("table").Set("column", 1).Statement);
            }

            [Test]
            public void ShouldUpdateMultipleColumnsForAll()
            {
                Assert.AreEqual("update table set column = 1, column2 = 2, column3 = 'ABC'",
                                SQL.Update("table").Set("column", 1).Set("column2", 2).Set("column3", "'ABC'").Statement);
            }

            [Test]
            public void ShouldUpdateWithWhereClause()
            {
                Assert.AreEqual("update table set column = 1 where column = 1",
                                SQL.Update("table").Set("column", 1).Where("column = 1").Statement);
                Assert.AreEqual("update table set column = 1 where column = 1 and column2 = 2",
                                SQL.Update("table").Set("column", 1).Where("column = 1").And("column2 = 2").Statement);
            }
        }

        [TestFixture]
        public class SqlDeleteTest

        {
            [Test]
            public void ShouldDeleteAll()
            {
                Assert.AreEqual("delete from table", SQL.Delete("table").Statement);
            }

            [Test]
            public void ShouldSupportWhereClause()
            {
                Assert.AreEqual("delete from table where column1 = 1",
                                SQL.Delete("table").Where("column1 = 1").Statement);
                Assert.AreEqual("delete from table where column1 = 1 and column2 = 2",
                                SQL.Delete("table").Where("column1 = 1").And("column2 = 2").Statement);
            }
        }

        [TestFixture]
        public class SqlInsertTest
        {
            [Test]
            public void ShouldInsert()
            {
                Assert.AreEqual("insert into table(column1) values(value1)",
                                SQL.Insert("table").Column("column1", "value1").Statement);
            }

            [Test]
            public void ShouldInsertMultipleColumns()
            {

                Assert.AreEqual("insert into table(column1,column2) values(value1,'value2')",
                                SQL.Insert("table").Column("column1", "value1").Column("column2", "'value2'").Statement);

            }
        }
    }
}