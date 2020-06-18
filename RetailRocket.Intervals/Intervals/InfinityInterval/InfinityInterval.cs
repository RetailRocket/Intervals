namespace Interval.Intervals.InfinityInterval
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityInterval<TPoint, TPointComparer>
        where TPointComparer : IComparer<TPoint>, new()
    {
        public LowerInfinityBoundary<TPoint> LowerBoundary { get; }

        public UpperInfinityBoundary<TPoint> UpperBoundary { get; }

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