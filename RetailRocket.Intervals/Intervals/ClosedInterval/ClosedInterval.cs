namespace Interval.Intervals.ClosedInterval
{
    using System;
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct ClosedInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
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

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.LowerBoundary.Point, point) >= 0 &&
                   pointComparer.Compare(this.UpperBoundary.Point, point) <= 0;
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