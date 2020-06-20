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
            ILowerBoundary<TPoint, TPointComparer> lowerBoundary,
            IUpperBoundary<TPoint, TPointComparer> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, upperBoundary) switch
            {
                (LowerClosedBoundary<TPoint, TPointComparer> lowerClosed, UpperClosedBoundary<TPoint, TPointComparer> upperClosed) => Build(lowerClosed, upperClosed, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> lowerClosed, UpperOpenBoundary<TPoint, TPointComparer> upperOpen) => Build(lowerClosed, upperOpen, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> lowerClosed, UpperInfinityBoundary<TPoint, TPointComparer> _) => new ClosedInfinityInterval<TPoint, TPointComparer>(lowerClosed),

                (LowerOpenBoundary<TPoint, TPointComparer> lowerOpen, UpperClosedBoundary<TPoint, TPointComparer> upperClosed) => Build(lowerOpen, upperClosed, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> lowerOpen, UpperOpenBoundary<TPoint, TPointComparer> upperOpen) => Build(lowerOpen, upperOpen, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> lowerOpen, UpperInfinityBoundary<TPoint, TPointComparer> _) => new OpenInfinityInterval<TPoint, TPointComparer>(lowerOpen),

                (LowerInfinityBoundary<TPoint, TPointComparer> lowerInfinity, UpperClosedBoundary<TPoint, TPointComparer> upperClosed) => new InfinityClosedInterval<TPoint, TPointComparer>(upperClosed),
                (LowerInfinityBoundary<TPoint, TPointComparer> lowerInfinity, UpperOpenBoundary<TPoint, TPointComparer> upperOpen) => new InfinityOpenInterval<TPoint, TPointComparer>(upperOpen),
                (LowerInfinityBoundary<TPoint, TPointComparer> _, UpperInfinityBoundary<TPoint, TPointComparer> _) => default(InfinityInterval<TPoint, TPointComparer>),
                _ => throw new ArgumentException()
            };

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint, TPointComparer> lowerClosed,
            UpperClosedBoundary<TPoint, TPointComparer> upperClosed,
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
            LowerClosedBoundary<TPoint, TPointComparer> lowerClosed,
            UpperOpenBoundary<TPoint, TPointComparer> upperOpen,
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
            LowerOpenBoundary<TPoint, TPointComparer> lowerOpen,
            UpperOpenBoundary<TPoint, TPointComparer> upperClosed,
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
            LowerOpenBoundary<TPoint, TPointComparer> lowerOpen,
            UpperClosedBoundary<TPoint, TPointComparer> upperClosed,
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