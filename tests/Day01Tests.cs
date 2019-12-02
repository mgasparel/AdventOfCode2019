using AdventOfCode2019.Day01;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day01Tests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Part1(int input, int expected)
        {
            Assert.Equal(expected, FuelCalculator.Calculate(input));
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Part2(int input, int expected)
        {
            Assert.Equal(expected, FuelCalculator.CalculateRecursive(input));
        }
    }
}
