namespace Interval.Intervals.OpenInterval
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Optional;

    public class OpenIntervalFactory
    {
        public static Option<OpenInterval<TPoint, TPointComparer>> Build<TPoint, TPointComparer>(
            LowerOpenBoundary<TPoint> lowerBoundary,
            UpperOpenBoundary<TPoint> upperBoundary,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>
        {
            if (pointComparer.Compare(lowerBoundary.Point, upperBoundary.Point) >= 0)
            {
                return Option.None<OpenInterval<TPoint, TPointComparer>>();
            }

            return new OpenInterval<TPoint, TPointComparer>(
                    lowerBoundary: lowerBoundary,
                    upperBoundary: upperBoundary)
                .Some();
        }
    }
}