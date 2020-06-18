namespace Interval.Intervals.OpenClosedInterval
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Optional;

    public class OpenClosedIntervalFactory
    {
        public static Option<OpenClosedInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerBoundary,
            UpperClosedBoundary<TPoint> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
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