using System;
using System.Linq;

namespace code_kata.Bowling.Test
{
    public class TensFrame : IFrame
    {
        private Score[] throws = new Score[3];


        public bool IsComplete
        {
            get
            {
                var isFirstTwoNonSpare = throws[0] != null && throws[1] != null && (FirstThrow + SecondThrow) < 10;

                return throws.All(x => x != null) || isFirstTwoNonSpare;
            }
        }

        public int FirstThrow
        {
            get { return throws[0].Pins; }
        }

        public int SecondThrow 
        {
            get { return throws[1].Pins; }
        }

        public bool IsStrike
        {
            get { return false; }
        }

        public bool IsSpare
        {
            get { return false; }
        }

        public bool IsLastFrame
        {
            get { return true; }
        }

        public int ThirdThrow
        {
            get { return throws[2].Pins; }
        }

        
        public void Throw(int pins)
        {
 
            if (IsComplete)
            {
                throw new InvalidOperationException();
            }

            for (int i = 0; i < 3; i++)
            {
                if (throws[i] == null)
                {
                    throws[i] = new Score(pins);
                    return;
                }
            }
        }

        public int PinsDown
        {
            get { return throws.Where(x => x != null).Sum(x => x.Pins); }
        }

        private class Score
        {
            private readonly int pins;

            public int Pins
            {
                get { return pins; }
            }

            public Score(int pins)
            {
                this.pins = pins;
            }
        }
    }
}