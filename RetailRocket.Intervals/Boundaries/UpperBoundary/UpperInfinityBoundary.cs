namespace Interval.Boundaries.UpperBoundary
{
    public readonly struct UpperInfinityBoundary<TPoint> :
        IUpperBoundary<TPoint>
        where TPoint : notnull
    {
        public override bool Equals(
            object? obj)
        {
            return obj is UpperInfinityBoundary<TPoint>;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }
    }
}