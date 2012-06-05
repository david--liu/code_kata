using System.Threading;
using NUnit.Framework;
using Rhino.Mocks;

namespace code_kata.RefreshingCache.Test
{
    [TestFixture]
    public class RefreshingCacheTest
    {
        [Test]
        public void WhenGetValueTheFirstTime_ShouldCallTheRemoteService()
        {
            var service = MockRepository.GenerateMock<IService>();
            var cache = new RefreshingCache(service, 5, 5);
            cache.GetValue("Test");

            service.AssertWasCalled(x => x.GetValue("Test"));
        }

        [Test]
        public void WhenGetValueMoreThanOneTime_ShouldOnCallTheProxyOnce()
        {
            var service = MockRepository.GenerateMock<IService>();
            var cache = new RefreshingCache(service, 5, 5);

            service.Expect(x => x.GetValue("Test"))
                .Return(string.Empty)
                .Repeat.Once();

            cache.GetValue("Test");

            service.VerifyAllExpectations();
        }

        [Test]
        public void GetValue_WhenTheCacheIsStale_ShouldCallTheRemoteProxy()
        {
            var service = MockRepository.GenerateMock<IService>();
            var cache = new RefreshingCache(service, 5, 1);


            service.Expect(x => x.GetValue("Test"))
                .Return(string.Empty)
                .Repeat.Twice();

            cache.GetValue("Test");

            Thread.Sleep(1000);

            cache.GetValue("Test");

            service.VerifyAllExpectations();
        }

        [Test]
        public void GetValue_WhenTheCacheIsFull_ShouldPushTheLeastRecentlyUsedOff()
        {
            var service = MockRepository.GenerateMock<IService>();
            var cache = new RefreshingCache(service, 2, 1);


            service.Expect(x => x.GetValue("key1"))
                .Return(string.Empty)
                .Repeat.Times(2);

            service.Expect(x => x.GetValue("key2"))
                .Return(string.Empty)
                .Repeat.Times(1);

            service.Expect(x => x.GetValue("key3"))
                .Return(string.Empty)
                .Repeat.Times(1);

            cache.GetValue("key1");
            cache.GetValue("key2");
            cache.GetValue("key3");
            cache.GetValue("key1");

            service.VerifyAllExpectations();



        }


    }
}