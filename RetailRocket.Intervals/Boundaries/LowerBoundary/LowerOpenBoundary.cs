namespace Interval.Boundaries.LowerBoundary
{
    public readonly struct LowerOpenBoundary<TPoint> :
        ILowerPointedBoundary<TPoint>
        where TPoint : notnull
    {
        public LowerOpenBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is LowerOpenBoundary<TPoint> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            LowerOpenBoundary<TPoint> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}