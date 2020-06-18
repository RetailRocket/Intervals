namespace Interval.Boundaries.UpperBoundary
{
    public readonly struct UpperOpenBoundary<TPoint>
        where TPoint : notnull
        {
        public UpperOpenBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is UpperOpenBoundary<TPoint> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            UpperOpenBoundary<TPoint> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}