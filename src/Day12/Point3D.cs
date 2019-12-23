using System;

namespace AdventOfCode2019.Day12
{
    public class Point3D
    {
        public int x { get; set; }

        public int y { get; set; }

        public int z { get; set; }

        public Point3D()
        {
        }

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Point3D)) return false;

            Point3D p = (Point3D) obj;
            return x == p.x & y == p.y & z == p.z;
        }

        public override int GetHashCode()
        {
            return $"{x},{y},{z}".GetHashCode();
        }

        public override string ToString()
        {
            return $"{x},{y},{z}";
        }
    }
}
