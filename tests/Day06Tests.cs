using AdventOfCode2019.Day06;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day06Tests
    {
        [Fact]
        public void Part1()
        {
            string[] input = new string[] { "COM)BBB", "BBB)CCC","CCC)DDD","DDD)EEE","EEE)FFF","BBB)GGG","GGG)HHH","DDD)III","EEE)JJJ","JJJ)KKK","KKK)LLL" };
            var map = new OrbitMap(input);

            int count = map.CountAllOrbits();

            Assert.Equal(42, count);
        }

        [Fact]
        public void Part2()
        {
            string[] input = new string[] { "CCCOM)BBB","BBB)CCC","CCC)DDD","DDD)EEE","EEE)FFF","BBB)GGG","GGG)HHH","DDD)III","EEE)JJJ","JJJ)KKK","KKK)LLL","KKK)YOU","III)SAN" };
            var orbitTransfer = new OrbitalTransfer(new OrbitMap(input));

            int count = orbitTransfer.CalculateTransferDistance("YOU", "SAN");

            Assert.Equal(4, count);
        }

        [Fact]
        public void SolvePart1()
        {
            string[] input = System.IO.File.ReadAllLines("../../../input/day_06.txt");
            var map = new OrbitMap(input);

            int count = map.CountAllOrbits();

            Assert.Equal(387356, count);
        }

        [Fact]
        public void SolvePart2()
        {
            string[] input = System.IO.File.ReadAllLines("../../../input/day_06.txt");
            var orbitTransfer = new OrbitalTransfer(new OrbitMap(input));

            int count = orbitTransfer.CalculateTransferDistance("YOU", "SAN");

            Assert.Equal(532, count);
        }
    }
}
