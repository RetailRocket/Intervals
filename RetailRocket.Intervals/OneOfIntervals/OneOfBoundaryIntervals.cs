namespace Interval.OneOfIntervals
{
    using System.Collections.Generic;
    using Interval.Intervals.ClosedInfinityInterval;
    using Interval.Intervals.ClosedInterval;
    using Interval.Intervals.ClosedOpenInterval;
    using Interval.Intervals.InfinityClosedInterval;
    using Interval.Intervals.InfinityInterval;
    using Interval.Intervals.InfinityOpenInterval;
    using Interval.Intervals.OpenClosedInterval;
    using Interval.Intervals.OpenInfinityInterval;
    using Interval.Intervals.OpenInterval;
    using RetailRocket.OneOf;

    public class OneOfBoundaryIntervals<TPoint, TPointComparer>
        : OneOf<
            ClosedInterval<TPoint, TPointComparer>,
            ClosedOpenInterval<TPoint, TPointComparer>,
            ClosedInfinityInterval<TPoint, TPointComparer>,
            OpenInterval<TPoint, TPointComparer>,
            OpenClosedInterval<TPoint, TPointComparer>,
            OpenInfinityInterval<TPoint, TPointComparer>,
            InfinityInterval<TPoint, TPointComparer>,
            InfinityOpenInterval<TPoint, TPointComparer>,
            InfinityClosedInterval<TPoint, TPointComparer>>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public OneOfBoundaryIntervals(
            ClosedInterval<TPoint, TPointComparer> closedInterval)
            : base(closedInterval)
        {
        }

        public OneOfBoundaryIntervals(
            ClosedOpenInterval<TPoint, TPointComparer> closedOpenInterval)
            : base(closedOpenInterval)
        {
        }

        public OneOfBoundaryIntervals(
            ClosedInfinityInterval<TPoint, TPointComparer> closedInfinityInterval)
            : base(closedInfinityInterval)
        {
        }

        public OneOfBoundaryIntervals(
            OpenInterval<TPoint, TPointComparer> openInterval)
            : base(openInterval)
        {
        }

        public OneOfBoundaryIntervals(
            OpenClosedInterval<TPoint, TPointComparer> openClosedInterval)
            : base(openClosedInterval)
        {
        }

        public OneOfBoundaryIntervals(
            OpenInfinityInterval<TPoint, TPointComparer> openInfinityInterval)
            : base(openInfinityInterval)
        {
        }

        public OneOfBoundaryIntervals(
            InfinityInterval<TPoint, TPointComparer> infinityInterval)
            : base(infinityInterval)
        {
        }

        public OneOfBoundaryIntervals(
            InfinityOpenInterval<TPoint, TPointComparer> infinityOpenInterval)
            : base(infinityOpenInterval)
        {
        }

        public OneOfBoundaryIntervals(
            InfinityClosedInterval<TPoint, TPointComparer> infinityClosedInterval)
            : base(infinityClosedInterval)
        {
        }
    }
}