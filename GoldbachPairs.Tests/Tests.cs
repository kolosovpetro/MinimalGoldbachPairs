using FluentAssertions;
using GoldbachPairs.Run;
using System.Linq;
using Xunit;

namespace GoldbachPairs.Tests;

public class Tests
{
    [Theory]
    [MemberData(nameof(TestData.PrimeCountTestCases), MemberType = typeof(TestData))]
    public void Test_Prime_Numbers_Count_Pi_n(int n, int x, int expected)
    {
        var minPairsCount = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(n + 3, x) + 1;

        minPairsCount.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestData.PrimeCountCasesFrom1To100Step1), MemberType = typeof(TestData))]
    public void Test_Prime_Count_From_1_To_100(int n, int x, int expected)
    {
        var result = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(n + 3, x) + 1;
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestData.PrimeCountCasesFrom1To100Step1), MemberType = typeof(TestData))]
    public void Test_Prime_Count_From_1_To_100_Sieve(int n, int x, int expected)
    {
        var result = GoldbachHelper.CountPrimesSieve(n);
        result.Should().Be(expected);
        x.Should().Be(3);
    }

    [Fact]
    public void Test_Non_Twin_Primes()
    {
        var minimalPairs = GoldbachHelper.GetMinimalGoldbachPairs(1_000_000);
        var minimalPairs7 = minimalPairs.Where(x => x.Value.Left == 5);
        var sieve = EratosthenesSieve.SieveOfEratosthenes(1_000_000);

        foreach (var pair in minimalPairs7)
        {
            var right = pair.Value.Right;

            var composite = right + 2;

            sieve[composite].Should().BeFalse();
        }
    }

    [Theory]
    [MemberData(nameof(TestData.TwinPrimesCountTestData), MemberType = typeof(TestData))]
    public void Test_Twin_Primes_Count(int bound, int expected)
    {
        var goldbachPairsMin3 = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3);
        var goldbachPairsMin5 = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 5, 5);

        var twins = goldbachPairsMin3 - goldbachPairsMin5;

        twins.Should().Be(expected);
    }

    [Theory]
    [InlineData(10, 4)]
    [InlineData(100, 25)]
    [InlineData(1000, 168)]
    [InlineData(10000, 1229)]
    [InlineData(100000, 9592)]
    [InlineData(1000000, 78498)]
    public void Test_Prime_Count_From_10_To_1_000_000(int n, int expected)
    {
        var result = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(n + 3, 3) + 1;
        result.Should().Be(expected);
    }
}