namespace AdventOfCode2019.Day01
{
    public class FuelCalculator
    {
        public static int Calculate(int mass)
        {
            return (int)(mass / 3f) - 2;
        }

        public static int CalculateRecursive(int mass)
        {
            int fuel = Calculate(mass);

            if (fuel <= 0)
            {
                return 0;
            }

            return fuel += CalculateRecursive(fuel);
        }
    }
}
