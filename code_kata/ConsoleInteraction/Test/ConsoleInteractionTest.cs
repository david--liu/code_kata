using NUnit.Framework;
using Rhino.Mocks;

namespace code_kata.ConsoleInteraction.Test
{
    [TestFixture]
    public class ConsoleInteractionTest
    {
        [Test]
        public void ShouldPrintFirstMessage()
        {
            var console = MockRepository.GenerateMock<IConsole>();
            new ConsoleInteraction(console).StartConsole();

            console.AssertWasCalled(x => x.WriteLine("Shape: (C)ircle or (R)ectangle?"));
        }

        [Test]
        public void ShouldReadUserInput()
        {
            var console = MockRepository.GenerateMock<IConsole>();
            new ConsoleInteraction(console).StartConsole();
            console.AssertWasCalled(x => x.ReadLine());
        }

        [Test]
        public void ShouldNotAcceptOtherThan_C_or_R_AsUserInput()
        {
            var console = MockRepository.GenerateMock<IConsole>();
            console.Stub(x => x.ReadLine()).Return("N");
            new ConsoleInteraction(console).StartConsole();

            console.AssertWasCalled(x => x.WriteLine("Invalid option."));
            console.AssertWasCalled(x => x.WriteLine("Shape: (C)ircle or (R)ectangle?"));
        }

        [Test]
        public void ShouldAccept_C_or_R_AsUserInput()
        {
            var console = MockRepository.GenerateMock<IConsole>();
            console.Stub(x => x.ReadLine()).Return("C");
            new ConsoleInteraction(console).StartConsole();

            console.AssertWasNotCalled(x => x.WriteLine("Invalid option."));
        }

        [TestFixture]
        public class WhenTestingCircle
        {
            [Test]
            public void ShouldAskRadiusOfTheCircle()
            {
                var console = MockRepository.GenerateMock<IConsole>();
                console.Stub(x => x.ReadLine()).Return("C");
                new ConsoleInteraction(console).StartConsole();

                console.AssertWasCalled(x => x.WriteLine("Radius of the circle?"));
                console.AssertWasCalled(x => x.ReadRadius());
            }

            [Test]
            public void ShouldPrintAreaAndCircumference()
            {
                var console = MockRepository.GenerateMock<IConsole>();
                console.Stub(x => x.ReadLine()).Return("C");
                console.Stub(x => x.ReadRadius()).Return(5);
                new ConsoleInteraction(console).StartConsole();

                console.AssertWasCalled(x => x.WriteLine(string.Format("Area={0}", 3.14m*5m*5m)));
                console.AssertWasCalled(x => x.WriteLine(string.Format("Circumference={0}", 3.14m*5m*2m)));
            }
        }

        [TestFixture]
        public class WhenTestingRectangle
        {
            [Test]
            public void ShouldAskTwoSideLengthOfTheRectangle()
            {
                var console = MockRepository.GenerateMock<IConsole>();
                console.Stub(x => x.ReadLine()).Return("R");
                new ConsoleInteraction(console).StartConsole();

                console.AssertWasCalled(x => x.WriteLine("Rectangle side A length?"));
                console.AssertWasCalled(x => x.ReadRectangleSideALength());
                console.AssertWasCalled(x => x.WriteLine("Rectangle side B length?"));
                console.AssertWasCalled(x => x.ReadRectangleSideBLength());
            }

            [Test]
            public void ShouldPrintAreaAndCircumference()
            {
                var console = MockRepository.GenerateMock<IConsole>();
                console.Stub(x => x.ReadLine()).Return("R");
                console.Stub(x => x.ReadRectangleSideALength()).Return(5);
                console.Stub(x => x.ReadRectangleSideBLength()).Return(10);
                new ConsoleInteraction(console).StartConsole();

                console.AssertWasCalled(x => x.WriteLine(string.Format("Area={0}", 50m)));
                console.AssertWasCalled(x => x.WriteLine(string.Format("Circumference={0}", 30m)));
            }
        }
    }
}