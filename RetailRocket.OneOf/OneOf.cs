using System;

namespace RetailRocket.OneOf
{
    public interface OneOf<T1, T2>
    {
        TResult Match<TResult>(
            Func<T1, TResult> case1,
            Func<T2, TResult> case2);
    }
}