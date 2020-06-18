namespace Interval.Intervals.ClosedOpenInterval.Operations
{
    using System.Collections.Generic;

    public static class ClosedOpenIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this ClosedOpenInterval<TPoint, TPointComparer> closedInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedInterval.LowerBoundary.Point, point) >= 0 &&
                   pointComparer.Compare(closedInterval.UpperBoundary.Point, point) < 0;
        }
    }
}