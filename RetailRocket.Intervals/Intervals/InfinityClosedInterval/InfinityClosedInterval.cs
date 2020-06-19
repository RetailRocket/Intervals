namespace Interval.Intervals.InfinityClosedInterval
{
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityClosedInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public InfinityClosedInterval(
            UpperClosedBoundary<TPoint> upperBoundary)
        {
            LowerInfinityBoundary<TPoint> lowerInfinityBoundary;
            this.LowerBoundary = lowerInfinityBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerInfinityBoundary<TPoint> LowerBoundary { get; }

        public UpperClosedBoundary<TPoint> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.UpperBoundary.Point, point) <= 0;
        }

        public List<TPoint> GetListOfBoundaryPoint()
        {
            return new List<TPoint>
            {
                this.UpperBoundary.Point,
            };
        }
    }
}