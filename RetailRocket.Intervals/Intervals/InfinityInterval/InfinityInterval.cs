namespace Interval.Intervals.InfinityInterval
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public LowerInfinityBoundary<TPoint, TPointComparer> LowerBoundary { get; }

        public UpperInfinityBoundary<TPoint, TPointComparer> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return true;
        }

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map)
        {
            return Enumerable.Empty<TResult>();
        }

        public override bool Equals(
            object? obj)
        {
            return obj is InfinityInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            InfinityInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}