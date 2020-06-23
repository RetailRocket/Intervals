namespace Interval.Intervals
{
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.Operations;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.Factories;

    public class BoundaryInterval<TPoint, TPointComparer, TLowerBoundary, TUpperBoundary> :
        IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
        where TLowerBoundary : ILowerBoundary<TPoint, TPointComparer>
        where TUpperBoundary : IUpperBoundary<TPoint, TPointComparer>
    {
        public BoundaryInterval(
            TLowerBoundary lowerBoundary,
            TUpperBoundary upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public TLowerBoundary LowerBoundary { get; }

        public TUpperBoundary UpperBoundary { get; }

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
    }
}