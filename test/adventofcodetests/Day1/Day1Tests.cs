namespace adventofcodetests.Day1
{
    using Xunit;
    using static AdventOfCode.Day1.DayOne;
    public class Day1Tests
    {
        [Theory]
        [InlineData("1122", 3)]
        [InlineData("1111", 4)]
        [InlineData("1234", 0)]
        [InlineData("91212129", 9)]
        public void InverseCaptchaStarOne(string input, int expected)
        {
            var actual = StarOne(input);
            Assert.Equal(expected, actual);
        }

        [InlineData("1212", 6)]
        [InlineData("1221", 0)]
        [InlineData("123425", 4)]
        [InlineData("123123", 12)]
        [InlineData("12131415", 4)]
        public void InverseCaptchaStarTwo(string input, int expected)
        {
            var actual = StarTwo(input);
            Assert.Equal(expected, actual);
        }
    }
}
