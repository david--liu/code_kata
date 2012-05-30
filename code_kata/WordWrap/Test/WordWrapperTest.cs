using NUnit.Framework;
using System.Linq;

namespace code_kata.WordWrap.Test
{
    [TestFixture]
    public class WordWrapperTest
    {

        [Test]
        public void ShouldReturnTheSame_WhenTheLengthOfTheInputIsLessThanTheRowLength()
        {
            var testInput = "This is a test";
            Assert.AreEqual(testInput, new WordWrapper(30).Wrap(testInput).First());
        }
        
        
        [Test]
        public void ShouldReturnMultipleLines_WhenTheLengthOfTheInputIsGreaterThanTheRowLength()
        {
            var testInput = "This is a test";
            Assert.IsTrue(new WordWrapper(2).Wrap(testInput).Count() > 1);
        }

        [Test]
        public void ShouldWrapUsingRowLength()
        {
            var testInput = "abcdef";
            var result = new WordWrapper(3).Wrap(testInput).ToList();
            Assert.IsTrue(result.Count == 2);
            Assert.AreEqual("abc", result[0]);
            Assert.AreEqual("def", result[1]);
        }
        [Test]
        public void ShouldWrapUsingRowLength_AndTrimLeadingSpaces()
        {
            var testInput = "abc def";
            var result = new WordWrapper(3).Wrap(testInput).ToList();
            Assert.IsTrue(result.Count == 2);
            Assert.AreEqual("abc", result[0]);
            Assert.AreEqual("def", result[1]);
        }
        
        [Test]
        public void ShouldWrapUsingRowLength_AndTrimLeadingSpacesOnly()
        {
            var testInput = "ab  def";
            var result = new WordWrapper(3).Wrap(testInput).ToList();
            Assert.IsTrue(result.Count == 2);
            Assert.AreEqual("ab ", result[0]);
            Assert.AreEqual("def", result[1]);
        }

        [Test]
        public void ShouldWrapUsingRowLength_AndTrimLeadingSpaces_Complex()
        {
            var testInput = "abcdef ghi";
            var result = new WordWrapper(3).Wrap(testInput).ToList();
            Assert.IsTrue(result.Count == 3);
            Assert.AreEqual("abc", result[0]);
            Assert.AreEqual("def", result[1]);
            Assert.AreEqual("ghi", result[2]);
        }

        [Test]
        public void ShouldWrapUsingRowLength_AndTrimLeadingSpacesOnly_Complex()
        {
            var testInput = "a b c d e f";
            var result = new WordWrapper(3).Wrap(testInput).ToList();
            Assert.IsTrue(result.Count == 3);
            Assert.AreEqual("a b", result[0]);
            Assert.AreEqual("c d", result[1]);
            Assert.AreEqual("e f", result[2]);
        }


    }
}   