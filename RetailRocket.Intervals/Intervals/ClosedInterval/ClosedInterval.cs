namespace Interval.Intervals.ClosedInterval
{
    using System;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        internal ClosedInterval(
            LowerClosedBoundary<TPoint> lowerBoundary,
            UpperClosedBoundary<TPoint> upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerClosedBoundary<TPoint> LowerBoundary { get; }

        public UpperClosedBoundary<TPoint> UpperBoundary { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is ClosedInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            ClosedInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}