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
            new ConsoleInteraction(console);

            console.AssertWasCalled(x => x.WriteLine("Shape: (C)ircle or (R)ectangle?"));

        }
    }
}