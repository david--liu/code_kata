using NUnit.Framework;

namespace code_kata.SpreadSheet.Test
{
    [TestFixture]
    public class SpreadSheetTest
    {
        [Test]
        public void ThatCellsAreEmptyByDefault()
        {
            var sheet = new Sheet();
            Assert.AreEqual("", sheet.get("A1"));
            Assert.AreEqual("", sheet.get("ZX347"));
        }

        [Test]
        public void testThatTextCellsAreStored()
        {
            var sheet = new Sheet();
            var theCell = "A21";

            sheet.put(theCell, "A string");
            Assert.AreEqual("A string", sheet.get(theCell));

            sheet.put(theCell, "A different string");
            Assert.AreEqual("A different string", sheet.get(theCell));

            sheet.put(theCell, "");
            Assert.AreEqual("", sheet.get(theCell));
        }

        [Test]
        public void testThatManyCellsExist()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "First");
            sheet.put("X27", "Second");
            sheet.put("ZX901", "Third");

            Assert.AreEqual("First", sheet.get("A1"));
            Assert.AreEqual("Second", sheet.get("X27"));
            Assert.AreEqual("Third", sheet.get("ZX901"));

            sheet.put("A1", "Fourth");
            Assert.AreEqual("Fourth", sheet.get("A1"));
            Assert.AreEqual("Second", sheet.get("X27"));
            Assert.AreEqual("Third", sheet.get("ZX901"));
        }

        [Test]
        public void testThatNumericCellsAreIdentifiedAndStored()
        {
            var sheet = new Sheet();
            var theCell = "A21";

            sheet.put(theCell, "X99"); // "Obvious" string
            Assert.AreEqual("X99", sheet.get(theCell));

            sheet.put(theCell, "14"); // "Obvious" number
            Assert.AreEqual("14", sheet.get(theCell));

            sheet.put(theCell, " 99 X"); // Whole string must be numeric
            Assert.AreEqual(" 99 X", sheet.get(theCell));

            sheet.put(theCell, " 1234 "); // Blanks ignored
            Assert.AreEqual("1234", sheet.get(theCell));

            sheet.put(theCell, " "); // Just a blank
            Assert.AreEqual(" ", sheet.get(theCell));
        }

        [Test]
        public void testThatWeHaveAccessToCellLiteralValuesForEditing()
        {
            var sheet = new Sheet();
            var theCell = "A21";

            sheet.put(theCell, "Some string");
            Assert.AreEqual("Some string", sheet.getLiteral(theCell));

            sheet.put(theCell, " 1234 ");
            Assert.AreEqual(" 1234 ", sheet.getLiteral(theCell));

            sheet.put(theCell, "=7"); // Foreshadowing formulas:)
            Assert.AreEqual("=7", sheet.getLiteral(theCell));
        }

        [Test]
        public void testFormulaSpec()
        {
            Sheet sheet = new Sheet();
            sheet.put("B1", " =7"); // note leading space
            Assert.AreEqual(" =7", sheet.get("B1"));
            Assert.AreEqual(" =7", sheet.getLiteral("B1"));
        }

        [Test]
        public void testConstantFormula()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=7");
            Assert.AreEqual("=7",sheet.getLiteral("A1"));
            Assert.AreEqual("7", sheet.get("A1"));
        }

        [Test]
        public void testParentheses()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=(7)");
            Assert.AreEqual("7", sheet.get("A1"));
        }

        [Test]
        public void testDeepParentheses()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=((((10))))");
            Assert.AreEqual("10", sheet.get("A1"));
        }

        [Test]
        public void testMultiply()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=2*3*4");
            Assert.AreEqual("24", sheet.get("A1"));
        }

        [Test]
        public void testAdd()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=71+2+3");
            Assert.AreEqual("76", sheet.get("A1"));
        }

        [Test]
        public void testPrecedence()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=7+2*3");
            Assert.AreEqual("13", sheet.get("A1"));
        }

        [Test]
        public void testFullExpression()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=7*(2+3)*((((2+1))))");
            Assert.AreEqual("105", sheet.get("A1"));
        }

        [Test]
        public void testSimpleFormulaError()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=7*");
            Assert.AreEqual("#Error", sheet.get("A1"));
        }


        [Test]
        public void testParenthesisError()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=(((((7))");
            Assert.AreEqual("#Error", sheet.get("A1"));
        }


        [Test]
        public void testThatCellReferenceWorks()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "8");
            sheet.put("A2", "=A1");
            Assert.AreEqual("8", sheet.get("A2"));

        }

        [Test]
        public void testThatCellChangesPropagate()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "8");
            sheet.put("A2", "=A1");
            Assert.AreEqual("8", sheet.get("A2"));

            sheet.put("A1", "9");
            Assert.AreEqual("9", sheet.get("A2"));
        }

        [Test]
        public void testThatFormulasKnowCellsAndRecalculate()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "8");
            sheet.put("A2", "3");
            sheet.put("B1", "=A1*(A1-A2)+A2/3");
            Assert.AreEqual("41", sheet.get("B1"));

            sheet.put("A2", "6");
            Assert.AreEqual("18", sheet.get("B1"));
        }

        [Test]
        public void testThatDeepPropagationWorks()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "8");
            sheet.put("A2", "=A1");
            sheet.put("A3", "=A2");
            sheet.put("A4", "=A3");
            Assert.AreEqual("8", sheet.get("A4"));

            sheet.put("A2", "6");
            Assert.AreEqual("6", sheet.get("A4"));
        }


        [Test]
        public void testThatFormulaWorksWithManyCells()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "10");
            sheet.put("A2", "=A1+B1");
            sheet.put("A3", "=A2+B2");
            sheet.put("A4", "=A3");
            sheet.put("B1", "7");
            sheet.put("B2", "=A2");
            sheet.put("B3", "=A3-A2");
            sheet.put("B4", "=A4+B3");

            Assert.AreEqual("34", sheet.get("A4"));
            Assert.AreEqual("51", sheet.get("B4"));
        }

        [Test]
        public void testThatCircularReferencesAdmitIt()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=A1");
            Assert.AreEqual("#Circular", sheet.get("A1"));
        }


        [Test]
        public void testThatMultiCircularReferencesAdmitIt()
        {
            Sheet sheet = new Sheet();
            sheet.put("A1", "=A3");
            sheet.put("A2", "=A1");
            sheet.put("A3", "=A2");
            Assert.AreEqual("#Circular", sheet.get("A1"));
            Assert.AreEqual("#Circular", sheet.get("A2"));
            Assert.AreEqual("#Circular", sheet.get("A3"));
        }

    }


}