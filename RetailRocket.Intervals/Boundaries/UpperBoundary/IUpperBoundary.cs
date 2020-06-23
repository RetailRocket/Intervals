namespace Interval.Boundaries.UpperBoundary
{
    using System.Collections.Generic;

    public interface IUpperBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        int CompareToPoint(
            TPoint point,
            TPointComparer pointComparer);

        bool IsBoundaryPoint(
            TPoint point,
            TPointComparer pointComparer);
    }
}