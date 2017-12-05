
using System;
using System.Collections.Immutable;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day5
{
    public static class DayFive
    {
        public static int JumpMaze(ImmutableList<int> input, Func<int, int> jumpRule)
        {
            var i = 0;
            var l = input.Count;
            var steps = 0;
            while (i > -1 && i < l)
            {
                steps++;
                var old = input[i];
                input = input.SetItem(i, jumpRule(old));
                i += old;
            }
            return steps;
        }

        public static int StarOne()
        {
            var input = File.ReadAllLines(@"C:\dev\personal\adventofcode2017\src\adventofcode\Day5\input.txt").Select(s => int.Parse(s)).ToImmutableList();
            Func<int, int> rule = i => i + 1;
            return JumpMaze(input, rule);
        }

        public static int StarTwo()
        {
            var input = File.ReadAllLines(@"C:\dev\personal\adventofcode2017\src\adventofcode\Day5\input.txt").Select(s => int.Parse(s)).ToImmutableList();
            Func<int, int> rule = i => i >= 3 ? i - 1 : i + 1;
            return JumpMaze(input, rule);
        }
    }
}
