using AdventOfCode2019.Day05;

namespace AdventOfCode2019.Day05.Part02
{
    public class Instruction
    {
        public OpCode OpCode { get; set; }

        public ParameterMode ParameterA { get; set; }

        public ParameterMode ParameterB { get; set; }

        public ParameterMode ParameterC { get; set; }

        public Instruction(int instruction)
        {
            string s = $"{instruction:00000}";

            OpCode = (OpCode)int.Parse(s[3..5]);
            ParameterA = (ParameterMode)int.Parse(s[2].ToString());
            ParameterB = (ParameterMode)int.Parse(s[1].ToString());
            ParameterC = (ParameterMode)int.Parse(s[0].ToString());
        }
    }
}
