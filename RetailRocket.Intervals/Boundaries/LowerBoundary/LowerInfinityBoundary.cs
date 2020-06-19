namespace Interval.Boundaries.LowerBoundary
{
    public readonly struct LowerInfinityBoundary<TPoint> :
        ILowerBoundary<TPoint>
        where TPoint : notnull
    {
        public override bool Equals(
            object? obj)
        {
            return obj is LowerInfinityBoundary<TPoint>;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }
    }
}