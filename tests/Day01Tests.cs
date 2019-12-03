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

        [Fact]
        public void SolvePart1()
        {
            Assert.Equal(
                3305041,
                FuelCounterUpper.Count("../../../input/day_01.txt", FuelCalculator.Calculate));
        }

        [Fact]
        public void SolvePart2()
        {
            Assert.Equal(
                4954710,
                FuelCounterUpper.Count("../../../input/day_01.txt", FuelCalculator.CalculateRecursive));
        }
    }
}
