namespace Interval.OneOfIntervals.Operations
{
    using System.Collections.Generic;

    public static class OneOfIntervalsIntersectOperation
    {
        public static OneOfIntervals<TPoint, TPointComparer> Intersect<TPoint, TPointComparer>(
            this OneOfIntervals<TPoint, TPointComparer> leftInterval,
            OneOfIntervals<TPoint, TPointComparer> rightInterval,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return leftInterval.Match(
                leftBoundaryInterval => rightInterval.Match(
                    rightBoundaryInterval => leftBoundaryInterval.Intersect(
                        rightIntervalCase: rightBoundaryInterval,
                        pointComparer: pointComparer),
                    emptyInterval => emptyInterval),
                emptyInterval => emptyInterval);
        }
    }
}