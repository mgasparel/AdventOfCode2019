using System;

namespace AdventOfCode2019
{
    public class IntcodeInputSolver
    {
        public static (int noun, int verb) Solve(int desiredOutput, string filePath)
        {
            for (int noun = 0; noun < 100; noun++)
            for (int verb = 0; verb < 100; verb++)
            {
                if(Intcode.Run(noun, verb, filePath)[0] == desiredOutput)
                {
                    return (noun, verb);
                }
            }

            throw new InvalidOperationException("No solution found");
        }
    }
}
