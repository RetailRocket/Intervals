namespace Interval.Boundaries.LowerBoundary
{
    using System.Collections.Generic;

    public interface ILowerPointedBoundary<TPoint, TPointComparer> :
        ILowerBoundary<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
    }
}