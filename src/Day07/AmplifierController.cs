namespace AdventOfCode2019.Day07
{
    public class AmplifierController
    {
        public int GetThrusterSignal(int[] input, int[] phaseSettingSequence)
        {
            int numAmplifiers = 5;
            int output = 0;
            for (int i = 0; i < numAmplifiers; i++)
            {
                var computer = new Intcode();
                int exitCode = computer.Run(phaseSettingSequence[i], output, input);

                output = computer.Diagnostics.Peek();
            }

            return output;
        }
    }
}
