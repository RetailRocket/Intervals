namespace Interval.Intervals
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public class BoundaryInterval<TPoint, TPointComparer> :
        IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public BoundaryInterval(
            ILowerBoundary<TPoint, TPointComparer> lowerBoundary,
            IUpperBoundary<TPoint, TPointComparer> upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public ILowerBoundary<TPoint, TPointComparer> LowerBoundary { get; }

        public IUpperBoundary<TPoint, TPointComparer> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return this.LowerBoundary.CompareToPoint(
                       point,
                       pointComparer) <= 0 &&
                   this.UpperBoundary.CompareToPoint(
                       point,
                       pointComparer) >= 0;
        }

        public bool IsBoundaryPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return this.LowerBoundary.IsBoundaryPoint(point, pointComparer) ||
                   this.UpperBoundary.IsBoundaryPoint(point, pointComparer);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is BoundaryInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(
                this.LowerBoundary.GetHashCode(),
                this.UpperBoundary.GetHashCode());
        }

        public bool Equals(
            BoundaryInterval<TPoint, TPointComparer> boundaryInterval)
        {
            return this.LowerBoundary.Equals(boundaryInterval.LowerBoundary) &&
                   this.UpperBoundary.Equals(boundaryInterval.UpperBoundary);
        }
    }
}