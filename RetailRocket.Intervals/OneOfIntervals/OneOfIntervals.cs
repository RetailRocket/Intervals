namespace Interval.OneOfIntervals
{
    using System.Collections.Generic;
    using Interval.Intervals.EmptyInterval;
    using RetailRocket.OneOf;

    public class OneOfIntervals<TPoint, TPointComparer>
        : OneOf<
            OneOfBoundaryIntervals<TPoint, TPointComparer>,
            EmptyInterval<TPoint, TPointComparer>>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public OneOfIntervals(
            OneOfBoundaryIntervals<TPoint, TPointComparer> oneOfOfBoundaryIntervals)
            : base(oneOfOfBoundaryIntervals)
        {
        }

        public OneOfIntervals(
            EmptyInterval<TPoint, TPointComparer> emptyInterval)
            : base(emptyInterval)
        {
        }

        public static implicit operator OneOfIntervals<TPoint, TPointComparer>(OneOfBoundaryIntervals<TPoint, TPointComparer> t)
            => new OneOfIntervals<TPoint, TPointComparer>(t);

        public static implicit operator OneOfIntervals<TPoint, TPointComparer>(EmptyInterval<TPoint, TPointComparer> t)
            => new OneOfIntervals<TPoint, TPointComparer>(t);
    }
}