namespace Interval
{
    using System.Collections.Generic;

    public class IntComparer : IComparer<int>
    {
        public int Compare(
            int x,
            int y)
        {
            return x.CompareTo(y);
        }
    }
}