namespace Interval.Intervals.EmptyInterval
{
    using System;

    public class EmptyInterval<TPoint, TPointComparer>
    {
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
    }
}