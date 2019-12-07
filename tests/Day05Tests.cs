using AdventOfCode2019.Day01;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day05Tests
    {
        public static TheoryData<int[], int[]> Day05Data
        {
            get
            {
                var data = new TheoryData<int[], int[]>();
                data.Add(
                    new int[] {1002,4,3,4,33}, new int[] {1002,4,3,4,99}
                );
                return data;
            }
        }

        [Theory]
        [MemberData(nameof(Day05Data))]
        public void Part1(int[] input, int[] expected)
        {
            Assert.Equal(expected, Intcode.Run(input[1], input[2], input));
        }

        [Fact]
        public void SolvePart1()
        {
            var memory = Intcode.Run(12, 2, "../../../input/day_05.txt");

            Assert.Equal(10987514, memory[0]);
        }

        // [Fact]
        // public void SolvePart2()
        // {
        //     (int noun, int verb) result = IntcodeInputSolver.Solve(19690720, "../../../input/day_02.txt");

        //     Assert.Equal(5741, 100 * result.noun + result.verb);
        // }
    }
}
