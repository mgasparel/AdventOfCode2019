using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Day08;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day08Tests
    {
        [Fact]
        public void Part1()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 };

            var parser = new ImageParser(input);
            List<int[]> layers = parser.ParseLayers(3, 2);

            Assert.Equal(2, layers.Count);
        }

        [Fact]
        public void SolvePart1()
        {
            static int CountOccurrences(int[] digits, int digitToCount)
                => digits.Count(x => x == digitToCount);

            int asciiOffset = 48;

            int[] input = System.IO.File.ReadAllText("../../../input/day_08.txt")
                .ToCharArray()
                .Select(x => (int)x - asciiOffset)
                .ToArray();

            var parser = new ImageParser(input);
            List<int[]> layers = parser.ParseLayers(25, 6);

            int lowestNum = int.MaxValue;
            int[] foundLayer = null;
            foreach (int[] layer in layers)
            {
                int numZeros = CountOccurrences(layer, 0);

                if(numZeros < lowestNum)
                {
                    lowestNum = numZeros;
                    foundLayer = layer;
                }
            }

            int ones = CountOccurrences(foundLayer, 1);
            int twos = CountOccurrences(foundLayer, 2);

            Assert.Equal(2125, ones * twos);
        }

        [Fact]
        public void Part2()
        {
            int[] input = new int[] { 0, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 2, 0, 0, 0, 0 };

            var parser = new ImageParser(input);
            List<int[]> layers = parser.ParseLayers(2, 2);

            var renderer = new ImageRenderer(layers, 2, 2);

            renderer.Render();

            renderer.PrintLines();

            var expected = new List<int[]>();
            expected.Add(new int[] { 0, 1 });
            expected.Add(new int[] { 1, 0 });

            Assert.Equal(expected, renderer.Lines);
        }

        [Fact]
        public void SolvePart2()
        {
            int asciiOffset = 48;

            int[] input = System.IO.File.ReadAllText("../../../input/day_08.txt")
                .ToCharArray()
                .Select(x => (int)x - asciiOffset)
                .ToArray();

            var parser = new ImageParser(input);
            List<int[]> layers = parser.ParseLayers(25, 6);

            var renderer = new ImageRenderer(layers, 25, 6);

            renderer.Render();

            renderer.PrintLines();

            var expected = new List<int[]>();
            expected.Add(new int[] { 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 0 });
            expected.Add(new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 });
            expected.Add(new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0 });
            expected.Add(new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 });
            expected.Add(new int[] { 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 });
            expected.Add(new int[] { 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0 });

            Assert.Equal(expected, renderer.Lines);
        }
    }
}
