namespace Interval.OneOfIntervals.Operations
{
    using System.Collections.Generic;
    using Interval.OneOfBoundaries.Operations;

    public static class OneOfBoundaryIntervalsIntersectOperation
    {
        public static OneOfIntervals<TPoint, TPointComparer> Intersect<TPoint, TPointComparer>(
            this OneOfBoundaryIntervals<TPoint, TPointComparer> leftIntervalCase,
            OneOfBoundaryIntervals<TPoint, TPointComparer> rightIntervalCase,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var biggerLowerBound = leftIntervalCase
                .LowerBoundary()
                .Compare(
                    rightIntervalCase.LowerBoundary(),
                    pointComparer) > 0
                ? rightIntervalCase.LowerBoundary()
                : leftIntervalCase.LowerBoundary();

            var smallerUpperBound = leftIntervalCase
                .UpperBoundary()
                .Compare(
                    rightIntervalCase.UpperBoundary(),
                    pointComparer: pointComparer) > 0
                ? rightIntervalCase.UpperBoundary()
                : leftIntervalCase.UpperBoundary();

            return OneOfIntervalsFactory.Build(
                oneOfLowerBoundaries: biggerLowerBound,
                oneOfUpperBoundaries: smallerUpperBound,
                pointComparer: pointComparer);
        }
    }
}