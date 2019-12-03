using AdventOfCode2019.Day01;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day02Tests
    {
        public static TheoryData<int[], int[]> Day01Data
        {
            get
            {
                var data = new TheoryData<int[], int[]>();
                data.Add(
                    new int[] {1,0,0,0,99}, new int[] {2,0,0,0,99}
                );

                data.Add(
                    new int[] {2,3,0,3,99}, new int[] {2,3,0,6,99}
                );

                data.Add(
                    new int[] {2,4,4,5,99,0}, new int[] {2,4,4,5,99,9801}
                );

                data.Add(
                    new int[] {1,1,1,4,99,5,6,0,99}, new int[] {30,1,1,4,2,5,6,0,99}
                );

                return data;
            }
        }

        [Theory]
        [MemberData(nameof(Day01Data))]
        public void Part1(int[] input, int[] expected)
        {
            Assert.Equal(expected, Intcode.Run(input[1], input[2], input));
        }

        [Fact]
        public void SolvePart1()
        {
            var memory = Intcode.Run(12, 2, "../../../input/day_02.txt");

            Assert.Equal(5290681, memory[0]);
        }

        [Fact]
        public void SolvePart2()
        {
            (int noun, int verb) result = IntcodeInputSolver.Solve(19690720, "../../../input/day_02.txt");

            Assert.Equal(5741, 100 * result.noun + result.verb);
        }
    }
}
