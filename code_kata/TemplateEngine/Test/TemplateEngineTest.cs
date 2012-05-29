using System.Text.RegularExpressions;
using NUnit.Framework;

namespace code_kata.TemplateEngine.Test
{
    [TestFixture]
    public class TemplateEngineTest
    {
        [Test]
        public void ShouldEvaluateSingleVariableExpression()
        {
            var mapOfVariables = new VariableMap();
            mapOfVariables.Put("name", "Cenk");
            var result = TemplateEngine.Evaluate("Hello {$name}", mapOfVariables);
            Assert.AreEqual("Hello Cenk", result);
        }

        [Test]
        public void ShouldEvaluateWithMultipleExpressions()
        {
            var mapOfVariables = new VariableMap();
            mapOfVariables.Put("firstName", "Cenk");
            mapOfVariables.Put("lastName", "Civici");
            var result = TemplateEngine.Evaluate("Hello {$firstName} {$lastName}", mapOfVariables);
            
            Assert.AreEqual("Hello Cenk Civici", result);
        }

        [Test]
        [ExpectedException(typeof(MissingValueException))]
        public void ShouldGiveErrorIfVariableDoesNotExistInTheMap()
        {
            var mapOfVariables = new VariableMap();
            var result = TemplateEngine.Evaluate("Hello {$name}", mapOfVariables);
        }

        [Test]
        public void ShouldEvaluateComplexCase()
        {
            var mapOfVariables = new VariableMap();
            mapOfVariables.Put("name", "Cenk");
            var result = TemplateEngine.Evaluate("Hello ${{$name}}", mapOfVariables);

            Assert.AreEqual("Hello ${Cenk}", result);
        }

        [Test]
        public void ShouldGetAllVariables()
        {
            var allVariables = TemplateEngine.GetAllVariables("Hello {$firstName} {$lastName}");
            Assert.IsNotEmpty(allVariables);
            Assert.Contains("firstName", allVariables);
            Assert.Contains("lastName", allVariables);

        }

        [Test]
        public void ShouldGetAllVariablesComplex()
        {
            var allVariables = TemplateEngine.GetAllVariables("Hello ${{$name}}");
            Assert.IsNotEmpty(allVariables);
            Assert.Contains("name", allVariables);

        }
    }
}