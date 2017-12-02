namespace utilstests.ExtensionMethodsTests
{
    using static Utils.ExtensionMethods.CharExtensions;
    using LaYumba.Functional;
    using static LaYumba.Functional.F;
    using Xunit;
    public class CharExtensionsTests
    {
        [Theory]
        [InlineData('0', 0)]
        [InlineData('1', 1)]
        [InlineData('2', 2)]
        [InlineData('3', 3)]
        [InlineData('4', 4)]
        [InlineData('5', 5)]
        [InlineData('6', 6)]
        [InlineData('7', 7)]
        [InlineData('8', 8)]
        [InlineData('9', 9)]
        [InlineData('A', -1)]
        public void ToInteger(char input, int expected)
        {
            var actual = input.ToInteger().Match(() => -1, (value) => value);
            Assert.Equal(expected, actual);
        }
    }
}
