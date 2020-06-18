namespace Interval.Intervals.ClosedInterval
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Optional;

    public class ClosedIntervalFactory
    {
        public static Option<ClosedInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerBoundary,
            UpperClosedBoundary<TPoint> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerBoundary.Point, upperBoundary.Point) > 0)
            {
                return Option.None<ClosedInterval<TPoint, TPointComparer>>();
            }

            return new ClosedInterval<TPoint, TPointComparer>(
                    lowerBoundary: lowerBoundary,
                    upperBoundary: upperBoundary)
                .Some();
        }
    }
}