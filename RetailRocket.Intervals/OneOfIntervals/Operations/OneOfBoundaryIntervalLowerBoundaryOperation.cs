namespace Interval.OneOfIntervals.Operations
{
    using System.Collections.Generic;
    using Interval.OneOfBoundaries;

    public static class OneOfBoundaryIntervalLowerBoundaryOperation
    {
        public static OneOfLowerBoundaries<TPoint> LowerBoundary<TPoint, TPointComparer>(
            this OneOfBoundaryIntervals<TPoint, TPointComparer> oneOfBoundaryIntervals)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfBoundaryIntervals.Match(
                closedInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        closedInterval.LowerBoundary),
                closedOpenInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        closedOpenInterval.LowerBoundary),
                closedInfinityInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        closedInfinityInterval.LowerBoundary),
                openInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        openInterval.LowerBoundary),
                openClosedInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        openClosedInterval.LowerBoundary),
                openInfinityInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        openInfinityInterval.LowerBoundary),
                infinityInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        infinityInterval.LowerBoundary),
                infinityClosedInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        infinityClosedInterval.LowerBoundary),
                infinityOpenInterval =>
                    new OneOfLowerBoundaries<TPoint>(
                        infinityOpenInterval.LowerBoundary));
        }
    }
}