using System;
using System.Linq;
using Xunit;
using AdventOfCode2019.Day11;
using System.Collections.Generic;

namespace AdventOfCode2019.Tests
{
    public class Day11Tests
    {
        [Fact]
        public void SolvePart1()
        {
            var input = System.IO.File.ReadAllText("../../../input/day_11.txt");

            long[] initialMemoryState = input
                .Split(',')
                .Select(x => long.Parse(x))
                .ToArray();

            var intcode = new Intcode(initialMemoryState);
            var hullPaintingRobot = new HullPaintingRobot(intcode);

            hullPaintingRobot.Paint();

            var panels = hullPaintingRobot.Panels;

            int panelsPainted = panels
                .Select(x => x.Location)
                .Distinct()
                .Count();

            Assert.Equal(2336, panelsPainted);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = System.IO.File.ReadAllText("../../../input/day_11.txt");

            long[] initialMemoryState = input
                .Split(',')
                .Select(x => long.Parse(x))
                .ToArray();

            var intcode = new Intcode(initialMemoryState);
            var hullPaintingRobot = new HullPaintingRobot(intcode);

            hullPaintingRobot.Paint();

            var panels = hullPaintingRobot.Panels;

            var allVisitedPoints = panels
                .Select(x => x.Location)
                .Distinct();

            List<Point> whitePoints = new List<Point>();
            foreach (var p in allVisitedPoints)
            {
                var latestColor = panels
                    .Where(x => x.Location.Equals(p))
                    .First()
                    .Color;

                if(latestColor == 1)
                {
                    whitePoints.Add(p);
                }
            }

            var minX = whitePoints.Min(p => p.x);
            var maxX = whitePoints.Max(p => p.x);
            var minY = whitePoints.Min(p => p.y);
            var maxY = whitePoints.Max(p => p.y);

            var output = new List<string>();

            for (int y = minY; y <= maxY; y++)
            {
                string line = "";
                for (int x = minX; x <= maxX; x++)
                {
                    if(whitePoints.Contains(new Point(x, y)))
                    {
                        line += "#";
                        Console.Write("#");
                    }
                    else
                    {
                        line += " ";
                        Console.Write(" ");
                    }
                }

                output.Add(line);
                Console.Write("\n");
            }

            var expected = new string[]
            {
                "##  # ####  ##  #### #  # ###  #    ### ",
                " #  #    # #  # #    # #  #  # #    #  #",
                " #  #   #  #  # ###  ##   ###  #    #  #",
                " #  #  #   #### #    # #  #  # #    ### ",
                " #  # #    #  # #    # #  #  # #    #   ",
                "  ##  #### #  # #### #  # ###  #### #   "
            };

            Assert.Equal(expected, output.ToArray());
        }
    }
}
