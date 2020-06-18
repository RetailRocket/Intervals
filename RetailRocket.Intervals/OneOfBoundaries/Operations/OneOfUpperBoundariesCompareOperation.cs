namespace Interval.OneOfBoundaries.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.UpperBoundary;
    using Interval.OneOfBoundaries;

    public static class OneOfUpperBoundariesCompareOperation
    {
        public static int Compare<TPoint, TPointComparer>(
            this OneOfUpperBoundaries<TPoint> leftOneOfUpperBoundaries,
            OneOfUpperBoundaries<TPoint> rightOneOfUpperBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            return leftOneOfUpperBoundaries.Match(
                lowerInfinityBoundary => CompareInfinityBoundaryTo(rightOneOfUpperBoundaries),
                lowerClosedBoundary => CompareClosedBoundaryTo(lowerClosedBoundary, rightOneOfUpperBoundaries, pointComparer),
                lowerOpenBoundary => CompareOpenBoundaryTo(lowerOpenBoundary, rightOneOfUpperBoundaries, pointComparer));
        }

        private static int CompareOpenBoundaryTo<TPoint>(
            UpperOpenBoundary<TPoint> leftUpperOpenBoundary,
            OneOfUpperBoundaries<TPoint> rightOneOfUpperBoundaries,
            IComparer<TPoint> pointComparer)
            where TPoint : notnull
        {
            return rightOneOfUpperBoundaries.Match(
                infinityBoundary => -1,
                rightClosedBoundary => CompareOpenToClosed(
                    leftUpperOpenBoundary,
                    rightClosedBoundary,
                    pointComparer),
                rightOpenBoundary => pointComparer
                    .Compare(
                        leftUpperOpenBoundary.Point,
                        rightOpenBoundary.Point));
        }

        private static int CompareOpenToClosed<TPoint>(
            UpperOpenBoundary<TPoint> leftUpperOpenBoundary,
            UpperClosedBoundary<TPoint> rightClosedBoundary,
            IComparer<TPoint> pointComparer)
            where TPoint : notnull
        {
            var comparison = pointComparer.Compare(leftUpperOpenBoundary.Point, rightClosedBoundary.Point);
            return comparison == 0 ? -1 : comparison;
        }

        private static int CompareClosedBoundaryTo<TPoint, TPointComparer>(
            UpperClosedBoundary<TPoint> lowerClosedBoundary,
            OneOfUpperBoundaries<TPoint> rightOneOfUpperBoundaries,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            return rightOneOfUpperBoundaries.Match(
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
            UpperClosedBoundary<TPoint> lowerClosedBoundary,
            UpperOpenBoundary<TPoint> rightOpenBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            var comparison = pointComparer.Compare(lowerClosedBoundary.Point, rightOpenBoundary.Point);
            return comparison == 0 ? 1 : comparison;
        }

        private static int CompareInfinityBoundaryTo<TPoint>(
            OneOfUpperBoundaries<TPoint> rightOneOfUpperBoundaries)
            where TPoint : notnull
        {
            return rightOneOfUpperBoundaries.Match(
                infinityBoundary => 0,
                closedBoundary => -1,
                openBoundary => -1);
        }
    }
}