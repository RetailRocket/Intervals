namespace Interval.Boundaries.UpperBoundary
{
    using System.Collections.Generic;

    public readonly struct UpperOpenBoundary<TPoint, TPointComparer> :
        IUpperPointedBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
        {
        public UpperOpenBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            var comparison = pointComparer.Compare(this.Point, point);
            return comparison == 0 ? -1 : comparison;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is UpperOpenBoundary<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            UpperOpenBoundary<TPoint, TPointComparer> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}