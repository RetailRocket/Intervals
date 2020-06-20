namespace Interval.Intervals.Operations.BoundaryIntervals
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Intervals.ClosedInterval;
    using Interval.Intervals.InfinityInterval;
    using Interval.Intervals.OpenInterval;

    public static class GetLowerBoundary
    {
        public static ILowerBoundary<TPoint, TPointComparer> LowerBoundary<TPoint, TPointComparer>(
            this IBoundaryInterval<TPoint, TPointComparer> boundaryInterval)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() => boundaryInterval switch
        {
            ClosedInterval<TPoint, TPointComparer> i => i.LowerBoundary,
            OpenInterval<TPoint, TPointComparer> i => i.LowerBoundary,
            InfinityInterval<TPoint, TPointComparer> i => i.LowerBoundary,
            _ => throw new ArgumentException()
        };
    }
}