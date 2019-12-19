using System;

namespace AdventOfCode2019.Day12
{
    public class Planet
    {
        public Point3D Position;

        public Point3D Velocity;

        public int PotentialEnergy
            => Math.Abs(Position.x) + Math.Abs(Position.y) + Math.Abs(Position.z);

        public int KineticEnergy
            => Math.Abs(Velocity.x) + Math.Abs(Velocity.y) + Math.Abs(Velocity.z);

        public int TotalEnergy => PotentialEnergy * KineticEnergy;
    }
}
