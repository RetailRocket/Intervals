namespace Interval.Intervals.ClosedOpenInterval
{
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;
    using Optional;

    public class ClosedOpenIntervalFactory
    {
        public static Option<ClosedOpenInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerClosedBoundary<TPoint, TPointComparer> lowerBoundary,
            UpperOpenBoundary<TPoint, TPointComparer> upperBoundary,
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