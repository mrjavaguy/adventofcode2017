namespace AdventOfCode.Day1
{
    using static Common;

    public static class DayOne
    {
        public static int StarOne(string input) => CalculateInverseCaptcha(input, 1);
        public static int StarTwo(string input) => CalculateInverseCaptcha(input, (input.Length / 2));
    }
}
