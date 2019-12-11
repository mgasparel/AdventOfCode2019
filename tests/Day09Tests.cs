using System;
using System.Linq;
using AdventOfCode2019.Day09;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day09Tests
    {
        [Fact]
        public void Part1()
        {
            long[] initialMemoryState = new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 };
            var intcode = new Intcode();
            int exitCode = intcode.Run(1, initialMemoryState);

            Assert.Equal(0, exitCode);

            Assert.Equal(
                initialMemoryState,
                intcode.Diagnostics.ToArray().Reverse());
        }

        [Fact]
        public void Part1B()
        {
            double CountDigits(long n) => Math.Floor(Math.Log10((double)n) + 1);

            long[] initialMemoryState = new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 };
            var intcode = new Intcode();
            int exitCode = intcode.Run(1, initialMemoryState);

            Assert.Equal(0, exitCode);

            Assert.Equal(
                16,
                CountDigits(intcode.Diagnostics.Peek()));
        }

        [Fact]
        public void Part1C()
        {
            long[] initialMemoryState = new long[] { 104, 1125899906842624, 99 };
            var intcode = new Intcode();
            int exitCode = intcode.Run(1, initialMemoryState);

            Assert.Equal(0, exitCode);

            Assert.Equal(
                1125899906842624,
                intcode.Diagnostics.Peek());
        }

        [Fact]
        public void SolvePart1()
        {
            var intcode = new Intcode();
            int exitCode = intcode.Run(1, "../../../input/day_09.txt");

            Assert.Equal(0, exitCode);

            Assert.Equal(
                2594708277,
                intcode.Diagnostics.Peek());
        }

        [Fact]
        public void SolvePart2()
        {
            var intcode = new Intcode();
            int exitCode = intcode.Run(2, "../../../input/day_09.txt");

            Assert.Equal(0, exitCode);

            Assert.Equal(
                87721,
                intcode.Diagnostics.Peek());
        }
    }
}
