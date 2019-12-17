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
        public void Part5()
        {
            string[] input = new string[]
            {
                ".#..##.###...#######",
                "##.############..##.",
                ".#.######.########.#",
                ".###.#######.####.#.",
                "#####.##.#.##.###.##",
                "..#####..#.#########",
                "####################",
                "#.####....###.#.#.##",
                "##.#################",
                "#####.##.###..####..",
                "..######..##.#######",
                "####.##.####...##..#",
                ".#####..#.######.###",
                "##...#.##########...",
                "#.##########.#######",
                ".####.#.###.###.#.##",
                "....##.##.###..#####",
                ".#.#.###########.###",
                "#.#.#.#####.####.###",
                "###.##.####.##.#..##"
            };

            var map = new AsteroidMap(input);

            int visible = map.CountVisibleAsteroids(new Point(11, 13));

            var p = AsteroidBlaster.BlastAsteroids(map.AsteroidsPerAngle, 200);

            Assert.Equal(210, visible);
            Assert.Equal(8, p.x);
            Assert.Equal(2, p.y);
        }

        [Fact]
        public void GetAngleLessThan180Degrees()
        {
            var a = new Point(2, 2);
            var b = new Point(4, 3);
            var g = Geometry.GetAngle(a, b);

            Assert.Equal(116.57, g);
        }

        [Fact]
        public void GetAngleGreaterThan180Degrees()
        {
            var a = new Point(2, 2);
            var b = new Point(0, 1);
            var g = Geometry.GetAngle(a, b);

            Assert.Equal(296.57, g);
        }

        [Fact]
        public void SolvePart1()
        {
            var input = System.IO.File.ReadAllLines("../../../input/day_10.txt");

            AsteroidMap map = new AsteroidMap(input);

            int mostVisible = 0;
            Point location = new Point();
            foreach (Point asteroid in map.AsteroidCoordinates)
            {
                int visible = map.CountVisibleAsteroids(asteroid);

                if(visible > mostVisible)
                {
                    mostVisible = visible;
                    location = asteroid;
                }
            }

            Assert.Equal(263, mostVisible);
            Assert.Equal(23, location.x);
            Assert.Equal(29, location.y);
        }

        [Fact]
        public void SolvePart2()
        {
            var input = System.IO.File.ReadAllLines("../../../input/day_10.txt");

            AsteroidMap map = new AsteroidMap(input);
            map.LoadAsteroidsPerAngle(new Point(23, 29));

            var p = AsteroidBlaster.BlastAsteroids(map.AsteroidsPerAngle, 200);

            int result = (p.x * 100) + p.y;

            Assert.Equal(1110, result);
        }
    }
}
