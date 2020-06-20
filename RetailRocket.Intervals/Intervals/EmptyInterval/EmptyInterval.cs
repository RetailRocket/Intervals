namespace Interval.Intervals.EmptyInterval
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public override bool Equals(
            object? obj)
        {
            return obj is EmptyInterval<TPoint, TPointComparer>;
        }

        public override int GetHashCode()
        {
            return this.GetType()
                .GetHashCode();
        }

        public List<TPoint> GetListOfBoundaryPoint()
        {
            return new List<TPoint> { };
        }

        public IEnumerable<TResult> MapBoundaryPoints<TResult>(
            Func<TPoint, TResult> map)
        {
            return Enumerable.Empty<TResult>();
        }
    }
}