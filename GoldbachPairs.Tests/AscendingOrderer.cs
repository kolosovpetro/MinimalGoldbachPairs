using System;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace GoldbachPairs.Tests;

public class AscendingOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
        where TTestCase : ITestCase
    {
        var orderedCases = testCases
            .OrderBy(tc => tc.TestMethod.Method.Name)
            .ThenBy(tc => tc.TestMethodArguments?.FirstOrDefault() as int? ?? 0);

        return orderedCases;
    }
}
