namespace Utils.Memorize
{
    using System;
    using System.Collections.Concurrent;

    public static class Memoize
    {
        public static Func<TReturn> Memo<TReturn>(this Func<TReturn> func)
        {
            object cache = null;
            return () =>
            {
                if (cache == null)
                {
                    cache = func();
                }

                return (TReturn)cache;
            };
        }

        public static Func<TSource, TReturn> Memo<TSource, TReturn>(this Func<TSource, TReturn> func)
        {
            var cache = new ConcurrentDictionary<TSource, TReturn>();

            return argument => cache.GetOrAdd(argument, func);
        }


        public static Func<TSource1, TSource2, TReturn> Memo<TSource1, TSource2, TReturn>(this Func<TSource1, TSource2, TReturn> func)
        {
            var cache = new ConcurrentDictionary<(TSource1, TSource2), TReturn>();

            return (argument1, argument2) => cache.GetOrAdd((argument1, argument2), func(argument1, argument2));
        }
    }
}
