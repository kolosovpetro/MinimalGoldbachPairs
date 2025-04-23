using FluentAssertions;
using System.Linq;
using Xunit;

namespace GoldbachPairs.Tests;

[TestCaseOrderer("GoldbachPairs.Tests.AscendingOrderer", "GoldbachPairs.Tests")]
public class Tests
{
    [Theory]
    [MemberData(nameof(TestData.PrimeCountTestCases), MemberType = typeof(TestData))]
    public void Count_Primes_Using_Minimal_Goldbach_Pairs_Up_To_1_500_000(int bound, int totalPrimesExpected)
    {
        var minPairsCount = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3) + 1;
        minPairsCount.Should().Be(totalPrimesExpected);
    }

    [Theory]
    [MemberData(nameof(TestData.CountPrimesUpTo10000Step1), MemberType = typeof(TestData))]
    public void Count_Primes_Using_Minimal_Goldbach_Pairs_Up_To_10000(int bound, int expected)
    {
        var result = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3) + 1;
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(TestData.PrimeCountCasesFrom1To100Step1), MemberType = typeof(TestData))]
    public void Test_Prime_Count_From_1_To_100_Sieve(int bound, int totalPrimesExpected)
    {
        var result = GoldbachHelper.CountPrimesSieve(bound);
        result.Should().Be(totalPrimesExpected);
    }

    [Fact]
    public void Test_Pi7_Plus_2_Is_Composite()
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
    public void Count_Twin_Primes_Using_Minimal_Goldbach_Pairs(int bound, int expected)
    {
        var goldbachPairsMin3 = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 3, 3);
        var goldbachPairsMin5 = GoldbachHelper.CountMinimalGoldbachPairsHavingPi(bound + 5, 5);

        var twins = goldbachPairsMin3 - goldbachPairsMin5;

        twins.Should().Be(expected);
    }
}
