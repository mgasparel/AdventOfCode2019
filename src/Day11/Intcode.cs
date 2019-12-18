using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Day11
{
    public class Intcode
    {
        private long[] memory;

        public Stack<long> Diagnostics { get; set; } = new Stack<long>();

        long relativeBase = 0;

        long i = 0;

        public Intcode(long[] initialMemoryState)
        {
            memory = initialMemoryState;
        }

        public long Run(int input)
        {
            while(i < memory.Length)
            {
                var instruction = new Instruction(GetMemorySafe(i));

                switch(instruction.OpCode)
                {
                    case OpCode.Halt:
                        // Success exit code.
                        throw new Exception("Halted!");
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
                        SetMemory(input, GetMemorySafe(i + 1), instruction.ParameterA);

                        i = GetNextPointer(i, numParams: 1);

                        continue;
                    case OpCode.OutputDiagnostic:
                        var diagnostic = GetMemory(i + 1, instruction.ParameterA);
                        Diagnostics.Push(diagnostic);
                        i = GetNextPointer(i, numParams: 1);

                        return diagnostic;
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
                    case OpCode.RelativeBaseOffset:
                        relativeBase += GetMemory(i + 1, instruction.ParameterA);
                        i = GetNextPointer(i, numParams: 1);
                        continue;
                    default:
                        throw new Exception($"OpCode '{instruction.OpCode}' is undefined!");
                }

                // Handle 2-parameter instructions separately, as they share a common pattern.
                long p1 = GetMemory(i + 1, instruction.ParameterA);
                long p2 = GetMemory(i + 2, instruction.ParameterB);
                long outputPosition = GetMemorySafe(i + 3);

                long output = instruction.OpCode switch
                {
                    OpCode.Addition => p1 + p2,
                    OpCode.Multiplication => p1 * p2,
                    OpCode.LessThan => (p1 < p2) ? 1 : 0,
                    OpCode.Equals => (p1 == p2) ? 1 : 0,
                    _ => throw new Exception($"OpCode '{instruction.OpCode}' is not supported for 3-param instructions!")
                };

                SetMemory(output, outputPosition, instruction.ParameterC);

                i = GetNextPointer(i, numParams: 3);
            }

            // If we did not halt on OpCode 99, something went wrong.
            return 1;
        }

        long GetNextPointer(long currentPosition, int numParams)
        {
            // Add an additional 1 to account for the instruction.
            return currentPosition + 1 + numParams;
        }

        long GetMemory(long index, ParameterMode mode)
            => mode switch
            {
                ParameterMode.Immediate => GetMemorySafe(index),
                ParameterMode.Position => GetMemorySafe(GetMemorySafe(index)),
                ParameterMode.Relative => GetMemorySafe(GetMemorySafe(index) + relativeBase),
                _ => throw new NotSupportedException()
            };

        long GetMemorySafe(long index)
        {
            if(index > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            EnsureMemorySize((int)index);
            return memory[index];
        }

        void SetMemory(long value, long index, ParameterMode mode)
        {
            if(index > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException();
            }

            long i = 0;
            if(mode == ParameterMode.Position)
            {
                i = index;
            }

            if(mode == ParameterMode.Relative)
            {
                i = index + relativeBase;
            }

            EnsureMemorySize((int)i);
            memory[i] = value;
        }

        void EnsureMemorySize(int index)
        {
            if(index >= memory.Length)
            {
                Array.Resize(ref memory, index + 1);
            }
        }
    }
}
