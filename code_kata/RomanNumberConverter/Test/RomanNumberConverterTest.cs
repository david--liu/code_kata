using System;
using NUnit.Framework;

namespace code_kata.RomanNumberConverter.Test
{
    [TestFixture]
    public class RomanNumberConverterTest
    {

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ShouldNotAcceptNegativeNumber()
        {
            RomanNumberConverter.ConvertToRoman(-1);
        }
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ShouldNotAcceptNumberGreaterThanTenThousands()
        {
            RomanNumberConverter.ConvertToRoman(9000);
        }

        [Test]
        public void ShouldConvertSimpleOnes()
        {
            Assert.AreEqual("I", RomanNumberConverter.ConvertToRoman(1));
            Assert.AreEqual("V", RomanNumberConverter.ConvertToRoman(5));
            Assert.AreEqual("X", RomanNumberConverter.ConvertToRoman(10));
            Assert.AreEqual("L", RomanNumberConverter.ConvertToRoman(50));
            Assert.AreEqual("C", RomanNumberConverter.ConvertToRoman(100));
            Assert.AreEqual("D", RomanNumberConverter.ConvertToRoman(500));
            Assert.AreEqual("M", RomanNumberConverter.ConvertToRoman(1000));
        }

        [Test]
        public void ShouldReturnSimpleCombination()
        {
            Assert.AreEqual("II", RomanNumberConverter.ConvertToRoman(2));
            Assert.AreEqual("III", RomanNumberConverter.ConvertToRoman(3));

            Assert.AreEqual("XX", RomanNumberConverter.ConvertToRoman(20));
            Assert.AreEqual("XXX", RomanNumberConverter.ConvertToRoman(30));

            Assert.AreEqual("CC", RomanNumberConverter.ConvertToRoman(200));
            Assert.AreEqual("CCC", RomanNumberConverter.ConvertToRoman(300));

            Assert.AreEqual("MM", RomanNumberConverter.ConvertToRoman(2000));
            Assert.AreEqual("MMM", RomanNumberConverter.ConvertToRoman(3000));

        }

        [Test]
        public void ShouldUseSubstractionWhenDigitIsFourOrNine()
        {
            Assert.AreEqual("IV", RomanNumberConverter.ConvertToRoman(4));
            Assert.AreEqual("IX", RomanNumberConverter.ConvertToRoman(9));

            Assert.AreEqual("XL", RomanNumberConverter.ConvertToRoman(40));
            Assert.AreEqual("XC", RomanNumberConverter.ConvertToRoman(90));

            Assert.AreEqual("CD", RomanNumberConverter.ConvertToRoman(400));
            Assert.AreEqual("CM", RomanNumberConverter.ConvertToRoman(900));

        }


        [Test]
        public void ShouldPassGoogleTest()
        {
            Assert.AreEqual("MCMLIV", RomanNumberConverter.ConvertToRoman(1954));
            Assert.AreEqual("MCMXC", RomanNumberConverter.ConvertToRoman(1990));
        }

        [Test]
        public void ShouldConvertRomanToNumber()
        {
            Assert.AreEqual(1954, RomanNumberConverter.ConvertFromRoman("MCMLIV"));
            Assert.AreEqual(1990, RomanNumberConverter.ConvertFromRoman("MCMXC"));
            Assert.AreEqual(1910, RomanNumberConverter.ConvertFromRoman("MDCCCCX"));
            
        }
    }
}