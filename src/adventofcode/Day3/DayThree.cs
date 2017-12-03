
namespace AdventOfCode.Day3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayThree
    {
        public enum Direction
        {
            North,
            West,
            South,
            East,
        }

        public static IEnumerable<Direction> Directions()
        {
            var value = 0;
            for (; ; )
            {
                yield return (Direction)value;
                value = (value + 1) % 4;
            }
        }

        public struct SpiralPoint
        {
            private readonly int value;
            private readonly int x;
            private readonly int y;
            public SpiralPoint(int value, int x, int y)
            {
                this.value = value;
                this.x = x;
                this.y = y;
            }

            public int Value => value;
            public int X => x;
            public int Y => y;
        }

        public static IEnumerable<SpiralPoint> SpiralPoints()
        {
            var value = 0;
            var x = 0;
            var y = 0;
            var direction = Directions().GetEnumerator();
            while (direction.Current != Direction.South)
            {
                direction.MoveNext();
            }
            var armNumber = ArmDistance().GetEnumerator();
            armNumber.MoveNext();
            var distanceTraveled = 0;

            for (; ; )
            {
                value++;
                yield return new SpiralPoint(value, x, y);

                if (distanceTraveled == armNumber.Current)
                {
                    distanceTraveled = 0;
                    armNumber.MoveNext();
                    direction.MoveNext();
                }
                distanceTraveled++;

                switch (direction.Current)
                {
                    case Direction.East:
                        x++;
                        break;
                    case Direction.North:
                        y++;
                        break;
                    case Direction.West:
                        x--;
                        break;
                    case Direction.South:
                        y--;
                        break;
                }
            }

        }

        public static int ManhattanDistance(this SpiralPoint point)
        {
            return (Math.Abs(point.X) + Math.Abs(point.Y));
        }

        public static IEnumerable<int> ArmDistance()
        {
            var armNumber = 1;
            for (; ; )
            {
                yield return armNumber;
                yield return armNumber;
                armNumber++;
            }

        }



        public static IEnumerable<SpiralPoint> AdjacentSpiral()
        {
            var cache = new Dictionary<(int, int), SpiralPoint>();

            IEnumerable<SpiralPoint> GetNeighbors(int xAxis, int yAxis)
            {
                var neighbors = new List<SpiralPoint>();
  
                for (var i = -1; i <= 1; i++)
                {
                    for (var j = -1; j <= 1; j++)
                    {
                        if (cache.TryGetValue((xAxis + i, yAxis + j), out var neighbor))
                        {
                            neighbors.Add(neighbor);
                        }
                    }
                }
  
                return neighbors;
            }

            var value = 0;
            var x = 0;
            var y = 0;
            var direction = Directions().GetEnumerator();
            while (direction.Current != Direction.East)
            {
                direction.MoveNext();
            }
            var armNumber = ArmDistance().GetEnumerator();
            armNumber.MoveNext();
            var distanceTraveled = 0;


            for (; ; )
            {
                value = Math.Max(GetNeighbors(x,y).Sum(n => n.Value), 1);
                var point = new SpiralPoint(value, x, y);
                cache.Add((x, y), point);
                yield return point;

                if (distanceTraveled == armNumber.Current)
                {
                    distanceTraveled = 0;
                    armNumber.MoveNext();
                    direction.MoveNext();
                }
                distanceTraveled++;

                switch (direction.Current)
                {
                    case Direction.East:
                        x++;
                        break;
                    case Direction.North:
                        y++;
                        break;
                    case Direction.West:
                        x--;
                        break;
                    case Direction.South:
                        y--;
                        break;
                }
            }
        }

        public static int StarOne(int input) => SpiralPoints().Take(input).Last().ManhattanDistance();

        public static int AdjacentSpiral(int input)
        {
            return AdjacentSpiral().Take(input).Last().Value;
        }

        public static int StarTwo(int input)
        {
            return AdjacentSpiral().SkipWhile(a => a.Value < input).First().Value;
        }
    }
}
