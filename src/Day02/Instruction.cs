namespace AdventOfCode2019
{
    public class Instruction
    {
        public int OpCode { get; set; }

        public ParameterMode ParameterA { get; set; }

        public ParameterMode ParameterB { get; set; }

        public ParameterMode ParameterC { get; set; }

        public Instruction(int instruction)
        {
            string s = $"{instruction:00000}";

            OpCode = int.Parse(s[3..4]);
            ParameterA = (ParameterMode)s[2];
            ParameterB = (ParameterMode)s[1];
            ParameterC = (ParameterMode)s[0];
        }
    }
}
