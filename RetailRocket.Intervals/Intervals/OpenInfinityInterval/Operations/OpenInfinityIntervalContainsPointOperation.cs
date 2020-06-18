namespace Interval.Intervals.OpenInfinityInterval.Operations
{
    using System.Collections.Generic;

    public static class OpenInfinityIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this OpenInfinityInterval<TPoint, TPointComparer> closedInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedInterval.LowerBoundary.Point, point) > 0;
        }
    }
}