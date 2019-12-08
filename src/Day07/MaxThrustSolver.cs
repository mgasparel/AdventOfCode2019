using System;
using System.Linq;

namespace AdventOfCode2019.Day07
{
    public class MaxThrustSolver
    {
        AmplifierController ampController;
        Random rnd = new Random();

        public MaxThrustSolver(AmplifierController ampController)
        {
            this.ampController = ampController;
        }

        public int FindMaxThrust(int[] input)
        {
            int[] sequenceValues = new int[] { 0, 1, 2, 3, 4 };

            int maxThrust = 0;
            DateTime start = DateTime.Now;

            // YOLOMODE: try random sequences for 5 seconds and take the highest value.
            while(DateTime.Now - start < TimeSpan.FromSeconds(5))
            {
                var randomizedSequence = sequenceValues
                    .OrderBy(x => rnd.Next())
                    .ToArray();

                int result = ampController.GetThrusterSignal(input, randomizedSequence);

                if(result > maxThrust)
                {
                    Console.WriteLine($"MaxThrust is now {result}");
                    maxThrust = result;
                }
            }

            return maxThrust;
        }

    }
}
