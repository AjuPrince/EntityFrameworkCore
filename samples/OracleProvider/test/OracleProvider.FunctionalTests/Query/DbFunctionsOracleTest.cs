// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore.Query
{
    public class DbFunctionsOracleTest : DbFunctionsTestBase<NorthwindQueryOracleFixture<NoopModelCustomizer>>
    {
        public DbFunctionsOracleTest(NorthwindQueryOracleFixture<NoopModelCustomizer> fixture, ITestOutputHelper testOutputHelper)
            : base(fixture)
        {
            fixture.TestSqlLoggerFactory.Clear();
        }

        [ConditionalFact]
        public override void String_Like_Literal()
        {
            using (var context = CreateContext())
            {
                var count = context.Customers.Count(c => EF.Functions.Like(c.ContactName, "%M%"));

                Assert.Equal(19, count); // TODO: case-sensitive - use REGEXP_LIKE function?
            }
        }

        [ConditionalFact(Skip = "See issue#10520")]
        public override void DateDiff_Microsecond()
        {
            base.DateDiff_Microsecond();
        }

        [ConditionalFact(Skip = "See issue#10520")]
        public override void DateDiff_Millisecond()
        {
            base.DateDiff_Millisecond();
        }

        [ConditionalFact(Skip = "See issue#10520")]
        public override void DateDiff_Nanosecond()
        {
            base.DateDiff_Nanosecond();
        }
    }
}
