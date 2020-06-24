namespace Interval.Boundaries.LowerBoundary
{
    using System.Collections.Generic;

    public class LowerOpenBoundary<TPoint, TPointComparer> :
        ILowerPointedBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public LowerOpenBoundary(
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
            return comparison == 0 ? 1 : comparison;
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
            return obj is LowerOpenBoundary<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Point
                .GetHashCode();
        }

        public bool Equals(
            LowerOpenBoundary<TPoint, TPointComparer> other)
        {
            return this.Point
                .Equals(other.Point);
        }
    }
}