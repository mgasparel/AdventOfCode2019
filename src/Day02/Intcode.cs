using System;
using System.Linq;

namespace AdventOfCode2019
{
    public class Intcode
    {
        static int input = 1;

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
            // memory[1] = noun;
            // memory[2] = verb;

            int i = 0;
            while(i < memory.Length)
            {
                var instruction = new Instruction(memory[i]);

                if(memory[i] == 99)
                {
                    break;
                }

                int? output = null;
                int? outputPosition = null;
                int numParams = 0;
                if(instruction.OpCode == 1)
                {
                    output = GetValue(instruction.ParameterA, i + 1, memory) + GetValue(instruction.ParameterB, i + 2, memory);
                    outputPosition = memory[i + 3];
                    numParams = 3;
                }
                else if(instruction.OpCode == 2)
                {
                    output = GetValue(instruction.ParameterA, i + 1, memory) * GetValue(instruction.ParameterB, i + 2, memory);
                    outputPosition = memory[i + 3];
                    numParams = 3;
                }
                else if(instruction.OpCode == 3)
                {
                    output = input;
                    outputPosition = memory[i + 1];
                    numParams = 1;
                }
                else if(instruction.OpCode == 4)
                {
                    Console.WriteLine($"OpCode 4 Outputs: {GetValue(instruction.ParameterA, i + 1, memory)}");
                    numParams = 1;
                }
                else
                {
                    throw new Exception("error!");
                }

                if(output.HasValue && outputPosition.HasValue)
                {
                    Console.WriteLine($"Set index: {outputPosition.Value} to value: {output}");
                    memory[outputPosition.Value] = output.Value;
                }

                i += 1 + numParams;
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
    }
}
