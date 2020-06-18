namespace Interval.Intervals.EmptyInterval.Operations
{
    public static class EmptyIntervalContainsPointOperation
    {
        public static bool Contains<TPoint, TPointComparer>(
            this EmptyInterval<TPoint, TPointComparer> infinityInterval)
        {
            return false;
        }
    }
}