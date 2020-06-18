namespace Interval.Intervals.ClosedInfinityInterval.Operations
{
    using System.Collections.Generic;

    public static class ClosedInfinityIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this ClosedInfinityInterval<TPoint, TPointComparer> closedInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedInterval.LowerBoundary.Point, point) >= 0;
        }
    }
}