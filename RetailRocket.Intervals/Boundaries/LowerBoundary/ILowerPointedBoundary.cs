namespace Interval.Boundaries.LowerBoundary
{
    public interface ILowerPointedBoundary<TPoint> :
        ILowerBoundary<TPoint>
        where TPoint : notnull
    {
    }
}