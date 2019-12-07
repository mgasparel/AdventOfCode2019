using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day05.Part02
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

                switch(instruction.OpCode)
                {
                    case OpCode.Halt:
                        // Success exit code.
                        return 0;
                    // 3-parameter OpCodes are hadled separately.
                    // These cases were left in to maintain exhaustive check on the OpCode.
                    case OpCode.Addition:
                        break;
                    case OpCode.Multiplication:
                        break;
                    case OpCode.LessThan:
                        break;
                    case OpCode.Equals:
                        break;
                    case OpCode.SetValue:
                        SetMemory(systemId, memory[i + 1]);

                        i = GetNextPointer(i, numParams: 1);

                        continue;
                    case OpCode.OutputDiagnostic:
                        Diagnostics.Push(GetMemory(i + 1, instruction.ParameterA));
                        i = GetNextPointer(i, numParams: 1);

                        continue;
                    case OpCode.JumpIfTrue:
                        if(GetMemory(i + 1, instruction.ParameterA) > 0)
                        {
                            i = GetMemory(i + 2, instruction.ParameterB);

                            continue;
                        }

                        i = GetNextPointer(i, numParams: 2);
                        continue;
                    case OpCode.JumpIfFalse:
                        if(GetMemory(i + 1, instruction.ParameterA) == 0)
                        {
                            i = GetMemory(i + 2, instruction.ParameterB);

                            continue;
                        }

                        i = GetNextPointer(i, numParams: 2);
                        continue;
                    default:
                        throw new Exception($"OpCode '{instruction.OpCode}' is undefined!");
                }

                // Handle 2-parameter instructions separately, as they share a common pattern.
                int p1 = GetMemory(i + 1, instruction.ParameterA);
                int p2 = GetMemory(i + 2, instruction.ParameterB);
                int outputPosition = memory[i + 3];

                int output = instruction.OpCode switch
                {
                    OpCode.Addition => p1 + p2,
                    OpCode.Multiplication => p1 * p2,
                    OpCode.LessThan => (p1 < p2) ? 1 : 0,
                    OpCode.Equals => (p1 == p2) ? 1 : 0,
                    _ => throw new Exception($"OpCode '{instruction.OpCode}' is not supported for 3-param instructions!")
                };

                SetMemory(output, outputPosition);

                i = GetNextPointer(i, numParams: 3);
            }

            // If we did not halt on OpCode 99, something went wrong.
            return 1;
        }

        int GetNextPointer(int currentPosition, int numParams)
        {
            // Add an additional 1 to account for the instruction.
            return currentPosition + 1 + numParams;
        }

        int GetMemory(int index, ParameterMode mode)
            => mode switch
            {
                ParameterMode.Immediate => memory[index],
                ParameterMode.Position => memory[memory[index]],
                _ => throw new NotSupportedException()
            };

        void SetMemory(int value, int index)
            => memory[index] = value;
    }
}
