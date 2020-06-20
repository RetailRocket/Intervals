namespace Interval
{
    using System.Collections.Generic;

    public class StringComparer : IComparer<string>
    {
        public int Compare(
            string x,
            string y)
        {
            return System.StringComparer.Ordinal.Compare(x, y);
        }
    }
}