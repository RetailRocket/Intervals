namespace Interval.Intervals.Operations.BoundaryIntervals
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals.ClosedInterval;
    using Interval.Intervals.InfinityInterval;
    using Interval.Intervals.OpenInterval;

    public static class GetUpperBoundary
    {
        public static IUpperBoundary<TPoint> UpperBoundary<TPoint, TPointComparer>(
            this IBoundaryInterval<TPoint, TPointComparer> boundaryInterval)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() => boundaryInterval switch
        {
            ClosedInterval<TPoint, TPointComparer> i => i.UpperBoundary,
            OpenInterval<TPoint, TPointComparer> i => i.UpperBoundary,
            InfinityInterval<TPoint, TPointComparer> i => i.UpperBoundary,
            _ => throw new ArgumentException()
        };
    }
}