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
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2};

            var decoder = new ImageDecoder(input);
            decoder.DecodeImage(3, 2);

            Assert.Equal(2, decoder.Layers.Count);
        }

        [Fact]
        public void SolvePart1()
        {
            int asciiOffset = 48;

            int[] input = System.IO.File.ReadAllText("../../../input/day_08.txt")
                .ToCharArray()
                .Select(x => (int)x - asciiOffset)
                .ToArray();

            var decoder = new ImageDecoder(input);
            decoder.DecodeImage(25, 6);

            int lowestNum = int.MaxValue;
            int[] foundLayer = null;
            foreach (int[] layer in decoder.Layers)
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

        public int CountOccurrences(int[] digits, int digitToCount)
            => digits.Count(x => x == digitToCount);
    }
}
