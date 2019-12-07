using AdventOfCode2019.Day05.Part01;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day05Tests
    {
        public static int airConSystemId = 1;


        [Fact]
        public void Part1()
        {
            var intcode = new Intcode();
            int exitCode = intcode.Run(airConSystemId, new int[] {1002,4,3,4,33});

            Assert.Equal(0, exitCode);

            Assert.All(
                intcode.Diagnostics,
                x => Assert.Equal(0, x));
        }

        [Fact]
        public void SolvePart1()
        {
            var intcode = new Intcode();
            int exitCode = intcode.Run(airConSystemId, "../../../input/day_05.txt");

            Assert.Equal(0, exitCode);

            Assert.Equal(10987514, intcode.Diagnostics.Peek());
        }
    }
}
