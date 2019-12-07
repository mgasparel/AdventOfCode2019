namespace AdventOfCode2019.Day05
{
    public enum OpCode
    {
        Addition = 1,
        Multiplication = 2,
        SetValue = 3,
        OutputDiagnostic = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Halt = 99
    }
}
