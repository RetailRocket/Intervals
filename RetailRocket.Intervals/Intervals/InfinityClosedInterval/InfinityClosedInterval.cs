namespace Interval.Intervals.InfinityClosedInterval
{
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;

    public readonly struct InfinityClosedInterval<TPoint, TPointComparer>
        where TPoint : notnull
    {
        public InfinityClosedInterval(
            UpperClosedBoundary<TPoint> upperBoundary)
        {
            LowerInfinityBoundary<TPoint> lowerInfinityBoundary;
            this.LowerBoundary = lowerInfinityBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerInfinityBoundary<TPoint> LowerBoundary { get; }

        public UpperClosedBoundary<TPoint> UpperBoundary { get; }
    }
}