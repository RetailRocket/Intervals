namespace Interval.OneOfIntervals
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.ClosedInfinityInterval;
    using Interval.Intervals.ClosedInterval;
    using Interval.Intervals.ClosedOpenInterval;
    using Interval.Intervals.EmptyInterval;
    using Interval.Intervals.InfinityClosedInterval;
    using Interval.Intervals.InfinityInterval;
    using Interval.Intervals.InfinityOpenInterval;
    using Interval.Intervals.OpenClosedInterval;
    using Interval.Intervals.OpenInfinityInterval;
    using Interval.Intervals.OpenInterval;
    using Interval.OneOfBoundaries;

    public class OneOfIntervalsFactory
    {
        public static OneOfIntervals<TPoint, TPointComparer>
            Build<TPoint, TPointComparer>(
                OneOfLowerBoundaries<TPoint> oneOfLowerBoundaries,
                OneOfUpperBoundaries<TPoint> oneOfUpperBoundaries,
                TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var oneOfIntervals = oneOfLowerBoundaries.Match(
                _ => BuildWithLowerInfinityBoundary<TPoint, TPointComparer>(
                    oneOfUpperBoundaries),
                lowerClosedBoundary => BuildWithLowerClosedBoundary(
                    lowerClosedBoundary,
                    oneOfUpperBoundaries,
                    pointComparer),
                lowerOpenBoundary => BuildWithLowerOpenBoundary(
                    lowerOpenBoundary,
                    oneOfUpperBoundaries,
                    pointComparer));

            return oneOfIntervals;
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildClosedInterval<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary,
            UpperClosedBoundary<TPoint> upperClosedBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return ClosedIntervalFactory.Build(
                    lowerClosedBoundary,
                    upperClosedBoundary,
                    pointComparer)
                .Match<OneOfIntervals<TPoint, TPointComparer>>(
                    openClosedInterval =>
                        new OneOfBoundaryIntervals<TPoint, TPointComparer>(openClosedInterval),
                    () =>
                        new EmptyInterval<TPoint, TPointComparer>());
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildClosedOpenInterval<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary,
            UpperOpenBoundary<TPoint> upperOpenBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return ClosedOpenIntervalFactory.Build(
                    lowerClosedBoundary,
                    upperOpenBoundary,
                    pointComparer)
                .Match<OneOfIntervals<TPoint, TPointComparer>>(
                    openInterval =>
                        new OneOfBoundaryIntervals<TPoint, TPointComparer>(openInterval),
                    () =>
                        new EmptyInterval<TPoint, TPointComparer>());
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildOpenClosedInterval<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpenBoundary,
            UpperClosedBoundary<TPoint> upperClosedBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return OpenClosedIntervalFactory.Build(
                    lowerOpenBoundary,
                    upperClosedBoundary,
                    pointComparer)
                .Match<OneOfIntervals<TPoint, TPointComparer>>(
                    openClosedInterval =>
                        new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                            openClosedInterval),
                    () =>
                        new EmptyInterval<TPoint, TPointComparer>());
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildOpenInterval<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpenBoundary,
            UpperOpenBoundary<TPoint> upperOpenBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return OpenIntervalFactory.Build(
                    lowerOpenBoundary,
                    upperOpenBoundary,
                    pointComparer)
                .Match<OneOfIntervals<TPoint, TPointComparer>>(
                    openClosedInterval =>
                        new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                            openClosedInterval),
                    () =>
                        new EmptyInterval<TPoint, TPointComparer>());
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildOpenInfinityInterval<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpenBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                new OpenInfinityInterval<TPoint, TPointComparer>(
                    lowerOpenBoundary));
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildClosedInfinityInterval<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                new ClosedInfinityInterval<TPoint, TPointComparer>(
                    lowerClosedBoundary));
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildInfinityOpenInterval<TPoint, TPointComparer>(
            UpperOpenBoundary<TPoint> upperOpenBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                new InfinityOpenInterval<TPoint, TPointComparer>(
                    upperOpenBoundary));
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildInfinityClosedInterval<TPoint, TPointComparer>(
            UpperClosedBoundary<TPoint> upperClosedBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                new InfinityClosedInterval<TPoint, TPointComparer>(
                    upperClosedBoundary));
        }

        public static OneOfIntervals<TPoint, TPointComparer> BuildInfinityInterval<TPoint, TPointComparer>()
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            InfinityInterval<TPoint, TPointComparer> infinityInterval;
            return new OneOfBoundaryIntervals<TPoint, TPointComparer>(
                infinityInterval);
        }

        private static OneOfIntervals<TPoint, TPointComparer> BuildWithLowerOpenBoundary<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpenBoundary,
            OneOfUpperBoundaries<TPoint> oneOfUpperBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfUpperBoundaries.Match(
                upperInfinityBoundary => BuildOpenInfinityInterval<TPoint, TPointComparer>(
                    lowerOpenBoundary),
                upperClosedBoundary =>
                    BuildOpenClosedInterval(
                        lowerOpenBoundary,
                        upperClosedBoundary,
                        pointComparer),
                upperOpenBoundary => BuildOpenInterval(
                    lowerOpenBoundary,
                    upperOpenBoundary,
                    pointComparer));
        }

        private static OneOfIntervals<TPoint, TPointComparer> BuildWithLowerClosedBoundary<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary,
            OneOfUpperBoundaries<TPoint> oneOfUpperBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfUpperBoundaries.Match(
                upperInfinityBoundary => BuildClosedInfinityInterval<TPoint, TPointComparer>(
                    lowerClosedBoundary),
                upperClosedBoundary => BuildClosedInterval(
                    lowerClosedBoundary,
                    upperClosedBoundary,
                    pointComparer),
                upperOpenBoundary => BuildClosedOpenInterval(
                    lowerClosedBoundary,
                    upperOpenBoundary,
                    pointComparer));
        }

        private static OneOfIntervals<TPoint, TPointComparer> BuildWithLowerInfinityBoundary<TPoint, TPointComparer>(
            OneOfUpperBoundaries<TPoint> oneOfUpperBoundaries)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfUpperBoundaries.Match(
                _ => BuildInfinityInterval<TPoint, TPointComparer>(),
                BuildInfinityClosedInterval<TPoint, TPointComparer>,
                BuildInfinityOpenInterval<TPoint, TPointComparer>);
        }
    }
}