namespace code_kata.ConsoleInteraction
{
    public class ConsoleInteraction
    {
        private IConsole console;

        public ConsoleInteraction(IConsole console)
        {
            this.console = console;
        }

 
        public void StartConsole()
        {
            PrintFirstMessage();
            var input = GetUserInput();
            if(input.ToUpper() == "C")
            {
                console.WriteLine("Radius of the circle?");
                var radius = console.ReadRadius();

                PrintCircleMessage(radius);

            }
            else if(input.ToUpper() == "R")
            {
                console.WriteLine("Rectangle side A length?");
                var lengthA = console.ReadRectangleSideALength();
                console.WriteLine("Rectangle side B length?");
                var lengthB = console.ReadRectangleSideBLength();

                PrintRectangleMessages(lengthA, lengthB);
            }
            else
            {
                console.WriteLine("Invalid option.");
                PrintFirstMessage();
            }
            
        }

        private void PrintFirstMessage()
        {
            console.WriteLine("Shape: (C)ircle or (R)ectangle?");
        }

        private string GetUserInput()
        {
            return console.ReadLine();
        }

        private void PrintCircleMessage(decimal radius)
        {
            PrintAreaAndCircumference(3.14m * radius * radius, 3.14m * 2 * radius);
        }

        private void PrintRectangleMessages(decimal sideA, decimal sideB)
        {
            PrintAreaAndCircumference(sideA * sideB, (sideA + sideB)*2);
        }

        private void PrintAreaAndCircumference(decimal area, decimal circum)
        {
            console.WriteLine(string.Format("Area={0}", area));
            console.WriteLine(string.Format("Circumference={0}", circum));
            
        }


    }
}