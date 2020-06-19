namespace Interval.Boundaries.UpperBoundary
{
    public interface IUpperPointedBoundary<TPoint> :
        IUpperBoundary<TPoint>
        where TPoint : notnull
    {
    }
}