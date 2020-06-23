namespace Interval.UnitTests.Operations.Intersect
{
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals;
    using Interval.Intervals.Factories;
    using Interval.Intervals.Operations;
    using Xunit;

    public class InfinityIntervalTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(-100, -10)]
        [InlineData(10, 100)]
        public void IntersectWithClosedIntervalIsClosedInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var leftInterval = IntervalFactory.Build(
                new LowerClosedBoundary<int, IntComparer>(lowerBoundaryPoint),
                new UpperClosedBoundary<int, IntComparer>(upperBoundaryPoint),
                pointComparer: new IntComparer());

            var rightInterval = (IInterval<int, IntComparer>)IntervalFactory.InfinityInterval<int, IntComparer>();

            var intersection = leftInterval.Intersect<int, IntComparer, ILowerBoundary<int, IntComparer>, IUpperBoundary<int, IntComparer>>(
                rightInterval,
                pointComparer: new IntComparer());

            Assert.Equal(
                expected: leftInterval,
                actual: intersection);
        }

        [Theory]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(-100, -10)]
        [InlineData(10, 100)]
        public void IntersectWithOpenIntervalIsOpenInterval(
            int lowerBoundaryPoint,
            int upperBoundaryPoint)
        {
            var leftInterval = IntervalFactory.Build(
                new LowerOpenBoundary<int, IntComparer>(lowerBoundaryPoint),
                new UpperOpenBoundary<int, IntComparer>(upperBoundaryPoint),
                pointComparer: new IntComparer());

            var rightInterval = (IInterval<int, IntComparer>)IntervalFactory.InfinityInterval<int, IntComparer>();

            var intersection = leftInterval.Intersect<int, IntComparer, ILowerBoundary<int, IntComparer>, IUpperBoundary<int, IntComparer>>(
                rightInterval,
                pointComparer: new IntComparer());

            Assert.Equal(
                expected: leftInterval,
                actual: intersection);
        }
    }
}