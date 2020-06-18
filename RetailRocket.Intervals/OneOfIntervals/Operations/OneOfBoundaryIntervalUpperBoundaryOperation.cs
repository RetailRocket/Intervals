namespace Interval.OneOfIntervals.Operations
{
    using System.Collections.Generic;
    using Interval.OneOfBoundaries;

    public static class OneOfBoundaryIntervalUpperBoundaryOperation
    {
        public static OneOfUpperBoundaries<TPoint> UpperBoundary<TPoint, TPointComparer>(
            this OneOfBoundaryIntervals<TPoint, TPointComparer> oneOfBoundaryIntervals)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfBoundaryIntervals.Match(
                closedInterval => new OneOfUpperBoundaries<TPoint>(
                    closedInterval.UpperBoundary),
                closedOpenInterval => new OneOfUpperBoundaries<TPoint>(
                    closedOpenInterval.UpperBoundary),
                closedInfinityInterval => new OneOfUpperBoundaries<TPoint>(
                    closedInfinityInterval.UpperBoundary),
                openInterval => new OneOfUpperBoundaries<TPoint>(
                    openInterval.UpperBoundary),
                openClosedInterval => new OneOfUpperBoundaries<TPoint>(
                    openClosedInterval.UpperBoundary),
                openInfinityInterval => new OneOfUpperBoundaries<TPoint>(
                    openInfinityInterval.UpperBoundary),
                infinityInterval => new OneOfUpperBoundaries<TPoint>(
                    infinityInterval.UpperBoundary),
                infinityOpenInterval => new OneOfUpperBoundaries<TPoint>(
                    infinityOpenInterval.UpperBoundary),
                closedInfinityInterval => new OneOfUpperBoundaries<TPoint>(
                    closedInfinityInterval.UpperBoundary));
        }
    }
}