using System;

namespace AdventOfCode2019.Day10
{
    public static class Geometry
    {
        public static double GetLength(Point a, Point b)
        {
            double s1 = Math.Abs(a.x - b.x);
            double s2 = Math.Abs(a.y - b.y);

            return Math.Sqrt((s1 * s1) + (s2 * s2));
        }

        public static double GetAngle(Point a, Point b)
        {
            int s3 = 1;

            // Create a point 1 unit above A to create a virtual triangle.
            var c = new Point(a.x, a.y - s3);

            var s1 = GetLength(a, b);
            var s2 = GetLength(b, c);

            var radians = Math.Acos(
                ((s1 * s1) + (s3 * s3) - (s2 * s2)) /
                (2 * s1 * s3));

            var degrees = Math.Round(RadiansToDegrees(radians), 2);

            if(b.x > a.x)
            {
                degrees = 360 - degrees;
            }

            return degrees;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }
    }
}
