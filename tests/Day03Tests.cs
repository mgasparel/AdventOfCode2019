using AdventOfCode2019.Day01;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day03Tests
    {
        [Theory]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Part1(string line1, string line2, int expectedResult)
        {
            var w = new Wires(line1, line2);

            Assert.Equal(expectedResult, w.ClosestToOrigin(w.Intersections));
        }

        [Theory]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void Part2(string line1, string line2, int expectedResult)
        {
            var w = new Wires(line1, line2);

            Assert.Equal(expectedResult, w.FindMinimumSignalDelay());
        }

        [Fact]
        public void SolvePart1()
        {
            var lines = System.IO.File.ReadAllLines("../../../input/day_03.txt");
            var w = new Wires(lines[0], lines[1]);

            Assert.Equal(221, w.ClosestToOrigin(w.Intersections));
        }

        [Fact]
        public void SolvePart2()
        {
            var lines = System.IO.File.ReadAllLines("../../../input/day_03.txt");
            var w = new Wires(lines[0], lines[1]);

            Assert.Equal(18542, w.FindMinimumSignalDelay());
        }
    }
}
