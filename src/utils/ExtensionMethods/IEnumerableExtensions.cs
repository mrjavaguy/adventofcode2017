namespace Utils.ExtensionMethods
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> Rotate<TSource>(this IEnumerable<TSource> enumerable, int amountToRotate) =>
            enumerable.Skip(amountToRotate).Concat(enumerable.Take(amountToRotate));

        public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> elements, int size) =>
            size == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Permutations(size - 1).Select(c => (new[] { e }).Concat(c)));
    }
}
