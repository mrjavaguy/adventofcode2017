namespace utilstests.memorize
{
    using System;
    using System.Diagnostics;
    using Utils.Memorize;
    using Xunit;

    public class MemorizeTests
    {
        [Fact]
        public void MemoJustReturn()
        {
            Func<int> f = () => { var x = 0; for (var y = 0; y < 1000; y++) x += y; return x; };

            f.Memo();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var x1 = f();
            stopwatch.Stop();
            var first = stopwatch.Elapsed;
            stopwatch.Reset();
            stopwatch.Start();
            var x2 = f();
            stopwatch.Stop();
            var second = stopwatch.Elapsed;
            Assert.True(second < first);
            Assert.Equal(x1, x2);
        }

        [Fact]
        public void MemoOneValue()
        {
            Func<int, int> f = null;
            f = n => n > 1 ? f(n - 1) + f(n - 2) : n;

            f.Memo();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var x1 = f(10);
            stopwatch.Stop();
            var first = stopwatch.Elapsed;
            stopwatch.Reset();
            stopwatch.Start();
            var x2 = f(10);
            stopwatch.Stop();
            var second = stopwatch.Elapsed;
            Assert.True(second < first);
            Assert.Equal(x1, x2);
        }


        [Fact]
        public void MemoTwoValues()
        {
            Func<int, int, int> f = null;
            f = (x, y) =>
            {
                var z = 0;
                for (var i = 0; i < x; i++)
                    for (var j = 0; j < y; j++)
                        z += i * j; 
                return z;
            };

            f.Memo();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var x1 = f(100, 100);
            stopwatch.Stop();
            var first = stopwatch.Elapsed;
            stopwatch.Reset();
            stopwatch.Start();
            var x2 = f(100, 100);
            stopwatch.Stop();
            var second = stopwatch.Elapsed;
            Assert.True(second < first);
            Assert.Equal(x1, x2);
        }
    }
}
