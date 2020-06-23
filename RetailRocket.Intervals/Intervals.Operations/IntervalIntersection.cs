namespace Interval.Intervals.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.Operations;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.Factories;

    public static class IntervalIntersection
    {

        public static IInterval<TPoint, TPointComparer> Intersect<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary>(
            this IInterval<TPoint, TPointComparer> interval,
            IInterval<TPoint, TPointComparer> other,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
            where TLowerBoundary : ILowerBoundary<TPoint, TPointComparer>
            where TUpperBoundary : IUpperBoundary<TPoint, TPointComparer> =>
            (interval, other) switch
            {
                (IBoundaryInterval<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary> left, IBoundaryInterval<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary> right) =>
                left.Intersect(right, pointComparer),
                _ => new EmptyInterval<TPoint, TPointComparer>()
            };

        public static IInterval<TPoint, TPointComparer> Intersect<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary>(
            this IBoundaryInterval<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary> interval,
            IBoundaryInterval<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary> otherInterval,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
            where TLowerBoundary : ILowerBoundary<TPoint, TPointComparer>
            where TUpperBoundary : IUpperBoundary<TPoint, TPointComparer>
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