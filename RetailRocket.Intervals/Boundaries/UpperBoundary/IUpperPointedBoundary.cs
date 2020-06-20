namespace Interval.Boundaries.UpperBoundary
{
    using System.Collections.Generic;

    public interface IUpperPointedBoundary<TPoint, TPointComparer> :
        IUpperBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
    }
}