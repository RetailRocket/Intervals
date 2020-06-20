namespace Interval.Boundaries.UpperBoundary
{
    using System.Collections.Generic;

    public readonly struct UpperInfinityBoundary<TPoint, TPointComparer> :
        IUpperPointedBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return 1;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is UpperInfinityBoundary<TPoint, TPointComparer>;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }
    }
}