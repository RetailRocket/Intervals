namespace Interval.Intervals.ClosedOpenInterval
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedOpenInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public ClosedOpenInterval(
            LowerClosedBoundary<TPoint> lowerBoundary,
            UpperOpenBoundary<TPoint> upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerClosedBoundary<TPoint> LowerBoundary { get; }

        public UpperOpenBoundary<TPoint> UpperBoundary { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is ClosedOpenInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            ClosedOpenInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}