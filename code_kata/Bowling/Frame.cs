using System;
using code_kata.Bowling.Test;

namespace code_kata.Bowling
{
    public class Frame : IFrame
    {
        public const int TotalPins = 10;
        private int pinsLeft = TotalPins;
        private bool isNew = true;

        private int downCounter = 0;
        private int firstThrow = 0;
        private int secondThrow;

        public void Throw(int pins)
        {
            if (pins > pinsLeft || IsComplete)
            {
                throw new InvalidOperationException();
            }
            if(isNew)
            {
                firstThrow = pins;
                isNew = false;
            }
            else
            {
                secondThrow = pins;
            }
            
            ++downCounter;
            pinsLeft = pinsLeft - pins;
        }

        public int PinsLeft
        {
            get { return pinsLeft; }
        }

        public int PinsDown
        {
            get { return TotalPins - pinsLeft; }
        }

        public bool IsNew
        {
            get { return isNew; }
        }

        public bool IsAllCleared
        {
            get { return pinsLeft == 0; }
        }

        public bool IsComplete
        {
            get { return !IsNew && (IsAllCleared || downCounter == 2); }
        }

        public bool IsStrike
        {
            get { return downCounter == 1 && IsAllCleared; }
        }

        public bool IsSpare
        {
            get { return downCounter == 2 && IsAllCleared; }
        }

        public bool IsLastFrame
        {
            get { return false; }
        }

        public int FirstThrow
        {
            get { return firstThrow; }
        }

        public int SecondThrow
        {
            get { return secondThrow; }
        }
    }
}