using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day12
{
    public class PlanetSimulator
    {
        Planet[] planets;

        public int TotalSystemEnergy => planets.Sum(x => x.TotalEnergy);

        public PlanetSimulator(Planet[] planets)
        {
            this.planets = planets;
        }

        public void Run(int numCycles)
        {
            var planetPairs = GetPlanetPairs();

            for (int i = 0; i < numCycles; i++)
            {
                foreach (var pair in planetPairs)
                {
                    ApplyGravity(pair.a, pair.b);
                }

                foreach (Planet planet in planets)
                {
                    ApplyVelocity(planet);
                }
            }
        }

        void ApplyGravity(Planet a, Planet b)
        {
            if(a.Position.x < b.Position.x)
            {
                a.Velocity.x++;
                b.Velocity.x--;
            }

            if(a.Position.x > b.Position.x)
            {
                a.Velocity.x--;
                b.Velocity.x++;
            }

            if(a.Position.y < b.Position.y)
            {
                a.Velocity.y++;
                b.Velocity.y--;
            }

            if(a.Position.y > b.Position.y)
            {
                a.Velocity.y--;
                b.Velocity.y++;
            }

            if(a.Position.z < b.Position.z)
            {
                a.Velocity.z++;
                b.Velocity.z--;
            }

            if(a.Position.z > b.Position.z)
            {
                a.Velocity.z--;
                b.Velocity.z++;
            }
        }

        void ApplyVelocity(Planet p)
        {
            p.Position.x += p.Velocity.x;
            p.Position.y += p.Velocity.y;
            p.Position.z += p.Velocity.z;
        }

        List<(Planet a, Planet b)> GetPlanetPairs()
        {
            var result = new List<(Planet a, Planet b)>();

            for (int i = 0; i < planets.Length; i++)
            for (int j = i + 1; j < planets.Length; j++)
            {
                result.Add((planets[i], planets[j]));
            }

            return result;
        }
    }
}
