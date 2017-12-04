
namespace AdventOfCode.Day4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class DayFour
    {

        public static bool IsValidPassPhrase(string phrase)
        {
            return !GetWords(phrase).GroupBy(w => w).Any(g => g.Count() > 1);
        }

        public static string[] GetWords(this string phrase)
        {
            return phrase.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool IsAnagram(string one, string two)
        {
            if (one.Length == two.Length)
            {
                return one.OrderBy(c => c).SequenceEqual(two.OrderBy(c => c));
            }

            return false;
        }

        public static bool ContainsAnagram(this IEnumerable<string> enumerable)
        {
            return enumerable.SelectMany(f => enumerable.Where(s => f != s).Select(s => (f, s))).Any(p => IsAnagram(p.f, p.s));
        }


        public static int StarOne(string[] input) =>
             input.Where(s => IsValidPassPhrase(s)).Count();

        public static int StarTwo(string[] input) =>
            input.Where(s => !(s.GetWords().ContainsAnagram())).Where(s => IsValidPassPhrase(s)).Count();
    }
}
