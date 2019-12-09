using System.Linq;

namespace AdventOfCode2019.Day07
{
    public class AmplifierController
    {
        public bool[] ampHalted = new bool[5];

        Intcode[] amplifiers;

        int[] input;

        public AmplifierController(int[] input)
        {
            this.input = input;
        }

        public int GetThrusterSignal(int[] phaseSettingSequence)
        {
            InitializeAmplifiers();

            int output = 0;
            for (int i = 0; i < amplifiers.Length; i++)
            {
                var amp = amplifiers[i];
                ampHalted[i] = amp.Run(phaseSettingSequence[i], output) == 0;
                output = amp.Diagnostics.Peek();

                if(ampHalted.All(x => x == true))
                {
                    return output;
                }

                if(i == amplifiers.Length - 1)
                {
                    i = -1;
                }
            }

            return output;
        }

        void InitializeAmplifiers()
        {
            amplifiers = new Intcode[]
            {
                new Intcode((int[])input.Clone()),
                new Intcode((int[])input.Clone()),
                new Intcode((int[])input.Clone()),
                new Intcode((int[])input.Clone()),
                new Intcode((int[])input.Clone())
            };
        }
    }
}
