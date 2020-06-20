namespace Interval
{
    using System.Collections.Generic;

    public class CaseIgnoreStringComparer : IComparer<string>
    {
        public int Compare(
            string x,
            string y)
        {
            return System.StringComparer.OrdinalIgnoreCase.Compare(x, y);
        }
    }
}