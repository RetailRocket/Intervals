namespace Interval.Intervals.OpenInterval
{
    using System;
    using System.Collections.Generic;
    using global::Interval.Boundaries.LowerBoundary;
    using global::Interval.Boundaries.UpperBoundary;

    public readonly struct OpenInterval<TPoint, TPointComparer> :
        IBoundaryInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        internal OpenInterval(
            LowerOpenBoundary<TPoint, TPointComparer> lowerBoundary,
            UpperOpenBoundary<TPoint, TPointComparer> upperBoundary)
        {
            this.LowerBoundary = lowerBoundary;
            this.UpperBoundary = upperBoundary;
        }

        public LowerOpenBoundary<TPoint, TPointComparer> LowerBoundary { get; }

        public UpperOpenBoundary<TPoint, TPointComparer> UpperBoundary { get; }

        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return pointComparer.Compare(this.LowerBoundary.Point, point) > 0 &&
                   pointComparer.Compare(this.UpperBoundary.Point, point) < 0;
        }

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map)
        {
            yield return map(this.LowerBoundary.Point);
            yield return map(this.UpperBoundary.Point);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is OpenInterval<TPoint, TPointComparer> other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.LowerBoundary, this.UpperBoundary);
        }

        public bool Equals(
            OpenInterval<TPoint, TPointComparer> other)
        {
            return this.LowerBoundary.Equals(other.LowerBoundary) && this.UpperBoundary.Equals(other.UpperBoundary);
        }
    }
}