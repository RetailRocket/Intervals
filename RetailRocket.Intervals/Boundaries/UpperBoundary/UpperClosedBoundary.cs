namespace Interval.Boundaries.UpperBoundary
{
    using System.Collections.Generic;

    public class UpperClosedBoundary<TPoint, TPointComparer> :
        IUpperPointedBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public UpperClosedBoundary(
            TPoint point)
        {
            this.Point = point;
        }

        public TPoint Point { get; }

        public int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.Point, point);
        }

        public bool IsBoundaryPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.Point, point) == 0;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is UpperClosedBoundary<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            UpperClosedBoundary<TPoint, TPointComparer> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}