namespace Interval.Intervals.InfinityInterval.Operations
{
    using System.Collections.Generic;

    public static class InfinityIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this InfinityInterval<TPoint, TPointComparer> infinityInterval)
            where TPointComparer : IComparer<TPoint>, new()
        {
            return true;
        }
    }
}