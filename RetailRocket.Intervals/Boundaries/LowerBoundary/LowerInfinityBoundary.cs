namespace Interval.Boundaries.LowerBoundary
{
    public readonly struct LowerInfinityBoundary<TPoint>
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