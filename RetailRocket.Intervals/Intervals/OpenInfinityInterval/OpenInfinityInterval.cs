namespace Interval.Intervals.OpenInfinityInterval
{
    using System;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct OpenInfinityInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        public OpenInfinityInterval(
            LowerOpenBoundary<TPoint> lowerBoundary)
        {
            this.LowerBoundary = lowerBoundary;
        }

        public LowerOpenBoundary<TPoint> LowerBoundary { get; }

        public UpperInfinityBoundary<TPoint> UpperBoundary { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is OpenInfinityInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            OpenInfinityInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}