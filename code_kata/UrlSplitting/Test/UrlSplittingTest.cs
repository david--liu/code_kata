using NUnit.Framework;

namespace code_kata.UrlSplitting.Test
{
    [TestFixture]
    public class UrlSplittingTest
    {

        [Test]
        public void ShouldGetProtocol()
        {
            Assert.AreEqual("http", new UrlSplitter(@"http://www.google.com").Protocol);
        }
        [Test]
        public void ShouldGetDomain()
        {
            Assert.AreEqual("www.google.com", new UrlSplitter(@"http://www.google.com").Domain);
        }

        [Test]
        public void ShouldGetPath()
        {
            Assert.AreEqual(string.Empty, new UrlSplitter(@"http://www.google.com").Path);
            Assert.AreEqual("path", new UrlSplitter(@"http://www.google.com/path").Path);
        }
    }
}