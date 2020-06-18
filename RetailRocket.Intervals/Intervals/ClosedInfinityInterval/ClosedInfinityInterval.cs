namespace Interval.Intervals.ClosedInfinityInterval
{
    using System;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedInfinityInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        public ClosedInfinityInterval(
            LowerClosedBoundary<TPoint> lowerBoundary)
        {
            this.LowerBoundary = lowerBoundary;
        }

        public LowerClosedBoundary<TPoint> LowerBoundary { get; }

        public UpperInfinityBoundary<TPoint> UpperBoundary { get; }

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
    }
}