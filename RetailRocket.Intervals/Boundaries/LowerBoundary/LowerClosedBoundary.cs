namespace Interval.Boundaries.LowerBoundary
{
    using System.Collections.Generic;

    public readonly struct LowerClosedBoundary<TPoint>
        where TPoint : notnull
    {
        public LowerClosedBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public override bool Equals(
            object? obj)
        {
            return obj is LowerClosedBoundary<TPoint> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            LowerClosedBoundary<TPoint> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}