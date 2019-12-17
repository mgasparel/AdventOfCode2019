using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day10
{
    public class AsteroidMap
    {
        public static char Asteroid = '#';

        string[] map;

        public Point[] AsteroidCoordinates;

        public Dictionary<double, List<Point>> AsteroidsPerAngle;

        public AsteroidMap(string[] map)
        {
            this.map = map;
            this.AsteroidCoordinates = GetAllAsteroids();
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

        public void LoadAsteroidsPerAngle(Point source)
        {
            AsteroidsPerAngle = new Dictionary<double, List<Point>>();

            foreach (Point asteroid in AsteroidCoordinates)
            {
                if(asteroid.Equals(source))
                {
                    continue;
                }

                double angle = Geometry.GetAngle(source, asteroid);

                if(!AsteroidsPerAngle.ContainsKey(angle))
                {
                    AsteroidsPerAngle.Add(angle, new List<Point> { asteroid });
                }
                else
                {
                    AsteroidsPerAngle[angle].Add(asteroid);
                }
            }

            for (int i = 0; i < AsteroidsPerAngle.Keys.Count; i++)
            {
                double angle = AsteroidsPerAngle.Keys.ElementAt(i);

                AsteroidsPerAngle[angle] = AsteroidsPerAngle[angle]
                    .OrderBy(x => Geometry.GetLength(x, source))
                    .ToList();
            }
        }

        public int CountVisibleAsteroids(Point source)
        {
            LoadAsteroidsPerAngle(source);

            return AsteroidsPerAngle.Keys.Count;
        }
    }
}
