
namespace adventofcodetests.Day3
{
    using System;
    using System.Linq;
    using Xunit;
    using static AdventOfCode.Day3.DayThree;

    public class DayThreeTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        public void DistanceToTravelOnSpiralArm(int armNumber, int expected)
        {
            var actual = ArmDistance().Take(armNumber).Last();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(12, 3)]
        [InlineData(23, 2)]
        [InlineData(1024, 31)]
        public void StarOneTests(int input, int expected)
        {
            var actual = StarOne(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 4)]
        [InlineData(5, 5)]
        [InlineData(6, 10)]
        [InlineData(7, 11)]
        [InlineData(8, 23)]
        [InlineData(9, 25)]
        [InlineData(10, 26)]
        [InlineData(11, 54)]
        [InlineData(12, 57)]
        [InlineData(13, 59)]
        [InlineData(14, 122)]
        [InlineData(15, 133)]
        [InlineData(16, 142)]
        [InlineData(17, 147)]
        [InlineData(18, 304)]
        public void AdjacentSpiralTests(int input, int expected)
        {
            var actual = AdjacentSpiral(input);
            Assert.Equal(expected, actual);
        }
    }
}
