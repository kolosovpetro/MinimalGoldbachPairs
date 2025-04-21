using System.Collections.Generic;

namespace GoldbachPairs.Tests;

public static class TestData
{
    public static IEnumerable<object[]> PrimeCountTestCases =>
        new List<object[]>
        {
            new object[] { 150, 35 },
            new object[] { 1_000, 168 },
            new object[] { 10_000, 1229 },
            new object[] { 100_000, 9592 },
            new object[] { 1_000_000, 78498 },
            new object[] { 1_500_000, 114155 }
        };

    public static IEnumerable<object[]> TwinPrimesCountTestData =>
        new List<object[]>
        {
            new object[] { 10, 2 },
            new object[] { 100, 8 },
            new object[] { 1_000, 35 },
            new object[] { 10_000, 205 },
            new object[] { 100_000, 1224 },
            new object[] { 1_000_000, 8169 }
        };

    public static IEnumerable<object[]> PrimeCountCasesFrom1To100Step1 =>
        new List<object[]>
        {
            new object[] { 2, 1 },
            new object[] { 3, 2 },
            new object[] { 4, 2 },
            new object[] { 5, 3 },
            new object[] { 6, 3 },
            new object[] { 7, 4 },
            new object[] { 8, 4 },
            new object[] { 9, 4 },
            new object[] { 10, 4 },
            new object[] { 11, 5 },
            new object[] { 12, 5 },
            new object[] { 13, 6 },
            new object[] { 14, 6 },
            new object[] { 15, 6 },
            new object[] { 16, 6 },
            new object[] { 17, 7 },
            new object[] { 18, 7 },
            new object[] { 19, 8 },
            new object[] { 20, 8 },
            new object[] { 21, 8 },
            new object[] { 22, 8 },
            new object[] { 23, 9 },
            new object[] { 24, 9 },
            new object[] { 25, 9 },
            new object[] { 26, 9 },
            new object[] { 27, 9 },
            new object[] { 28, 9 },
            new object[] { 29, 10 },
            new object[] { 30, 10 },
            new object[] { 31, 11 },
            new object[] { 32, 11 },
            new object[] { 33, 11 },
            new object[] { 34, 11 },
            new object[] { 35, 11 },
            new object[] { 36, 11 },
            new object[] { 37, 12 },
            new object[] { 38, 12 },
            new object[] { 39, 12 },
            new object[] { 40, 12 },
            new object[] { 41, 13 },
            new object[] { 42, 13 },
            new object[] { 43, 14 },
            new object[] { 44, 14 },
            new object[] { 45, 14 },
            new object[] { 46, 14 },
            new object[] { 47, 15 },
            new object[] { 48, 15 },
            new object[] { 49, 15 },
            new object[] { 50, 15 },
            new object[] { 51, 15 },
            new object[] { 52, 15 },
            new object[] { 53, 16 },
            new object[] { 54, 16 },
            new object[] { 55, 16 },
            new object[] { 56, 16 },
            new object[] { 57, 16 },
            new object[] { 58, 16 },
            new object[] { 59, 17 },
            new object[] { 60, 17 },
            new object[] { 61, 18 },
            new object[] { 62, 18 },
            new object[] { 63, 18 },
            new object[] { 64, 18 },
            new object[] { 65, 18 },
            new object[] { 66, 18 },
            new object[] { 67, 19 },
            new object[] { 68, 19 },
            new object[] { 69, 19 },
            new object[] { 70, 19 },
            new object[] { 71, 20 },
            new object[] { 72, 20 },
            new object[] { 73, 21 },
            new object[] { 74, 21 },
            new object[] { 75, 21 },
            new object[] { 76, 21 },
            new object[] { 77, 21 },
            new object[] { 78, 21 },
            new object[] { 79, 22 },
            new object[] { 80, 22 },
            new object[] { 81, 22 },
            new object[] { 82, 22 },
            new object[] { 83, 23 },
            new object[] { 84, 23 },
            new object[] { 85, 23 },
            new object[] { 86, 23 },
            new object[] { 87, 23 },
            new object[] { 88, 23 },
            new object[] { 89, 24 },
            new object[] { 90, 24 },
            new object[] { 91, 24 },
            new object[] { 92, 24 },
            new object[] { 93, 24 },
            new object[] { 94, 24 },
            new object[] { 95, 24 },
            new object[] { 96, 24 },
            new object[] { 97, 25 },
            new object[] { 98, 25 },
            new object[] { 99, 25 },
            new object[] { 100, 25 }
        };

    public static IEnumerable<object[]> CountPrimesUpTo10000Step1 => GetCountPrimesUpTo10000Step1();

    private static IEnumerable<object[]> GetCountPrimesUpTo10000Step1()
    {
        for (int i = 6; i < 10_000; i++)
        {
            var primesCount = GoldbachHelper.CountPrimesSieve(i);
            yield return new object[] { i, primesCount };
        }
    }
}
