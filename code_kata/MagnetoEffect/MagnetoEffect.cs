using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace code_kata.MagnetoEffect
{
    public class MagnetoEffect
    {
        private readonly List<Point> points = new List<Point>();
        private readonly int radius;

        public MagnetoEffect(int radius)
        {
            this.radius = radius;
        }

        public void AddMagnetPoint(Point point)
        {
            points.Add(point);
        }

        public bool HasMagnetPoint(Point other)
        {
            return points.Exists(point => DistanceBetween(other, point) <= radius);
        }

        private static double DistanceBetween(Point other, Point point)
        {
            return Math.Sqrt(Math.Pow(other.Y - point.Y, 2) + Math.Pow(other.X - point.X, 2));
        }

        public Point FindBestAvailableMagnetPoint(Point other)
        {
            if (!HasMagnetPoint(other))
                return other;
            else
            {
                return points.Where(HasMagnetPoint).OrderBy(p => DistanceBetween(other, p)).First();
            }
        }
    }
}