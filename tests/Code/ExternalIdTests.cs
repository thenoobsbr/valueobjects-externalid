using FluentAssertions;
using TRExternalId.Core;

namespace TRExternalId.Code.Tests;

public class ExternalIdTests
{
    [Theory]
    [MemberData(nameof(GetParameters))]
    public void Test1(int maxLength, string prefix)
    {
        var externalId = ExternalId.Create(maxLength, prefix);
        externalId
            .Should()
            .HaveLength(maxLength)
            .And
            .StartWith(prefix);
    }

    public static IEnumerable<object[]> GetParameters()
    {
        var maxLength = Random.Shared.Next(20, 100);
        yield return new object[]
        {
            maxLength,
            Guid.NewGuid().ToString().Substring(0, 6)
        };
    }
}