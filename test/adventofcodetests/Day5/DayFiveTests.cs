
namespace adventofcodetests.Day5
{
    using System;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using Xunit;
    using static AdventOfCode.Day5.DayFive;

    public class DayFiveTests
    {
        [Fact]
        public void StarOneTests()
        {
            var input = ImmutableList<int>.Empty.Add(0).Add(3).Add(0).Add(1).Add(-3);
            Func<int, int> rule = i => i + 1;
            Assert.Equal(5, JumpMaze(input, rule));
        }
    }
}
