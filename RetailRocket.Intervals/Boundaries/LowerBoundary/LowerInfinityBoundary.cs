namespace Interval.Boundaries.LowerBoundary
{
    using System.Collections.Generic;

    public readonly struct LowerInfinityBoundary<TPoint, TPointComparer> :
        ILowerBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return -1;
        }

        public bool IsBoundaryPoint(
            TPoint point,
            TPointComparer pointComparer)
        {
            return false;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is LowerInfinityBoundary<TPoint, TPointComparer>;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }
    }
}