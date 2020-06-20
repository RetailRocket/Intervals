namespace Interval.Intervals.Operations.BoundaryIntervals
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IsBoundaryPointOperation
    {
        public static bool IsBoundaryPoint<TPoint, TPointComparer>(
            this IBoundaryInterval<TPoint, TPointComparer> boundaryInterval,
            TPoint point,
            TPointComparer pointComparer)
            where TPoint : notnull
            where TPointComparer : IComparer<TPoint>, new()
        {
            return boundaryInterval
                .MapBoundaryPoints(p => p)
                .Any(p => pointComparer.Compare(p, point) == 0);
        }
    }
}