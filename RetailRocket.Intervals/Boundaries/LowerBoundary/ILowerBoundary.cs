namespace Interval.Boundaries.LowerBoundary
{
    using System.Collections.Generic;

    public interface ILowerBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer);
    }
}