namespace RetailRocket.CenteredIntervalTree
{
    using System.Collections.Generic;

    public readonly struct EmptyCenteredIntervalTreeNode<TPoint, TPointComparer, TValue> :
        ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public List<IntervalValuePair<TPoint, TPointComparer, TValue>> Query(
            TPoint point,
            TPointComparer pointComparer)
        {
            return new List<IntervalValuePair<TPoint, TPointComparer, TValue>>();
        }
    }
}