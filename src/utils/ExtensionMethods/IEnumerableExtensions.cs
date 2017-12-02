namespace Utils.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> Rotate<TSource>(this IEnumerable<TSource> enumerable, int amountToRotate) =>
            enumerable.Skip(amountToRotate).Concat(enumerable.Take(amountToRotate));
    }
}
