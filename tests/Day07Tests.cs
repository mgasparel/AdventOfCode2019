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

            var ampController = new AmplifierController();

            int signal = ampController.GetThrusterSignal(input, sequence);

            Assert.Equal(43210, signal);
        }

        [Fact]
        public void SolvePart1()
        {
            int[] sequence = new int[] { 4, 3, 2, 1, 0 };

            var ampController = new AmplifierController();
            var solver = new MaxThrustSolver(ampController);

            int[] input = System.IO.File.ReadAllText("../../../input/day_07.txt")
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            int maxThrust = solver.FindMaxThrust(input);

            Assert.Equal(79723, maxThrust);
        }
    }
}
