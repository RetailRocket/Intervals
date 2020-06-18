namespace Interval.Intervals.ClosedOpenInterval
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Optional;

    public class ClosedOpenIntervalFactory
    {
        public static Option<ClosedOpenInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint> lowerBoundary,
            UpperOpenBoundary<TPoint> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerBoundary.Point, upperBoundary.Point) >= 0)
            {
                return Option.None<ClosedOpenInterval<TPoint, TPointComparer>>();
            }

            return new ClosedOpenInterval<TPoint, TPointComparer>(
                    lowerBoundary: lowerBoundary,
                    upperBoundary: upperBoundary)
                .Some();
        }
    }
}