// using System;
// using System.Collections.Generic;
// using System.Linq;
// using AdventOfCode2019.Day05;

// namespace AdventOfCode2019.Day09
// {
//     public class Intcode2
//     {
//         bool? hasRunFirstInput = null;

//         private int[] memory;

//         // Instruction pointer.
//         int i = 0;

//         int relativeBase = 0;

//         public Stack<int> Diagnostics { get; set; } = new Stack<int>();

//         public Intcode(int[] initialMemoryState)
//         {
//             memory = initialMemoryState;
//         }

//         public Intcode(string filePath)
//         {
//             var input = System.IO.File.ReadAllText(filePath);

//             memory = input
//                 .Split(',')
//                 .Select(x => int.Parse(x))
//                 .ToArray();
//         }

//         public int Run(int phaseSetting, int inputSignal)
//         {
//             while(i < memory.Length)
//             {
//                 var instruction = new AdventOfCode2019.Day05.Part02.Instruction(GetMemorySafe(i));

//                 switch(instruction.OpCode)
//                 {
//                     case OpCode.Halt:
//                         // Success exit code.
//                         return 0;
//                     // 3-parameter OpCodes are hadled separately.
//                     // These cases were left in to maintain exhaustive check on the OpCode.
//                     case OpCode.Addition:
//                         break;
//                     case OpCode.Multiplication:
//                         break;
//                     case OpCode.LessThan:
//                         break;
//                     case OpCode.Equals:
//                         break;
//                     case OpCode.SetValue:
//                         if(hasRunFirstInput == true)
//                         {
//                             SetMemory(inputSignal, GetMemorySafe(i + 1));
//                         }
//                         else
//                         {
//                             SetMemory(phaseSetting, GetMemorySafe(i + 1));
//                         }

//                         i = GetNextPointer(i, numParams: 1);

//                         hasRunFirstInput ??= true;
//                         continue;
//                     case OpCode.OutputDiagnostic:
//                         Diagnostics.Push(GetMemory(i + 1, instruction.ParameterA));
//                         i = GetNextPointer(i, numParams: 1);

//                         return 1;
//                     case OpCode.JumpIfTrue:
//                         if(GetMemory(i + 1, instruction.ParameterA) > 0)
//                         {
//                             i = GetMemory(i + 2, instruction.ParameterB);

//                             continue;
//                         }

//                         i = GetNextPointer(i, numParams: 2);
//                         continue;
//                     case OpCode.JumpIfFalse:
//                         if(GetMemory(i + 1, instruction.ParameterA) == 0)
//                         {
//                             i = GetMemory(i + 2, instruction.ParameterB);

//                             continue;
//                         }

//                         i = GetNextPointer(i, numParams: 2);
//                         continue;
//                     case OpCode.RelativeBaseOffset:
//                         relativeBase += GetMemory(i + 1, instruction.ParameterA);
//                         continue;
//                     default:
//                         throw new Exception($"OpCode '{instruction.OpCode}' is undefined!");
//                 }

//                 // Handle 2-parameter instructions separately, as they share a common pattern.
//                 int p1 = GetMemory(i + 1, instruction.ParameterA);
//                 int p2 = GetMemory(i + 2, instruction.ParameterB);
//                 int outputPosition = GetMemorySafe(i + 3);

//                 int output = instruction.OpCode switch
//                 {
//                     OpCode.Addition => p1 + p2,
//                     OpCode.Multiplication => p1 * p2,
//                     OpCode.LessThan => (p1 < p2) ? 1 : 0,
//                     OpCode.Equals => (p1 == p2) ? 1 : 0,
//                     _ => throw new Exception($"OpCode '{instruction.OpCode}' is not supported for 3-param instructions!")
//                 };

//                 SetMemory(output, outputPosition);

//                 i = GetNextPointer(i, numParams: 3);
//             }

//             // If we did not halt on OpCode 99, something went wrong.
//             return -1;
//         }

//         int GetNextPointer(int currentPosition, int numParams)
//         {
//             // Add an additional 1 to account for the instruction.
//             return currentPosition + 1 + numParams;
//         }

//         int GetMemory(int index, ParameterMode mode)
//             => mode switch
//             {
//                 ParameterMode.Immediate => GetMemorySafe(index),
//                 ParameterMode.Position => GetMemorySafe(GetMemorySafe(index)),
//                 ParameterMode.Relative => GetMemorySafe(GetMemorySafe(index + relativeBase)),
//                 _ => throw new NotSupportedException()
//             };

//         int GetMemorySafe(int index)
//         {
//             EnsureMemorySize(index);
//             return memory[index];
//         }

//         void SetMemory(int value, int index)
//         {
//             EnsureMemorySize(index);
//             memory[index] = value;
//         }

//         void EnsureMemorySize(int index)
//         {
//             if(index > memory.Length)
//             {
//                 Array.Resize(ref memory, index + 1);
//             }
//         }
//     }
// }
