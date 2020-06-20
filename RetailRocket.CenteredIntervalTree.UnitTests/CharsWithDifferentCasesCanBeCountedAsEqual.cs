namespace RetailRocket.CenteredIntervalTree.UnitTests
{
    using System.Collections.Generic;
    using Interval;
    using Interval.Boundaries.LowerBoundary;
    using Interval.Boundaries.UpperBoundary;
    using Interval.Intervals;
    using Xunit;

    public class CharsWithDifferentCasesCanBeCountedAsEqual
    {
        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void PointCanBeFoundInBothCases(
            string point)
        {
            var pointComparer = new StringComparer();
            var intervalTree = CenteredIntervalTreeFactory
                .Build(
                    intervalValuePairList: new List<IntervalValuePair<string, StringComparer, string>>
                    {
                        new IntervalValuePair<string, StringComparer, string>(
                            interval: (IBoundaryInterval<string, StringComparer>)IntervalFactory.Build(
                                lowerBoundary: new LowerClosedBoundary<string, StringComparer>(point),
                                upperBoundary: new UpperClosedBoundary<string, StringComparer>(point),
                                pointComparer: pointComparer),
                            value: "Value"),
                    },
                    pointComparer: pointComparer);

            Assert.Single(
                collection: intervalTree.Query(
                    point: point.ToLower(),
                    pointComparer));

            Assert.Single(
                collection: intervalTree.Query(
                    point: point.ToUpper(),
                    pointComparer));
        }

        [Theory]
        [InlineData("a", "b")]
        [InlineData("b", "c")]
        public void PointDoNotFinds(
            string point,
            string query)
        {
            var pointComparer = new StringComparer();
            var intervalTree = CenteredIntervalTreeFactory
                .Build(
                    intervalValuePairList: new List<IntervalValuePair<string, StringComparer, string>>
                    {
                        new IntervalValuePair<string, StringComparer, string>(
                            interval: (IBoundaryInterval<string, StringComparer>)IntervalFactory.Build(
                                lowerBoundary: new LowerClosedBoundary<string, StringComparer>(point),
                                upperBoundary: new UpperClosedBoundary<string, StringComparer>(point),
                                pointComparer: pointComparer),
                            value: "Value"),
                    },
                    pointComparer: pointComparer);

            Assert.Empty(
                collection: intervalTree.Query(
                    point: query,
                    pointComparer: pointComparer));

            Assert.Empty(
                collection: intervalTree.Query(
                    point: query,
                    pointComparer: pointComparer));
        }
    }
}