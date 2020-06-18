namespace Interval.OneOfBoundaries.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.OneOfBoundaries;

    public static class OneOfLowerBoundariesCompareOperation
    {
        public static int Compare<TPoint, TPointComparer>(
            this OneOfLowerBoundaries<TPoint> leftOneOfLowerBoundaries,
            OneOfLowerBoundaries<TPoint> rightOneOfLowerBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            return leftOneOfLowerBoundaries.Match(
                lowerInfinityBoundary => CompareInfinityBoundaryTo(rightOneOfLowerBoundaries),
                lowerClosedBoundary => CompareClosedBoundaryTo(lowerClosedBoundary, rightOneOfLowerBoundaries, pointComparer),
                lowerOpenBoundary => CompareOpenBoundaryTo(lowerOpenBoundary, rightOneOfLowerBoundaries, pointComparer));
        }

        private static int CompareOpenBoundaryTo<TPoint>(
            LowerOpenBoundary<TPoint> leftLowerOpenBoundary,
            OneOfLowerBoundaries<TPoint> rightOneOfLowerBoundaries,
            IComparer<TPoint> pointComparer)
            where TPoint : notnull
        {
            return rightOneOfLowerBoundaries.Match(
                infinityBoundary => -1,
                rightClosedBoundary => CompareOpenToClosed(
                    leftLowerOpenBoundary,
                    rightClosedBoundary,
                    pointComparer),
                rightOpenBoundary => pointComparer
                    .Compare(
                        leftLowerOpenBoundary.Point,
                        rightOpenBoundary.Point));
        }

        private static int CompareOpenToClosed<TPoint>(
            LowerOpenBoundary<TPoint> leftLowerOpenBoundary,
            LowerClosedBoundary<TPoint> rightClosedBoundary,
            IComparer<TPoint> pointComparer)
            where TPoint : notnull
        {
            var comparison = pointComparer.Compare(leftLowerOpenBoundary.Point, rightClosedBoundary.Point);
            return comparison == 0 ? 1 : comparison;
        }

        private static int CompareClosedBoundaryTo<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary,
            OneOfLowerBoundaries<TPoint> rightOneOfLowerBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            return rightOneOfLowerBoundaries.Match(
                infinityBoundary => -1,
                rightClosedBoundary => pointComparer
                    .Compare(
                        lowerClosedBoundary.Point,
                        rightClosedBoundary.Point),
                rightOpenBoundary => CompareClosedBoundaryToOpenBoundary(
                    lowerClosedBoundary,
                    rightOpenBoundary,
                    pointComparer));
        }

        private static int CompareClosedBoundaryToOpenBoundary<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerClosedBoundary,
            LowerOpenBoundary<TPoint> rightOpenBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            var comparison = pointComparer.Compare(lowerClosedBoundary.Point, rightOpenBoundary.Point);
            return comparison == 0 ? -1 : comparison;
        }

        private static int CompareInfinityBoundaryTo<TPoint>(
            OneOfLowerBoundaries<TPoint> rightOneOfLowerBoundaries)
            where TPoint : notnull
        {
            return rightOneOfLowerBoundaries.Match(
                infinityBoundary => 1,
                closedBoundary => -1,
                openBoundary => -1);
        }
    }
}