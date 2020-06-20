namespace Interval.Intervals
{
    using System;
    using System.Collections.Generic;

    public interface IInterval<TPoint, TPointComparer>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public bool Contains(
            TPoint point,
            TPointComparer pointComparer);

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map);
    }
}