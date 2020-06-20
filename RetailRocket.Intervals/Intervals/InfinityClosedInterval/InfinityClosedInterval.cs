namespace Interval.Intervals.InfinityClosedInterval
{
    using System;
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityClosedInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public InfinityClosedInterval(
            UpperClosedBoundary<TPoint, TPointComparer> upperBoundary)
        {
            LowerInfinityBoundary<TPoint, TPointComparer> lowerInfinityBoundary;
            this.LowerBoundary = lowerInfinityBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerInfinityBoundary<TPoint, TPointComparer> LowerBoundary { get; }

        public UpperClosedBoundary<TPoint, TPointComparer> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.UpperBoundary.Point, point) <= 0;
        }

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map)
        {
            yield return map(this.UpperBoundary.Point);
        }
    }
}