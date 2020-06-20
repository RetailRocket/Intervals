namespace Interval.Boundaries.Operations
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;

    public static class LowerBoundaryComparison
    {
        public static int Compare<TPoint, TPointComparer>(
            this ILowerBoundary<TPoint, TPointComparer> lowerBoundary,
            ILowerBoundary<TPoint, TPointComparer> otherLowerBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, otherLowerBoundary) switch
            {
                (LowerClosedBoundary<TPoint, TPointComparer> leftClosed, LowerClosedBoundary<TPoint, TPointComparer> rightClosed) => leftClosed.Compare(rightClosed, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> leftClosed, LowerOpenBoundary<TPoint, TPointComparer> rightOpen) => leftClosed.Compare(rightOpen, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> leftClosed, LowerInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftClosed.Compare(rightInfinity, pointComparer),

                (LowerOpenBoundary<TPoint, TPointComparer> leftOpen, LowerOpenBoundary<TPoint, TPointComparer> rightOpen) => leftOpen.Compare(rightOpen, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> leftOpen, LowerClosedBoundary<TPoint, TPointComparer> rightClosed) => leftOpen.Compare(rightClosed, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> leftOpen, LowerInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftOpen.Compare(rightInfinity, pointComparer),

                (LowerInfinityBoundary<TPoint, TPointComparer> leftInfinity, LowerInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftInfinity.Compare(rightInfinity, pointComparer),
                (LowerInfinityBoundary<TPoint, TPointComparer> leftInfinity, LowerClosedBoundary<TPoint, TPointComparer> rightClosed) => leftInfinity.Compare(rightClosed, pointComparer),
                (LowerInfinityBoundary<TPoint, TPointComparer> leftInfinity, LowerOpenBoundary<TPoint, TPointComparer> rightOpen) => leftInfinity.Compare(rightOpen, pointComparer),

                _ => throw new ArgumentException(),
            };

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint, TPointComparer> leftClosed,
            LowerOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightOpen.Point);
            return comparison == 0 ? -1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint, TPointComparer> leftClosed,
            LowerClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightClosed.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerClosedBoundary<TPoint, TPointComparer> leftClosed,
            LowerInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint, TPointComparer> leftClosed,
            LowerOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightOpen.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint, TPointComparer> leftClosed,
            LowerClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightClosed.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerOpenBoundary<TPoint, TPointComparer> leftClosed,
            LowerInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint, TPointComparer> leftClosed,
            LowerOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint, TPointComparer> leftClosed,
            LowerClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this LowerInfinityBoundary<TPoint, TPointComparer> leftClosed,
            LowerInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 0;
        }
    }
}