namespace Interval.Intervals.ClosedInfinityInterval
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedInfinityInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public ClosedInfinityInterval(
            LowerClosedBoundary<TPoint, TPointComparer> lowerBoundary)
        {
            UpperInfinityBoundary<TPoint, TPointComparer> upperBoundary;
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerClosedBoundary<TPoint, TPointComparer> LowerBoundary { get; }

        public UpperInfinityBoundary<TPoint, TPointComparer> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.LowerBoundary.Point, point) >= 0;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is ClosedInfinityInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            ClosedInfinityInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary);
        }

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map)
        {
            yield return map(this.LowerBoundary.Point);
        }
    }
}