namespace adventofcodetests.Day2
{
    using System;
    using System.IO;
    using System.Linq;
    using Xunit;
    using Utils.ExtensionMethods;
    using static AdventOfCode.Day2.DayTwo;

    public class DayTwoTests
    {
        [Fact]
        public void ChecksumStar1Tests()
        {
            var input = new string[] { "5 1 9 5", "7 5 3", "2 4 6 8" };
            var result = Star1(input);
            Assert.Equal(18, result);
        }

        [Fact]
        public void ChecksumStar2Tests()
        {
            var input = new string[] { "5 9 2 8", "9 4 7 3", "3 8 6 5" };
            var result = Star2(input);
            Assert.Equal(9, result);
        }
    }
}
