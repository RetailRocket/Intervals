namespace Interval.Intervals.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.Operations;
    using Interval.Intervals.Factories;

    public static class IntervalIntersection
    {
        public static IInterval<TPoint, TPointComparer> Intersect<TPoint, TPointComparer>(
            this IInterval<TPoint, TPointComparer> interval,
            IInterval<TPoint, TPointComparer> other,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (interval, other) switch
            {
                (BoundaryInterval<TPoint, TPointComparer> left, BoundaryInterval<TPoint, TPointComparer> right) => left.Intersect(right, pointComparer),
                _ => new EmptyInterval<TPoint, TPointComparer>()
            };

        public static IInterval<TPoint, TPointComparer> Intersect<TPoint, TPointComparer>(
            this BoundaryInterval<TPoint, TPointComparer> interval,
            BoundaryInterval<TPoint, TPointComparer> otherInterval,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var maxLowerBoundary = interval.LowerBoundary
                .Compare(
                    otherInterval.LowerBoundary,
                    pointComparer) >= 0
                ? interval.LowerBoundary
                : otherInterval.LowerBoundary;

            var minLowerBoundary = interval.UpperBoundary
                .Compare(
                    otherInterval.UpperBoundary,
                    pointComparer) <= 0
                ? interval.UpperBoundary
                : otherInterval.UpperBoundary;

            return IntervalFactory.Build(
                lowerBoundary: maxLowerBoundary,
                upperBoundary: minLowerBoundary,
                pointComparer: pointComparer);
        }
    }
}