using NUnit.Framework;

namespace code_kata.TemplateEngine.Test
{
    [TestFixture]
    public class VariableMapTest
    {
        [Test]
        public void ShouldPutAndGetValue()
        {
            var map = new VariableMap();
            map.Put("ABC", "CDE");
            Assert.AreEqual("CDE", map.Get("ABC"));
        }

        [Test]
        [ExpectedException(typeof(MissingValueException))]
        public void ShouldThrowException()
        {
            var map = new VariableMap();
            map.Get("ABC");
            
        }
    }
}