using System;
using NUnit.Framework;

namespace code_kata.EndTrimmer.Test
{
    [TestFixture]
    public class EndTrimmerTest
    {

        [Test]
        public void ShouldTrimEndingSpaces()
        {
            Assert.AreEqual("abc", EndTrimmer.Trim("abc "));
        }

        [Test]
        public void ShouldTrimEndingTabs()
        {
            Assert.AreEqual("abc", EndTrimmer.Trim("abc\t"));
        }

        [Test]
        public void ShouldNotTrimNewLine()
        {
            Assert.AreEqual("abc\n", EndTrimmer.Trim("abc\n"));
        }


        [Test]
        public void ShouldNotTrimLeadingSpaces()
        {
            Assert.AreEqual(" abc", EndTrimmer.Trim(" abc"));
        }

        [Test]
        public void ShouldNotTrimReturns()
        {
            Assert.AreEqual("ab\r\ncd\n", EndTrimmer.Trim( "ab\r\ncd\n"));
            
        }
    }

    public class EndTrimmer
    {
        public static string Trim(string line)
        {
            return line.TrimEnd(' ').TrimEnd('\t');
        }
    }
}