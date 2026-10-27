using Arishma.Verify.Infrastructure;
using Xunit;
namespace Arishma.Verify.Tests;
public class DatabaseProviderTests
{
    [Theory]
    [InlineData("Postgres", DatabaseProvider.Postgres)]
    [InlineData("MySql", DatabaseProvider.MySql)]
    [InlineData(null, DatabaseProvider.Postgres)]
    [InlineData("anything-else", DatabaseProvider.Postgres)]
    public void Parse_selects_expected_provider(string? input, DatabaseProvider expected)
        => Assert.Equal(expected, DatabaseProviderParser.Parse(input));
}
