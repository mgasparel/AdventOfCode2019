using System;
using System.Linq;
using Xunit;
using AdventOfCode2019.Day11;

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
    }
}
