namespace RetailRocket.CenteredIntervalTree
{
    using System.Collections.Generic;
    using Interval.Intervals.Operations.BoundaryIntervals;

    public readonly struct CenteredIntervalTreeNode<TPoint, TPointComparer, TValue> :
        ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue>
        where TPoint : notnull
        where TPointComparer : IComparer<TPoint>, new()
    {
        public CenteredIntervalTreeNode(
            ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue> leftBranch,
            ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue> rightBranch,
            List<IntervalValuePair<TPoint, TPointComparer, TValue>> centerBelonged,
            TPoint centralPoint)
        {
            this.LeftBranch = leftBranch;
            this.RightBranch = rightBranch;
            this.CenterBelonged = centerBelonged;
            this.CentralPoint = centralPoint;
        }

        public ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue> LeftBranch { get; }

        public ICenteredIntervalTreeNode<TPoint, TPointComparer, TValue> RightBranch { get; }

        public List<IntervalValuePair<TPoint, TPointComparer, TValue>> CenterBelonged { get; }

        public TPoint CentralPoint { get; }

        public List<IntervalValuePair<TPoint, TPointComparer, TValue>> Query(
            TPoint point,
            TPointComparer pointComparer)
        {
            var result = new List<IntervalValuePair<TPoint, TPointComparer, TValue>>();
            foreach (var intervalValuePair in this.CenterBelonged)
            {
                var interval = intervalValuePair.Interval;

                if (interval
                    .LowerBoundary()
                    .CompareToPoint(point, pointComparer) > 0)
                {
                    break;
                }

                if (interval.Contains(point, pointComparer))
                {
                    result.Add(intervalValuePair);
                }
            }

            var centerComparisonResult =
                pointComparer.Compare(point, this.CentralPoint);

            if (centerComparisonResult < 0)
            {
                result
                    .AddRange(this.LeftBranch
                        .Query(
                            point,
                            pointComparer));
            }
            else if (centerComparisonResult > 0)
            {
                result
                    .AddRange(this.RightBranch
                        .Query(
                            point,
                            pointComparer));
            }

            return result;
        }
    }
}