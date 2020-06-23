namespace Interval.Intervals.Factories
{
    using System;
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public static class IntervalFactory
    {
        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            ILowerBoundary<TPoint, TPointComparer> lowerBoundary,
            IUpperBoundary<TPoint, TPointComparer> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new() =>
            (lowerBoundary, upperBoundary) switch
            {
                (LowerClosedBoundary<TPoint, TPointComparer> lc, UpperClosedBoundary<TPoint, TPointComparer> uc) => Build(lc, uc, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> lc, UpperOpenBoundary<TPoint, TPointComparer> uo) => Build(lc, uo, pointComparer),
                (LowerClosedBoundary<TPoint, TPointComparer> lc, UpperInfinityBoundary<TPoint, TPointComparer> ui) => Build(lc, ui),

                (LowerOpenBoundary<TPoint, TPointComparer> lo, UpperClosedBoundary<TPoint, TPointComparer> uc) => Build(lo, uc, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> lo, UpperOpenBoundary<TPoint, TPointComparer> uo) => Build(lo, uo, pointComparer),
                (LowerOpenBoundary<TPoint, TPointComparer> lo, UpperInfinityBoundary<TPoint, TPointComparer> ui) => Build(lo, ui),

                (LowerInfinityBoundary<TPoint, TPointComparer> li, UpperClosedBoundary<TPoint, TPointComparer> uc) => Build(li, uc),
                (LowerInfinityBoundary<TPoint, TPointComparer> li, UpperOpenBoundary<TPoint, TPointComparer> uo) => Build(li, uo),
                (LowerInfinityBoundary<TPoint, TPointComparer> li, UpperInfinityBoundary<TPoint, TPointComparer> ui) => Build(li, ui),
                _ => throw new ArgumentException()
            };

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerInfinityBoundary<TPoint, TPointComparer> lowerOpenBoundary,
            UpperInfinityBoundary<TPoint, TPointComparer> upperInfinityBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerInfinityBoundary<TPoint, TPointComparer>,
                UpperInfinityBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpenBoundary,
                upperBoundary: upperInfinityBoundary);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerInfinityBoundary<TPoint, TPointComparer> lowerOpenBoundary,
            UpperOpenBoundary<TPoint, TPointComparer> upperInfinityBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerInfinityBoundary<TPoint, TPointComparer>,
                UpperOpenBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpenBoundary,
                upperBoundary: upperInfinityBoundary);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerInfinityBoundary<TPoint, TPointComparer> lowerOpenBoundary,
            UpperClosedBoundary<TPoint, TPointComparer> upperInfinityBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerInfinityBoundary<TPoint, TPointComparer>,
                UpperClosedBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpenBoundary,
                upperBoundary: upperInfinityBoundary);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint, TPointComparer> lowerOpenBoundary,
            UpperInfinityBoundary<TPoint, TPointComparer> upperInfinityBoundary)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerOpenBoundary<TPoint, TPointComparer>,
                UpperInfinityBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpenBoundary,
                upperBoundary: upperInfinityBoundary);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint, TPointComparer> lowerClosed,
            UpperInfinityBoundary<TPoint, TPointComparer> upperInfinity)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerClosedBoundary<TPoint, TPointComparer>,
                UpperInfinityBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerClosed,
                upperBoundary: upperInfinity);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint, TPointComparer> lowerClosed,
            UpperClosedBoundary<TPoint, TPointComparer> upperClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerClosed.Point, upperClosed.Point) > 0)
            {
                return new EmptyInterval<TPoint, TPointComparer>();
            }

            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerClosedBoundary<TPoint, TPointComparer>,
                UpperClosedBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerClosed,
                upperBoundary: upperClosed);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint, TPointComparer> lowerClosed,
            UpperOpenBoundary<TPoint, TPointComparer> upperOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerClosed.Point, upperOpen.Point) >= 0)
            {
                return new EmptyInterval<TPoint, TPointComparer>();
            }

            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerClosedBoundary<TPoint, TPointComparer>,
                UpperOpenBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerClosed,
                upperBoundary: upperOpen);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint, TPointComparer> lowerOpen,
            UpperOpenBoundary<TPoint, TPointComparer> upperOpen,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerOpen.Point, upperOpen.Point) >= 0)
            {
                return new EmptyInterval<TPoint, TPointComparer>();
            }

            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerOpenBoundary<TPoint, TPointComparer>,
                UpperOpenBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpen,
                upperBoundary: upperOpen);
        }

        public static IInterval<TPoint, TPointComparer> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint, TPointComparer> lowerOpen,
            UpperClosedBoundary<TPoint, TPointComparer> upperClosed,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerOpen.Point, upperClosed.Point) >= 0)
            {
                return new EmptyInterval<TPoint, TPointComparer>();
            }

            return new BoundaryInterval<
                TPoint,
                TPointComparer,
                LowerOpenBoundary<TPoint, TPointComparer>,
                UpperClosedBoundary<TPoint, TPointComparer>>(
                lowerBoundary: lowerOpen,
                upperBoundary: upperClosed);
        }
    }
}