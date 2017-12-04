namespace adventofcodetests.Day4
{
    using System.IO;
    using Xunit;
    using static AdventOfCode.Day4.DayFour;

    public class DayFourTests
    {
        [Theory]
        [InlineData("aa bb cc dd ee", true)]
        [InlineData("aa bb cc dd aa", false)]
        [InlineData("aa bb cc dd aaa", true)]
        public void Day1PassPhraseTest(string input, bool expected)
        {
            var actual = IsValidPassPhrase(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcde fghi", false)]
        [InlineData("abcde xyz ecdab", true)]
        [InlineData("a ab abc abd abf abj", false)]
        [InlineData("iiii oiii ooii oooi oooo", false)]
        [InlineData("oiii ioii iioi iiio", true)]
        public void Day1ContainsAnagramTest(string input, bool expected)
        {
            var actual = input.GetWords().ContainsAnagram();
            Assert.Equal(expected, actual);
        }
    }
}
