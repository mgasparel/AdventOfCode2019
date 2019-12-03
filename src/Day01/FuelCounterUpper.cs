using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    public class FuelCounterUpper
    {
        public static int Count(string filePath, Func<int, int> calculateFuel)
        {
            return File.ReadAllLines(filePath)
                .Select(x => calculateFuel(int.Parse(x)))
                .Sum();
        }
    }
}
