namespace Interval.OneOfBoundaries
{
    using Interval.Boundaries.LowerBoundary;
    using RetailRocket.OneOf;

    public class OneOfLowerBoundaries<TPoint>
        : OneOf<
            LowerInfinityBoundary<TPoint>,
            LowerClosedBoundary<TPoint>,
            LowerOpenBoundary<TPoint>>
        where TPoint : notnull
    {
        public OneOfLowerBoundaries(
            LowerInfinityBoundary<TPoint> lowerInfinityBoundary)
            : base(lowerInfinityBoundary)
        {
        }

        public OneOfLowerBoundaries(
            LowerClosedBoundary<TPoint> lowerClosedBoundary)
            : base(lowerClosedBoundary)
        {
        }

        public OneOfLowerBoundaries(
            LowerOpenBoundary<TPoint> lowerOpenBoundary)
            : base(lowerOpenBoundary)
        {
        }
    }
}