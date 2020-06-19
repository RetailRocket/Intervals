namespace Interval.Boundaries.Operations
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.UpperBoundary;

    public static class UpperBoundaryComparison
    {
        public static int Compare<TPoint, TPointComparer>(
            this IUpperBoundary<TPoint> lowerBoundary,
            IUpperBoundary<TPoint> otherUpperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, otherUpperBoundary) switch
            {
                (UpperClosedBoundary<TPoint> leftClosed, UpperClosedBoundary<TPoint> rightClosed) => leftClosed.Compare(rightClosed, pointComparer),
                (UpperClosedBoundary<TPoint> leftClosed, UpperOpenBoundary<TPoint> rightOpen) => leftClosed.Compare(rightOpen, pointComparer),
                (UpperClosedBoundary<TPoint> leftClosed, UpperInfinityBoundary<TPoint> rightInfinity) => leftClosed.Compare(rightInfinity, pointComparer),

                (UpperOpenBoundary<TPoint> leftOpen, UpperOpenBoundary<TPoint> rightOpen) => leftOpen.Compare(rightOpen, pointComparer),
                (UpperOpenBoundary<TPoint> leftOpen, UpperClosedBoundary<TPoint> rightClosed) => leftOpen.Compare(rightClosed, pointComparer),
                (UpperOpenBoundary<TPoint> leftOpen, UpperInfinityBoundary<TPoint> rightInfinity) => leftOpen.Compare(rightInfinity, pointComparer),

                (UpperInfinityBoundary<TPoint> leftInfinity, UpperInfinityBoundary<TPoint> rightInfinity) => leftInfinity.Compare(rightInfinity, pointComparer),
                (UpperInfinityBoundary<TPoint> leftInfinity, UpperClosedBoundary<TPoint> rightClosed) => leftInfinity.Compare(rightClosed, pointComparer),
                (UpperInfinityBoundary<TPoint> leftInfinity, UpperOpenBoundary<TPoint> rightOpen) => leftInfinity.Compare(rightOpen, pointComparer),

                _ => throw new ArgumentException(),
            };

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint> leftClosed,
            UpperOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightOpen.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint> leftClosed,
            UpperClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightClosed.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint> leftClosed,
            UpperInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint> leftClosed,
            UpperOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightOpen.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint> leftClosed,
            UpperClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightClosed.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint> leftClosed,
            UpperInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint> leftClosed,
            UpperOpenBoundary<TPoint> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint> leftClosed,
            UpperClosedBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint> leftClosed,
            UpperInfinityBoundary<TPoint> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 0;
        }
    }
}