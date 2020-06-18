namespace Interval.UnitTests.Operations.Intersect
{
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.OneOfIntervals;
    using Interval.OneOfIntervals.Operations;
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
            var leftInterval = OneOfIntervalsFactory.BuildClosedInterval(
                new LowerClosedBoundary<int>(lowerBoundaryPoint),
                new UpperClosedBoundary<int>(upperBoundaryPoint),
                pointComparer: new IntComparer());

            var rightInterval = OneOfIntervalsFactory.BuildInfinityInterval<int, IntComparer>();

            var intersection = leftInterval.Intersect(
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
            var leftInterval = OneOfIntervalsFactory.BuildOpenInterval(
                new LowerOpenBoundary<int>(lowerBoundaryPoint),
                new UpperOpenBoundary<int>(upperBoundaryPoint),
                pointComparer: new IntComparer());

            var rightInterval = OneOfIntervalsFactory.BuildInfinityInterval<int, IntComparer>();

            var intersection = leftInterval.Intersect(
                rightInterval,
                pointComparer: new IntComparer());

            Assert.Equal(
                expected: leftInterval,
                actual: intersection);
        }
    }
}