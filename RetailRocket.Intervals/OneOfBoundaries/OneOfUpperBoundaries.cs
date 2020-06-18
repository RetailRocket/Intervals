namespace Interval.OneOfBoundaries
{
    using Interval.Boundaries.UpperBoundary;
    using RetailRocket.OneOf;

    public class OneOfUpperBoundaries<TPoint>
        : OneOf<
            UpperInfinityBoundary<TPoint>,
            UpperClosedBoundary<TPoint>,
            UpperOpenBoundary<TPoint>>
        where TPoint : notnull
    {
        public OneOfUpperBoundaries(
            UpperInfinityBoundary<TPoint> lowerInfinityBoundary)
            : base(lowerInfinityBoundary)
        {
        }

        public OneOfUpperBoundaries(
            UpperClosedBoundary<TPoint> lowerClosedBoundary)
            : base(lowerClosedBoundary)
        {
        }

        public OneOfUpperBoundaries(
            UpperOpenBoundary<TPoint> upperOpenBoundary)
            : base(upperOpenBoundary)
        {
        }
    }
}