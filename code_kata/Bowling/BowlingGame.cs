using System;
using System.Collections.Generic;
using System.Linq;
using code_kata.Bowling.Test;

namespace code_kata.Bowling
{
    public class BowlingGame
    {
        private LinkedList<IFrame> frames = new LinkedList<IFrame>();
        private IFrame currentFrame;
        private int currentFrameNumber = 0;
        public int GetScoreOfFrame(int frame)
        {
            var current  = frames.First;
            int score = 0;
            for (int i = 0; i < frame; i++)
            {
                score += current.Value.PinsDown;
                if(current.Value.IsStrike)
                {
                    if(current.Next.Value.IsStrike)
                    {
                       
                        score += current.Next.Value.FirstThrow + current.Next.Next.Value.FirstThrow;
                    }
                    else if(current.Next.Value.IsSpare)
                    {
                        score += 10;
                    }
                    else
                    {
                        score += current.Next.Value.FirstThrow + current.Next.Value.SecondThrow;
                    }
                }
                else if(current.Value.IsSpare)
                {
                    score += current.Next.Value.FirstThrow;
                }
                current = current.Next;
            }

            return score;

        }

        public BowlingGame()
        {
            CreateNewFrame();
        }

        private void CreateNewFrame()
        {
            if (currentFrameNumber < 9)
            {
                currentFrame = new Frame();

                ++currentFrameNumber;
                
                frames.AddLast(currentFrame);
                
            }
            else if(currentFrameNumber == 9)
            {
                ++currentFrameNumber;
                currentFrame = new TensFrame();
                frames.AddLast(currentFrame);
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public IEnumerable<IFrame> Frames
        {
            get { return frames.AsEnumerable(); }
        }

        public int FramesPlaying
        {
            get { return frames.Count; }
        }

        public int Score
        {
            get
            {
                if (frames.All(x => x.IsComplete))
                {
                    return GetScoreOfFrame(10);
                }

                throw new GameNotCompleteException();

            }
        }

        public BowlingGame Throw(int pins)
        {
            currentFrame.Throw(pins);
            if(currentFrame.IsComplete && currentFrameNumber < 10)
            {
                CreateNewFrame();
            }
            return this;
        }


    }
}