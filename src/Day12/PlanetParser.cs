using System.Text.RegularExpressions;

namespace AdventOfCode2019.Day12
{
    public static class PlanetParser
    {
        static readonly Regex r = new Regex(@"[x,y,z]=(\-?\d*)");

        public static Planet ParsePlanet(string input)
        {
            var results = r.Matches(input);

            string x = results[0].Groups[1].Value;
            string y = results[1].Groups[1].Value;
            string z = results[2].Groups[1].Value;

            return new Planet
            {
                Position = new Point3D(int.Parse(x), int.Parse(y), int.Parse(z))
            };
        }
    }
}
