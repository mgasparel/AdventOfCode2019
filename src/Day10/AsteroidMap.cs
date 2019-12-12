using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day10
{
    public class AsteroidMap
    {
        enum Bearing
        {
            Left = 0,
            Right = 1
        }

        public static char Asteroid = '#';

        public static char Space = '.';

        string[] map;

        public Point[] Asteroids;

        public AsteroidMap(string[] map)
        {
            this.map = map;
            this.Asteroids = GetAllAsteroids();
        }

        Point[] GetAllAsteroids()
        {
            var points = new List<Point>();

            for (int y = 0; y < map.Length; y++)
            for (int x = 0; x < map[y].Length; x++)
            {
                if(map[y][x] == Asteroid)
                {
                    points.Add(new Point(x, y));
                }
            }

            return points.ToArray();
        }

        public int CountVisibleAsteroids(Point source)
        {
            int visibleAsteroids = 0;
            var asteroidsPerAngle = new Dictionary<double, List<Point>>();

            foreach (Point asteroid in Asteroids)
            {
                if(asteroid.Equals(source))
                {
                    continue;
                }

                double angle = Geometry.GetAngle(source, asteroid);

                if(!asteroidsPerAngle.ContainsKey(angle))
                {
                    asteroidsPerAngle.Add(angle, new List<Point> { asteroid });
                }
                else
                {
                    asteroidsPerAngle[angle].Add(asteroid);
                }
            }

            foreach (var pair in asteroidsPerAngle)
            {
                double minDistance = double.MaxValue;
                foreach (Point asteroid in pair.Value)
                {
                    double distance = Geometry.GetLength(asteroid, source);
                    if(distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }

                if(minDistance < int.MaxValue)
                {
                    visibleAsteroids++;
                }
            }

            return visibleAsteroids;
        }
    }
}
