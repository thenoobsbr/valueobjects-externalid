using FluentAssertions;
using TheNoobs.ValueObjects.ExternalId.UnitTests.Stubs;

namespace TheNoobs.ValueObjects.ExternalId.UnitTests;

public class ExternalIdTests
{
    [Theory]
    [MemberData(nameof(GetValidParameters))]
    public void GivenExternalIdShouldCreateRandomValueWithPrefix(int maxLength, string prefix)
    {
        var externalId = new StubId(maxLength, prefix);
        externalId.Value
            .Should()
            .HaveLength(maxLength)
            .And
            .StartWith(prefix);
    }
    
    [Theory]
    [MemberData(nameof(GetValidValues))]
    public void GivenExternalIdShouldCreateWithValue(string value, int maxLength)
    {
        var externalId = new StubId(value);
        externalId.Value
            .Should()
            .HaveLength(maxLength)
            .And
            .Be(value);
    }
    
    [Theory]
    [MemberData(nameof(GetInvalidMaxLengthParameter))]
    public void GivenExternalIdWhenMaxLengthInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .Should()
            .Throw<ArgumentOutOfRangeException>();
    }
    
    [Theory]
    [MemberData(nameof(GetInvalidPrefixLengthParameter))]
    public void GivenExternalIdWhenPrefixLengthInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .Should()
            .Throw<ArgumentException>();
    }
    
    [Theory]
    [MemberData(nameof(GetInvalidPrefixDataParameter))]
    public void GivenExternalIdWhenPrefixDataInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .Should()
            .Throw<ArgumentException>();
    }

    [Fact]
    public void GivenExternalIdWhenPrefixNullShouldThrow()
    {
        var externalId = () => new StubId(20, null!);
        externalId
            .Should()
            .Throw<ArgumentNullException>();
    }

    public static IEnumerable<object[]> GetValidValues()
    {
        yield return new object[]
        {
            "abc_1234567890123456",
            20
        };
        
        yield return new object[]
        {
            "sub_12345678901234567890123456",
            30
        };
    }

    public static IEnumerable<object[]> GetValidParameters()
    {
        var maxLength = new Random().Next(20, 100);
        yield return new object[]
        {
            maxLength,
            "abc"
        };
        
        yield return new object[]
        {
            maxLength,
            "Abc"
        };
        
        yield return new object[]
        {
            maxLength,
            "aBc"
        };
        
        yield return new object[]
        {
            maxLength,
            "ABC"
        };
    }
    
    public static IEnumerable<object[]> GetInvalidMaxLengthParameter()
    {
        var maxLength = new Random().Next(0, 20);
        yield return new object[]
        {
            maxLength,
            Guid.NewGuid().ToString()[..4]
        };
    }
    
    public static IEnumerable<object[]> GetInvalidPrefixLengthParameter()
    {
        var maxLength = new Random().Next(20, 100);
        var prefixLength = new Random().Next(5, 10);
        yield return new object[]
        {
            maxLength,
            Guid.NewGuid().ToString()[..prefixLength]
        };
    }
    
    public static IEnumerable<object[]> GetInvalidPrefixDataParameter()
    {
        var maxLength = new Random().Next(20, 100);
        yield return new object[]
        {
            maxLength,
            "123"
        };
        
        yield return new object[]
        {
            maxLength,
            "abc_"
        };
    }
}
