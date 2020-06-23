namespace Interval.Intervals
{
    using System.Collections.Generic;

    public class EmptyInterval<TPoint, TPointComparer> :
        IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public bool Contains(
            TPoint point,
            TPointComparer pointComparer)
        {
            return false;
        }
    }
}