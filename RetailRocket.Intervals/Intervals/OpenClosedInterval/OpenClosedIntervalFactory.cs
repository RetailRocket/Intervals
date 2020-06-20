namespace Interval.Intervals.OpenClosedInterval
{
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;
    using Optional;

    public class OpenClosedIntervalFactory
    {
        public static Option<OpenClosedInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint, TPointComparer> lowerBoundary,
            UpperClosedBoundary<TPoint, TPointComparer> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            if (pointComparer.Compare(lowerBoundary.Point, upperBoundary.Point) > 0)
            {
                return Option.None<OpenClosedInterval<TPoint, TPointComparer>>();
            }

            return new OpenClosedInterval<TPoint, TPointComparer>(
                    lowerBoundary: lowerBoundary,
                    upperBoundary: upperBoundary)
                .Some();
        }
    }
}