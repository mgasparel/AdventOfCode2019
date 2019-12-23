using System;

namespace AdventOfCode2019.Day12
{
    public class Planet
    {
        public Point3D Position = new Point3D();

        public Point3D Velocity = new Point3D();

        public int PotentialEnergy
            => Math.Abs(Position.x) + Math.Abs(Position.y) + Math.Abs(Position.z);

        public int KineticEnergy
            => Math.Abs(Velocity.x) + Math.Abs(Velocity.y) + Math.Abs(Velocity.z);

        public int TotalEnergy => PotentialEnergy * KineticEnergy;

        public override bool Equals(Object obj)
        {
            if (!(obj is Planet)) return false;

            Planet p = (Planet) obj;
            return Position.Equals(p.Position) & Velocity.Equals(p.Velocity);
        }

        public override int GetHashCode()
        {
            //return HashCode.Combine(Position, Velocity);
            int hash = 17;
            hash = hash * 31 + Position.GetHashCode();
            hash = hash * 31 + Velocity.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{Position.ToString()}-{Velocity.ToString()}";
        }
    }
}
