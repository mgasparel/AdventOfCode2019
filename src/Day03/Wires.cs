using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Wires
    {
        public static readonly Coordinate origin = new Coordinate(0, 0);

        Coordinate[] wire1Path;

        Coordinate[] wire2Path;

        public Coordinate[] Intersections => wire1Path.ToList().Intersect(wire2Path).ToArray();

        public Wires(string wire1Directions, string wire2Directions)
        {
            wire1Path = PopulatePath(new Coordinate(), wire1Directions.Split(','));
            wire2Path = PopulatePath(new Coordinate(), wire2Directions.Split(','));
        }

        public static Coordinate[] PopulatePath(Coordinate origin, string[] directions)
        {
            var result = new List<Coordinate>();
            var currentPoint = origin;

            foreach(var direction in directions)
            {
                int distance = int.Parse(direction.Substring(1));

                for (int i = 0; i < distance; i++)
                {
                    var newPoint = Move(currentPoint, direction, 1);
                    result.Add(newPoint);

                    currentPoint = newPoint;
                }
            }

            return result.ToArray();
        }

        public int ClosestToOrigin(Coordinate[] coordinates)
        {
            int minValue = int.MaxValue;

            foreach(var point in coordinates)
            {
                var d = DistanceToOrigin(point);
                if(d < minValue)
                {
                    minValue = d;
                }
            }

            return minValue;
        }

        int DistanceToOrigin(Coordinate coordindate)
        {
            return Math.Abs(coordindate.x) + Math.Abs(coordindate.y);
        }

        static Coordinate Move(Coordinate startPosition, string direction, int distance)
        {
            return direction[0] switch
            {
                'R' => new Coordinate(startPosition.x + distance, startPosition.y),
                'L' => new Coordinate(startPosition.x - distance, startPosition.y),
                'U' => new Coordinate(startPosition.x, startPosition.y + distance),
                'D' => new Coordinate(startPosition.x, startPosition.y - distance),
                _ => throw new ArgumentException("Invalid Direction")
            };
        }
    }
}
