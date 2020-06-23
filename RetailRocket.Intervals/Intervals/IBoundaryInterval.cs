namespace Interval.Intervals
{
    public interface IBoundaryInterval<TPoint, TPointComparer, out TLowerBoundary, out TUpperBoundary>
    {
        public TLowerBoundary LowerBoundary { get; }

        public TUpperBoundary UpperBoundary { get; }
    }
}