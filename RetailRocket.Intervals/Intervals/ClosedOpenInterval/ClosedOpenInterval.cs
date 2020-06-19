namespace Interval.Intervals.ClosedOpenInterval
{
    using System;
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedOpenInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
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

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.LowerBoundary.Point, point) >= 0 &&
                   pointComparer.Compare(this.UpperBoundary.Point, point) < 0;
        }

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

        public List<TPoint> GetListOfBoundaryPoint()
        {
            return new List<TPoint>
            {
                this.LowerBoundary.Point,
                this.UpperBoundary.Point,
            };
        }
    }
}