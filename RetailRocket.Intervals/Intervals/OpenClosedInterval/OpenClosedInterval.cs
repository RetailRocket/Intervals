namespace Interval.Intervals.OpenClosedInterval
{
    using System;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct OpenClosedInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        internal OpenClosedInterval(
            LowerOpenBoundary<TPoint> lowerBoundary,
            UpperClosedBoundary<TPoint> upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerOpenBoundary<TPoint> LowerBoundary { get; }

        public UpperClosedBoundary<TPoint> UpperBoundary { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is OpenClosedInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            OpenClosedInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}