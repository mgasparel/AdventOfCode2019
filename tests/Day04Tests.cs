using System.Linq;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day04Tests
    {
        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void Part1(string input, bool expected)
        {
            Assert.Equal(expected, PasswordCracker.MeetsRequirements(input));
        }

        [Fact]
        public void SolvePart1()
        {
            var range = System.IO.File.ReadAllText("../../../input/day_04.txt")
                .Split('-')
                .Select(x => int.Parse(x))
                .ToArray();

            int numPasswords = PasswordCracker.FindAllPasswordsInRange(range[0], range[1]).Count();

            Assert.Equal(1, numPasswords);
        }
    }
}
