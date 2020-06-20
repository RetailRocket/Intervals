namespace Interval.Boundaries.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.UpperBoundary;

    public class UpperBoundaryComparer<TPoint, TPointComparer> :
        IComparer<IUpperBoundary<TPoint, TPointComparer>>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        private readonly TPointComparer pointComparer;

        public UpperBoundaryComparer(
            TPointComparer pointComparer)
        {
            this.pointComparer = pointComparer;
        }

        public int Compare(
            IUpperBoundary<TPoint, TPointComparer> x,
            IUpperBoundary<TPoint, TPointComparer> y)
        {
            return x.Compare(y, this.pointComparer);
        }
    }
}