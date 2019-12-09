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

        public int FindMaxThrust(int[] input, int[] sequenceValues)
        {
            int maxThrust = 0;
            DateTime start = DateTime.Now;

            // YOLOMODE: try random sequences for 3 seconds and take the highest value.
            while(DateTime.Now - start < TimeSpan.FromSeconds(3))
            {
                var randomizedSequence = sequenceValues
                    .OrderBy(x => rnd.Next())
                    .ToArray();

                int result = ampController.GetThrusterSignal(randomizedSequence);

                if(result > maxThrust)
                {
                    maxThrust = result;
                }
            }

            return maxThrust;
        }

    }
}
