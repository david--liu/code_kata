using System;
using System.Drawing;

namespace code_kata.Line2d
{
    public class Line2d
    {
        private readonly Point pointOne;
        private readonly Point pointTwo;

        public Line2d(Point pointOne, Point pointTwo)
        {
            this.pointOne = pointOne;
            this.pointTwo = pointTwo;
        }

        public  int X1
        {
            get { return pointOne.X; }
        }
        public  int X2
        {
            get { return pointTwo.X; }
        }
        public  int Y1
        {
            get { return pointOne.Y; }
        }
        public  int Y2
        {
            get { return pointTwo.Y; }
        }

        //http://local.wasp.uwa.edu.au/~pbourke/geometry/lineline2d/

        public bool HasIntersectWith(Line2d other)
        {
            double d = (other.Y2 - other.Y1)*(X2 - X1) - (other.X2 - other.X1)*(Y2 - Y1);
            double na = (other.X2 - other.X1)*(Y1 - other.Y1) - (other.Y2 - other.Y1)*(X1 - other.X1);
            double nb = (X2 - X1)*(Y1 - other.Y1) - (Y2 - Y1)*(X1 - other.X1);

            if(d == 0)
            {
                return false;
            }

            double ua = na/d;
            double ub = nb/d;

            // The fractional point will be between 0 and 1 inclusive if the lines
            // intersect.  If the fractional calculation is larger than 1 or smaller
            // than 0 the lines would need to be longer to intersect.

            return (ua >= 0 && ua <= 1 && ub >= 0 && ub <= 1);
        }
    }
}