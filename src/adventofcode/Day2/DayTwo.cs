namespace AdventOfCode.Day2
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using Utils.ExtensionMethods;

    public static class DayTwo
    {
        public static IEnumerable<int> Parser(string s) =>
            s.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n));

        public static int Star1(string[] input) => 
            input
                .Select(s => Parser(s))
                .Select(l => (Max: l.Max(), Min: l.Min()))
                .Select(m => m.Max - m.Min).Sum();

        public static int Star2(string[] input) => 
            input
                .Select(s => Parser(s))
                .Select(l => l.Permutations(2).Where(p => p.First() % p.Last() == 0 || p.Last() % p.First() == 0).Select(p => (Max: p.Max(), Min: p.Min())).Select(m => m.Max / m.Min).First())
                .Sum();
    }
}
