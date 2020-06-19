namespace Interval.Intervals
{
    using System.Collections.Generic;

    public interface IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public bool Contains(
            TPoint point,
            TPointComparer pointComparer);

        public List<TPoint> GetListOfBoundaryPoint();
    }
}