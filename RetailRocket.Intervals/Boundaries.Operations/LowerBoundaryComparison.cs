namespace Interval.Boundaries.Operations
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;

    public static class LowerBoundaryComparison
    {
        public static int Compare<TPoint, TPointComparer>(
            this ILowerBoundary<TPoint> lowerBoundary,
            ILowerBoundary<TPoint> otherLowerBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, otherLowerBoundary) switch
            {
                (LowerClosedBoundary<TPoint> leftClosed, LowerClosedBoundary<TPoint> rightClosed) => leftClosed.Compare(rightClosed, pointComparer),
                (LowerClosedBoundary<TPoint> leftClosed, LowerOpenBoundary<TPoint> rightOpen) => leftClosed.Compare(rightOpen, pointComparer),
                (LowerClosedBoundary<TPoint> leftClosed, LowerInfinityBoundary<TPoint> rightInfinity) => leftClosed.Compare(rightInfinity, pointComparer),

                (LowerOpenBoundary<TPoint> leftOpen, LowerOpenBoundary<TPoint> rightOpen) => leftOpen.Compare(rightOpen, pointComparer),
                (LowerOpenBoundary<TPoint> leftOpen, LowerClosedBoundary<TPoint> rightClosed) => leftOpen.Compare(rightClosed, pointComparer),
                (LowerOpenBoundary<TPoint> leftOpen, LowerInfinityBoundary<TPoint> rightInfinity) => leftOpen.Compare(rightInfinity, pointComparer),

                (LowerInfinityBoundary<TPoint> leftInfinity, LowerInfinityBoundary<TPoint> rightInfinity) => leftInfinity.Compare(rightInfinity, pointComparer),
                (LowerInfinityBoundary<TPoint> leftInfinity, LowerClosedBoundary<TPoint> rightClosed) => leftInfinity.Compare(rightClosed, pointComparer),
                (LowerInfinityBoundary<TPoint> leftInfinity, LowerOpenBoundary<TPoint> rightOpen) => leftInfinity.Compare(rightOpen, pointComparer),

                _ => throw new ArgumentException(),
            };

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint> leftClosed,
            LowerOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightOpen.Point);
            return comparison == 0 ? -1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint> leftClosed,
            LowerClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightClosed.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint> leftClosed,
            LowerInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint> leftClosed,
            LowerOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightOpen.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint> leftClosed,
            LowerClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightClosed.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint> leftClosed,
            LowerInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint> leftClosed,
            LowerOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint> leftClosed,
            LowerClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint> leftClosed,
            LowerInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 0;
        }
    }
}