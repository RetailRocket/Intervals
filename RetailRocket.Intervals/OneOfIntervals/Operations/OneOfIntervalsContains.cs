namespace Interval.OneOfIntervals.Operations
{
    using System.Collections.Generic;
    using Interval.Intervals.ClosedInfinityInterval.Operations;
    using Interval.Intervals.ClosedInterval.Operations;
    using Interval.Intervals.ClosedOpenInterval.Operations;
    using Interval.Intervals.EmptyInterval.Operations;
    using Interval.Intervals.InfinityClosedInterval.Operations;
    using Interval.Intervals.InfinityInterval.Operations;
    using Interval.Intervals.InfinityOpenInterval.Operations;
    using Interval.Intervals.OpenClosedInterval.Operations;
    using Interval.Intervals.OpenInfinityInterval.Operations;
    using Interval.Intervals.OpenInterval.Operations;

    public static class OneOfIntervalsContains
    {
        public static bool Contains<TPoint, TPointComparer>(
            this OneOfIntervals<TPoint, TPointComparer> oneOfIntervals,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return oneOfIntervals
                .Match(
                    oneOfBoundaryInterval => oneOfBoundaryInterval.Match(
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(),
                        i => i.Contains(point, pointComparer),
                        i => i.Contains(point, pointComparer)),
                    emptyInterval => emptyInterval.Contains());
        }
    }
}