namespace Interval.Intervals.InfinityClosedInterval.Operations
{
    using System.Collections.Generic;

    public static class InfinityClosedIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this InfinityClosedInterval<TPoint, TPointComparer> closedInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedInterval.UpperBoundary.Point, point) <= 0;
        }
    }
}