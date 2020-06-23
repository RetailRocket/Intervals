namespace ConsoleApp1
{
    using System;
    using System.Diagnostics;
    using Interval;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.Factories;

    public class Program
    {
        public static void Main(
            string[] args)
        {
            var comparer = new IntComparer();
            var interval = IntervalFactory.Build(
                new LowerClosedBoundary<int, IntComparer>(0),
                new UpperClosedBoundary<int, IntComparer>(101),
                comparer);

            var rnd = new Random();
            var t = false;
            var stopWatch = Stopwatch.StartNew();
            for (uint i = 0; i < 100000000; ++i)
            {
                var point = rnd.Next(1, 100);
                t = t || interval.Contains(point, comparer);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            Console.WriteLine(t);
        }
    }
}