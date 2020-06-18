namespace Interval.Intervals.OpenInterval.Operations
{
    using System.Collections.Generic;

    public static class OpenIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this OpenInterval<TPoint, TPointComparer> closedIntervalT,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(closedIntervalT.LowerBoundary.Point, point) > 0 &&
                   pointComparer.Compare(closedIntervalT.UpperBoundary.Point, point) < 0;
        }
    }
}