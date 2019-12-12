using AdventOfCode2019.Day10;
using Xunit;

namespace AdventOfCode2019.Tests
{
    public class Day10Tests
    {
        [Fact]
        public void Part1()
        {
            string[] input = new string[]
            {
                ".#..#",
                ".....",
                "#####",
                "....#",
                "...##"
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(3, 4));

            Assert.Equal(8, visible);
        }

        [Fact]
        public void Part2()
        {
            string[] input = new string[]
            {
                "......#.#.",
                "#..#.#....",
                "..#######.",
                ".#.#.###..",
                ".#..#.....",
                "..#....#.#",
                "#..#....#.",
                ".##.#..###",
                "##...#..#.",
                ".#....####"
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(5, 8));

            Assert.Equal(33, visible);
        }

        [Fact]
        public void Part6()
        {
            string[] input = new string[]
            {
                "#.#...#.#.",
                ".###....#.",
                ".#....#...",
                "##.#.#.#.#",
                "....#.#.#.",
                ".##..###.#",
                "..#...##..",
                "..##....##",
                "......#...",
                ".####.###."
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(1, 2));

            Assert.Equal(35, visible);
        }

        [Fact]
        public void Part3()
        {
            string[] input = new string[]
            {
                "#.#",
                ".#.",
                "#.#",
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(1, 1));

            Assert.Equal(4, visible);
        }

        [Fact]
        public void Part4()
        {
            string[] input = new string[]
            {
                "#.#.",
                "...#",
                "..##",
                ".#.#",
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(3, 1));

            Assert.Equal(4, visible);
        }

        [Fact]
        public void GetAngleLessThan180Degrees()
        {
            var a = new Point(2, 2);
            var b = new Point(0, 1);
            var g = Geometry.GetAngle(a, b);

            Assert.Equal(63.43, g);
        }

        [Fact]
        public void GetAngleGreaterThan180Degrees()
        {
            var a = new Point(2, 2);
            var b = new Point(4, 3);
            var g = Geometry.GetAngle(a, b);

            Assert.Equal(243.43, g);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = System.IO.File.ReadAllLines("../../../input/day_10.txt");

            AsteroidMap map = new AsteroidMap(input);

            int mostVisible = 0;
            Point location;
            foreach (Point asteroid in map.Asteroids)
            {
                int visible = map.CountVisibleAsteroids(asteroid);

                if(visible > mostVisible)
                {
                    mostVisible = visible;
                    location = asteroid;
                }
            }

            Assert.Equal(263, mostVisible);
        }
    }
}
