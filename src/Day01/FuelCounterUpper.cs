using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    public class FuelCounterUpper
    {
        public static int Count(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Select(x => FuelCalculator.Calculate(int.Parse(x)))
                .Sum();
        }
    }
}
