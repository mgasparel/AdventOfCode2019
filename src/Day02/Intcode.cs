using System;
using System.Linq;

namespace AdventOfCode2019
{
    public class Intcode
    {
        private static string filePath = "day_02.txt";

        public static int[] Run(int noun, int verb)
        {
            var input = System.IO.File.ReadAllText(filePath);

            int[] memory = input
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            return Run(noun, verb, memory);
        }

        public static int[] Run(int noun, int verb, int[] memory)
        {
            memory[1] = noun;
            memory[2] = verb;

            for(int i = 0; i < memory.Length; i += 4)
            {
                int? result = RunOpCode(memory, i);

                if(result == null)
                {
                    break;
                }

                memory[memory[i + 3]] = result.Value;
            }

            return memory;
        }

        private static int? RunOpCode(int[] memory, int index) =>
            memory[index] switch
            {
                99  => (int?)null,
                1   => memory[memory[index + 1]] + memory[memory[index + 2]],
                2   => memory[memory[index + 1]] * memory[memory[index + 2]],
                _   => throw new ArgumentException()
            };
    }
}
