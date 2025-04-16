using FluentAssertions;
using GoldbachPairs.Run;
using Xunit;

namespace GoldbachPairs.Tests;

public class Tests
{
    [Theory]
    [InlineData(50, 3, 14)]
    [InlineData(50, 5, 7)]
    [InlineData(1000000, 3, 78497)]
    [InlineData(1000000, 5, 70328)]
    [InlineData(1000000, 7, 62185)]
    public void TestMinimalPairs(int n, int x, int expected)
    {
        var minPairsCount = GoldbachHelper.CountMinPairs(n, x);

        minPairsCount.Should().Be(expected);
    }
}