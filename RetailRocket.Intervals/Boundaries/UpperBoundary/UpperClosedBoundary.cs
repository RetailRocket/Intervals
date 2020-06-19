namespace Interval.Boundaries.UpperBoundary
{
    public readonly struct UpperClosedBoundary<TPoint> :
        IUpperPointedBoundary<TPoint>
        where TPoint : notnull
    {
        public UpperClosedBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is UpperClosedBoundary<TPoint> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            UpperClosedBoundary<TPoint> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}