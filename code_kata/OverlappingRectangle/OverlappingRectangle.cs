using System;

namespace code_kata.OverlappingRectangle
{
    public class OverlappingRectangle
    {
        private readonly int x1;
        private readonly int y1;
        private readonly int x2;
        private readonly int y2;

        public OverlappingRectangle(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public int Area
        {
            get { return Math.Abs((x2 - x1)*(y2 - y1)); }
        }

        public int Circumference    
        {
            get { return (Math.Abs(x2 - x1) + Math.Abs(y2 - y1)) * 2; }
        }

        public int MinX
        {
            get { return x1 > x2 ? x2 : x1; }
        }

        public int MinY
        {
            get { return y1 > y2 ? y2 : y1; }
        }

        public int MaxX
        {
            get { return x1 < x2 ? x2 : x1; }
        }

        public int MaxY
        {
            get { return y1 < y2 ? y2 : y1; }
        }

        public bool IsOverlappedWith(OverlappingRectangle other)
        {
            return IsAnyOfTheCornerPointsWithIn(other) || other.IsAnyOfTheCornerPointsWithIn(this);
        }

        public bool IsAnyOfTheCornerPointsWithIn(OverlappingRectangle other)
        {
            var isBottomLeftWithIn = IsPointWith(other, MinX, MinY);
            var isBottomRightWithIn = IsPointWith(other, MaxX, MinY);
            var isTopLeftWithIn = IsPointWith(other, MinX, MaxY);
            var isTopRightWithIn = IsPointWith(other, MaxX, MaxY);
            return isBottomLeftWithIn || isBottomRightWithIn || isTopLeftWithIn || isTopRightWithIn;
        }

        private static bool IsPointWith(OverlappingRectangle other, int x, int y)
        {
            return x >= other.MinX && x <= other.MaxX && y >= other.MinY && y <= other.MaxY;
        }
    }
}