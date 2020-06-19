namespace Interval.Intervals
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.ClosedInfinityInterval;
    using Interval.Intervals.ClosedInterval;
    using Interval.Intervals.ClosedOpenInterval;
    using Interval.Intervals.InfinityClosedInterval;
    using Interval.Intervals.InfinityInterval;
    using Interval.Intervals.InfinityOpenInterval;
    using Interval.Intervals.OpenClosedInterval;
    using Interval.Intervals.OpenInfinityInterval;
    using Interval.Intervals.OpenInterval;

    public static class IntervalFactory
    {
        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            ILowerBoundary<TPoint> lowerBoundary,
            IUpperBoundary<TPoint> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, upperBoundary) switch
            {
                (LowerClosedBoundary<TPoint> lowerClosed, UpperClosedBoundary<TPoint> upperClosed) => Build(lowerClosed, upperClosed, pointComparer),
                (LowerClosedBoundary<TPoint> lowerClosed, UpperOpenBoundary<TPoint> upperOpen) => Build(lowerClosed, upperOpen, pointComparer),
                (LowerClosedBoundary<TPoint> lowerClosed, UpperInfinityBoundary<TPoint> _) => new ClosedInfinityInterval<TPoint, TPointComparer>(lowerClosed),

                (LowerOpenBoundary<TPoint> lowerOpen, UpperClosedBoundary<TPoint> upperClosed) => Build(lowerOpen, upperClosed, pointComparer),
                (LowerOpenBoundary<TPoint> lowerOpen, UpperOpenBoundary<TPoint> upperOpen) => Build(lowerOpen, upperOpen, pointComparer),
                (LowerOpenBoundary<TPoint> lowerOpen, UpperInfinityBoundary<TPoint> _) => new OpenInfinityInterval<TPoint, TPointComparer>(lowerOpen),

                (LowerInfinityBoundary<TPoint> lowerInfinity, UpperClosedBoundary<TPoint> upperClosed) => new InfinityClosedInterval<TPoint, TPointComparer>(upperClosed),
                (LowerInfinityBoundary<TPoint> lowerInfinity, UpperOpenBoundary<TPoint> upperOpen) => new InfinityOpenInterval<TPoint, TPointComparer>(upperOpen),
                (LowerInfinityBoundary<TPoint> _, UpperInfinityBoundary<TPoint> _) => default(InfinityInterval<TPoint, TPointComparer>),
                _ => throw new ArgumentException()
            };

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosed,
            UpperClosedBoundary<TPoint> upperClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return ClosedIntervalFactory.Build(
                    lowerBoundary: lowerClosed,
                    upperBoundary: upperClosed,
                    pointComparer: pointComparer)
                .Match(
                    closedInterval => (IInterval<TPoint, TPointComparer>)closedInterval,
                    () => new EmptyInterval.EmptyInterval<TPoint, TPointComparer>());
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosed,
            UpperOpenBoundary<TPoint> upperOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return ClosedOpenIntervalFactory.Build(
                    lowerBoundary: lowerClosed,
                    upperBoundary: upperOpen,
                    pointComparer: pointComparer)
                .Match(
                    closedInterval => (IInterval<TPoint, TPointComparer>)closedInterval,
                    () => new EmptyInterval.EmptyInterval<TPoint, TPointComparer>());
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpen,
            UpperOpenBoundary<TPoint> upperClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return OpenIntervalFactory.Build(
                    lowerBoundary: lowerOpen,
                    upperBoundary: upperClosed,
                    pointComparer: pointComparer)
                .Match(
                    closedInterval => (IInterval<TPoint, TPointComparer>)closedInterval,
                    () => new EmptyInterval.EmptyInterval<TPoint, TPointComparer>());
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerOpen,
            UpperClosedBoundary<TPoint> upperClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return OpenClosedIntervalFactory.Build(
                    lowerBoundary: lowerOpen,
                    upperBoundary: upperClosed,
                    pointComparer: pointComparer)
                .Match(
                    closedInterval => (IInterval<TPoint, TPointComparer>)closedInterval,
                    () => new EmptyInterval.EmptyInterval<TPoint, TPointComparer>());
        }
    }
}