namespace Interval.Boundaries.Operations
{
    using System.Collections.Generic;
    using Interval.Boundaries.LowerBoundary;

    public class LowerBoundaryComparer<TPoint, TPointComparer> :
        IComparer<ILowerBoundary<TPoint, TPointComparer>>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        private readonly TPointComparer pointComparer;

        public LowerBoundaryComparer(
            TPointComparer pointComparer)
        {
            this.pointComparer = pointComparer;
        }

        public int Compare(
            ILowerBoundary<TPoint, TPointComparer> x,
            ILowerBoundary<TPoint, TPointComparer> y)
        {
            return x.Compare(y, this.pointComparer);
        }
    }
}