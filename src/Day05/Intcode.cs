using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day05.Part01
{
    public class Intcode
    {
        private int[] memory;

        public Stack<int> Diagnostics { get; set; } = new Stack<int>();

        public int Run(int systemId, string filePath)
        {
            var input = System.IO.File.ReadAllText(filePath);

            int[] initialMemoryState = input
                .Split(',')
                .Select(x => int.Parse(x))
                .ToArray();

            return Run(systemId, initialMemoryState);
        }

        public int Run(int systemId, int[] initialMemoryState)
        {
            memory = initialMemoryState;

            return Run(systemId);
        }

        public int Run(int systemId)
        {
            int i = 0;
            while(i < memory.Length)
            {
                var instruction = new Instruction(memory[i]);

                if(memory[i] == 99)
                {
                    // Success exit code.
                    return 0;
                }

                int? output = null;
                int? outputPosition = null;
                int numParams = 0;
                if(instruction.OpCode == 1)
                {
                    output = GetMemory(i + 1, instruction.ParameterA) + GetMemory(i + 2, instruction.ParameterB);
                    outputPosition = memory[i + 3];
                    numParams = 3;
                }
                else if(instruction.OpCode == 2)
                {
                    output = GetMemory(i + 1, instruction.ParameterA) * GetMemory(i + 2, instruction.ParameterB);
                    outputPosition = memory[i + 3];
                    numParams = 3;
                }
                else if(instruction.OpCode == 3)
                {
                    output = systemId;
                    outputPosition = memory[i + 1];
                    numParams = 1;
                }
                else if(instruction.OpCode == 4)
                {
                    Diagnostics.Push(GetMemory(i + 1, instruction.ParameterA));
                    numParams = 1;
                }
                else
                {
                    throw new Exception($"OpCode '{instruction.OpCode}' is undefined!");
                }

                if(output.HasValue && outputPosition.HasValue)
                {
                    SetMemory(output.Value, outputPosition.Value);
                }

                i += 1 + numParams;
            }

            return 0;
        }

        public int GetMemory(int index, ParameterMode mode)
            => mode switch
            {
                ParameterMode.Immediate => memory[index],
                ParameterMode.Position => memory[memory[index]],
                _ => throw new NotSupportedException()
            };

        public void SetMemory(int value, int index)
            => memory[index] = value;
    }
}
