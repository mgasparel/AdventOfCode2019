using System.Collections.Generic;

namespace AdventOfCode2019.Day11
{
    public class HullPaintingRobot
    {
        public static int Black = 0;
        public static int White = 1;

        public static int Up = 0;

        public static int Right = 1;

        public static int Down = 2;

        public static int Left = 3;

        int currentDirection = 0;

        Intcode intcode;

        public List<Panel> Panels = new List<Panel>
        {
            new Panel
            {
                Location = new Point(0,0),
                Color = White
            }
        };

        public HullPaintingRobot(Intcode intcode)
        {
            this.intcode = intcode;
        }

        public void Paint()
        {
            var p = new Point(0, 0);

            try
            {
                while (true)
                {
                    var color = GetCurrentColor(p);

                    var nextColor = intcode.Run(color);
                    var turnDirection = intcode.Run(color);

                    PaintPanel(p, nextColor);

                    SetDirection(turnDirection);

                    p = Move(p);
                }
            }
            catch (System.Exception e)
            {
                if(e.Message != "Halted!")
                {
                    throw;
                }
            }
        }

        Point Move(Point p)
        {
            var p2 = new Point(p.x, p.y);

            switch (currentDirection)
            {
                case 0:
                    p2.y--;
                    break;
                case 1:
                    p2.x++;
                    break;
                case 2:
                    p2.y++;
                    break;
                case 3:
                    p2.x--;
                    break;
                default:
                    throw new System.Exception("");
            }

            return p2;
        }

        void SetDirection(long turnDirection)
        {
            if(turnDirection == 0)
            {
                // Turn left.
                currentDirection -= 1;

                if(currentDirection < 0)
                {
                    currentDirection = 3;
                }
            }
            else if(turnDirection == 1)
            {
                // Turn Right.
                currentDirection += 1;

                if(currentDirection > 3)
                {
                    currentDirection = 0;
                }
            }
            else
            {
                throw new System.Exception($"Invalid direction {turnDirection}");
            }

        }

        void PaintPanel(Point p, long color)
        {
            int c = (int)color;
            var panel = new Panel
            {
                Color = c,
                Location = p
            };

            Panels.Add(panel);
        }

        int GetCurrentColor(Point p)
        {
            for (int i = Panels.Count - 1; i >= 0; i--)
            {
                if(Panels[i].Location.Equals(p))
                {
                    return Panels[i].Color;
                }
            }

            return Black;
        }
    }

    public class Panel
    {
        public int Color { get; set; }

        public Point Location { get; set; }
    }

    public struct Point
    {
        public int x { get; set; }

        public int y { get; set; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
