namespace Interval.Intervals.InfinityOpenInterval.Operations
{
    using System.Collections.Generic;

    public static class InfinityOpenIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this InfinityOpenInterval<TPoint, TPointComparer> closedInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedInterval.UpperBoundary.Point, point) < 0;
        }
    }
}