using FluentAssertions;
using System.Linq;
using Xunit;

namespace GoldbachPairs.Tests;

public class Tests
{
    [Theory]
    [MemberData(nameof(TestData.PrimeCountTestCases), MemberType = typeof(TestData))]
    public void Count_Primes_Using_Minimal_Goldbach_Pairs_Pi3(int bound, int totalPrimesExpected)
    {
        var minPairsCount = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3) + 1;
        minPairsCount.Should().Be(totalPrimesExpected);
    }

    [Theory]
    [MemberData(nameof(TestData.PrimeCountCasesFrom1To100Step1), MemberType = typeof(TestData))]
    public void Test_Prime_Count_From_1_To_100(int bound, int totalPrimesExpected)
    {
        var result = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3) + 1;
        result.Should().Be(totalPrimesExpected);
    }

    [Theory]
    [MemberData(nameof(TestData.PrimeCountCasesFrom1To100Step1), MemberType = typeof(TestData))]
    public void Test_Prime_Count_From_1_To_100_Sieve(int bound, int totalPrimesExpected)
    {
        var result = GoldbachHelper.CountPrimesSieve(bound);
        result.Should().Be(totalPrimesExpected);
    }

    [Fact]
    public void Test_Non_Twin_Primes()
    {
        var minimalPairs = GoldbachHelper.GetMinimalGoldbachPairs(1_000_000);
        var minimalPairs7 = minimalPairs.Where(x => x.Value.Left == 5);
        var sieve = GoldbachHelper.Primes.SieveOfEratosthenes;

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
