using System;
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

        [Fact]
        public void Part2()
        {
            string[] input =
            {
                "<x=-8, y=-10, z=0>",
                "<x=5, y=5, z=10>",
                "<x=2, y=-7, z=3>",
                "<x=9, y=-8, z=-3>"
            };

            Planet[] planets = input
                .Select(x => x.Substring(1, x.Length - 2))
                .Select(x => PlanetParser.ParsePlanet(x))
                .ToArray();

            // var a = planets[0].GetHashCode();
            // planets[0].Position.x += 5;
            // var d = planets[0].GetHashCode();

            // var a = new Point3D(1, 2, 3);
            // var b = a.GetHashCode();
            // a.x += 5;
            // var d = a.GetHashCode();

            var sim = new PlanetSimulator(planets);
            long c = sim.Run(long.MaxValue);

            Assert.Equal(74099, c);
        }
    }
}
