namespace Interval.Intervals
{
    using System.Collections.Generic;

    public interface IBoundaryInterval<TPoint, TPointComparer> :
        IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
    }
}