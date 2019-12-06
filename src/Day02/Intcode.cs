using System;
using System.Linq;

namespace AdventOfCode2019
{
    public class Intcode
    {
        public static int[] Run(int noun, int verb, string filePath)
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
                var instruction = new Instruction(memory[i]);

                int? result = RunOpCode(memory, i, ParameterMode.Position);

                if(result == null)
                {
                    break;
                }

                memory[memory[i + 3]] = result.Value;
            }

            return memory;
        }

        public static int GetValue(ParameterMode mode, int index, int[] memory)
            => mode switch
            {
                ParameterMode.Immediate => memory[index],
                ParameterMode.Position => memory[memory[index]],
                _ => throw new NotSupportedException()
            };

        private static int? RunOpCode(int[] memory, int index, ParameterMode mode) =>
            memory[index] switch
            {
                99  => (int?)null,
                1   => GetValue(mode, index + 1, memory) + GetValue(mode, index + 2, memory),
                2   => GetValue(mode, index + 1, memory) * GetValue(mode, index + 2, memory),
                _   => throw new ArgumentException()
            };
    }
}
