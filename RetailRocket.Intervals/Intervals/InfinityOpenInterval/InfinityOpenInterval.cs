namespace Interval.Intervals.InfinityOpenInterval
{
    using System;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityOpenInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        public InfinityOpenInterval(
            UpperOpenBoundary<TPoint> upperBoundary)
        {
            this.UpperBoundary = upperBoundary;
        }

        public LowerInfinityBoundary<TPoint> LowerBoundary { get; }

        public UpperOpenBoundary<TPoint> UpperBoundary { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is InfinityOpenInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            InfinityOpenInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}