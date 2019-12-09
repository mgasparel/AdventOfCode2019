using System.Linq;
using AdventOfCode2019.Day07;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day07Tests
    {
        [Fact]
        public void Part1()
        {
            int[] input = new int[] { 3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0 };
            int[] sequence = new int[] { 4, 3, 2, 1, 0 };

            var ampController = new AmplifierController(input);

            int signal = ampController.GetThrusterSignal(sequence);

            Assert.Equal(43210, signal);
        }

        [Fact]
        public void SolvePart1()
        {
            int[] sequence = new int[] { 4, 3, 2, 1, 0 };
            int[] input = System.IO.File.ReadAllText("../../../input/day_07.txt")
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            var ampController = new AmplifierController(input);
            var solver = new MaxThrustSolver(ampController);

            int maxThrust = solver.FindMaxThrust(input, sequence);

            Assert.Equal(79723, maxThrust);
        }

        [Fact]
        public void Part2()
        {
            int[] sequence = new int[] { 9, 8, 7, 6, 5 };
            int[] input = { 3, 26, 1001, 26, -4, 26, 3, 27, 1002, 27, 2, 27, 1, 27, 26, 27, 4, 27, 1001, 28, -1, 28, 1005, 28, 6, 99, 0, 0, 5 };

            var ampController = new AmplifierController(input);
            var solver = new MaxThrustSolver(ampController);

            int signal = ampController.GetThrusterSignal(sequence);

            Assert.Equal(139629729, signal);
        }

        [Fact]
        public void SolvePart2()
        {
            int[] sequence = new int[] { 9, 8, 7, 6, 5 };
            int[] input = System.IO.File.ReadAllText("../../../input/day_07.txt")
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            var ampController = new AmplifierController(input);
            var solver = new MaxThrustSolver(ampController);

            int maxThrust = solver.FindMaxThrust(input, sequence);

            Assert.Equal(70602018, maxThrust);
        }
    }
}
