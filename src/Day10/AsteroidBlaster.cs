using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day10
{
    public static class AsteroidBlaster
    {
        // Blast the number of asteroids specified, and return the last asteroid blasted.
        public static Point BlastAsteroids(Dictionary<double, List<Point>> asteroidsPerAngle, int count)
        {
            var sortedKeys = asteroidsPerAngle.Keys.OrderBy(x =>
            {
                if(x == 0)
                {
                    return -1;
                }

                return x;
            }).ToList();

            for (int i = 0; i < sortedKeys.Count; i++)
            {
                double angle = sortedKeys.ElementAt(i);

                var lastAsteroid = asteroidsPerAngle[angle][0];

                // Vaporize the closest asteroid at this angle.
                asteroidsPerAngle[angle].RemoveAt(0);

                if(i == count - 1)
                {
                    return lastAsteroid;
                }

                if(i == asteroidsPerAngle.Keys.Count)
                {
                    i = 0;
                }
            }

            return new Point();
        }
    }
}
