using System.Linq;
using AdventOfCode2019.Day12;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part1()
        {
            string[] input =
            {
                "<x=-1, y=0, z=2>",
                "<x=2, y=-10, z=-7>",
                "<x=4, y=-8, z=8>",
                "<x=3, y=5, z=-1>",
            };

            Planet[] planets = input
                .Select(x => x.Substring(1, x.Length - 2))
                .Select(x => PlanetParser.ParsePlanet(x))
                .ToArray();

            var sim = new PlanetSimulator(planets);
            sim.Run(10);

            Assert.Equal(179, sim.TotalSystemEnergy);
        }

        [Fact]
        public void SolvePart1()
        {
            string[] input = System.IO.File.ReadAllLines("../../../input/day_12.txt");

            Planet[] planets = input
                .Select(x => x.Substring(1, x.Length - 2))
                .Select(x => PlanetParser.ParsePlanet(x))
                .ToArray();

            var sim = new PlanetSimulator(planets);
            sim.Run(1000);

            Assert.Equal(5350, sim.TotalSystemEnergy);
        }
    }
}
