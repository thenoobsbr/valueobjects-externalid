using FluentAssertions;
using TRExternalId.Core;

namespace TRExternalId.Code.Tests;

public class ExternalIdTests
{
    [Theory]
    [MemberData(nameof(GetValidParameters))]
    public void GivenExternalIdShouldCreateRandomValueWithPrefix(int maxLength, string prefix)
    {
        var externalId = ExternalId.Create(maxLength, prefix);
        externalId
            .Should()
            .HaveLength(maxLength)
            .And
            .StartWith(prefix);
    }
    
    [Theory]
    [MemberData(nameof(GetInvalidMaxLengthParameter))]
    public void GivenExternalIdWhenMaxLengthInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => ExternalId.Create(maxLength, prefix);
        externalId
            .Should()
            .Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenExternalIdWhenPrefixNullShouldThrow()
    {
        var externalId = () => ExternalId.Create(20, null!);
        externalId
            .Should()
            .Throw<ArgumentNullException>();
    }
    

    public static IEnumerable<object[]> GetValidParameters()
    {
        var maxLength = Random.Shared.Next(20, 100);
        yield return new object[]
        {
            maxLength,
            Guid.NewGuid().ToString().Substring(0, 6)
        };
    }
    
    public static IEnumerable<object[]> GetInvalidMaxLengthParameter()
    {
        var maxLength = Random.Shared.Next(0, 20);
        yield return new object[]
        {
            maxLength,
            Guid.NewGuid().ToString().Substring(0, 6)
        };
    }
}