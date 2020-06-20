namespace Interval.Boundaries.Operations
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.UpperBoundary;

    public static class UpperBoundaryComparison
    {
        public static int Compare<TPoint, TPointComparer>(
            this IUpperBoundary<TPoint, TPointComparer> lowerBoundary,
            IUpperBoundary<TPoint, TPointComparer> otherUpperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, otherUpperBoundary) switch
            {
                (UpperClosedBoundary<TPoint, TPointComparer> leftClosed, UpperClosedBoundary<TPoint, TPointComparer> rightClosed) => leftClosed.Compare(rightClosed, pointComparer),
                (UpperClosedBoundary<TPoint, TPointComparer> leftClosed, UpperOpenBoundary<TPoint, TPointComparer> rightOpen) => leftClosed.Compare(rightOpen, pointComparer),
                (UpperClosedBoundary<TPoint, TPointComparer> leftClosed, UpperInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftClosed.Compare(rightInfinity, pointComparer),

                (UpperOpenBoundary<TPoint, TPointComparer> leftOpen, UpperOpenBoundary<TPoint, TPointComparer> rightOpen) => leftOpen.Compare(rightOpen, pointComparer),
                (UpperOpenBoundary<TPoint, TPointComparer> leftOpen, UpperClosedBoundary<TPoint, TPointComparer> rightClosed) => leftOpen.Compare(rightClosed, pointComparer),
                (UpperOpenBoundary<TPoint, TPointComparer> leftOpen, UpperInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftOpen.Compare(rightInfinity, pointComparer),

                (UpperInfinityBoundary<TPoint, TPointComparer> leftInfinity, UpperInfinityBoundary<TPoint, TPointComparer> rightInfinity) => leftInfinity.Compare(rightInfinity, pointComparer),
                (UpperInfinityBoundary<TPoint, TPointComparer> leftInfinity, UpperClosedBoundary<TPoint, TPointComparer> rightClosed) => leftInfinity.Compare(rightClosed, pointComparer),
                (UpperInfinityBoundary<TPoint, TPointComparer> leftInfinity, UpperOpenBoundary<TPoint, TPointComparer> rightOpen) => leftInfinity.Compare(rightOpen, pointComparer),

                _ => throw new ArgumentException(),
            };

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint, TPointComparer> leftClosed,
            UpperOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightOpen.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint, TPointComparer> leftClosed,
            UpperClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightClosed.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperClosedBoundary<TPoint, TPointComparer> leftClosed,
            UpperInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint, TPointComparer> leftClosed,
            UpperOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return pointComparer.Compare(leftClosed.Point, rightOpen.Point);
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint, TPointComparer> leftClosed,
            UpperClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            var comparison = pointComparer.Compare(leftClosed.Point, rightClosed.Point);
            return comparison == 0 ? 1 : comparison;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperOpenBoundary<TPoint, TPointComparer> leftClosed,
            UpperInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return -1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint, TPointComparer> leftClosed,
            UpperOpenBoundary<TPoint, TPointComparer> rightOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint, TPointComparer> leftClosed,
            UpperClosedBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 1;
        }

        public static int Compare<TPoint, TPointComparer>(
            this UpperInfinityBoundary<TPoint, TPointComparer> leftClosed,
            UpperInfinityBoundary<TPoint, TPointComparer> rightClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return 0;
        }
    }
}