using Shouldly;

using TheNoobs.ValueObjects.ExternalId.UnitTests.Stubs;

namespace TheNoobs.ValueObjects.ExternalId.UnitTests;

public class ExternalIdTests
{
    public static IEnumerable<object[]> GetInvalidMaxLengthParameter()
    {
        var maxLength = new Random().Next(0, 20);
        yield return
        [
            maxLength,
            Guid.NewGuid().ToString()[..4]
        ];
    }

    public static IEnumerable<object[]> GetInvalidPrefixDataParameter()
    {
        var maxLength = new Random().Next(20, 100);
        yield return
        [
            maxLength,
            "123"
        ];

        yield return
        [
            maxLength,
            "abc_"
        ];
    }

    public static IEnumerable<object[]> GetInvalidPrefixLengthParameter()
    {
        var maxLength = new Random().Next(20, 100);
        var prefixLength = new Random().Next(5, 10);
        yield return
        [
            maxLength,
            Guid.NewGuid().ToString()[..prefixLength]
        ];
    }

    public static IEnumerable<object[]> GetValidParameters()
    {
        var maxLength = new Random().Next(20, 100);
        yield return
        [
            maxLength,
            "abc"
        ];

        yield return
        [
            maxLength,
            "Abc"
        ];

        yield return
        [
            maxLength,
            "aBc"
        ];

        yield return
        [
            maxLength,
            "ABC"
        ];
    }

    public static IEnumerable<object[]> GetValidValues()
    {
        yield return
        [
            "abc_1234567890123456",
            20
        ];

        yield return
        [
            "sub_12345678901234567890123456",
            30
        ];
    }

    [Theory]
    [MemberData(nameof(GetValidParameters))]
    public void GivenExternalIdShouldCreateRandomValueWithPrefix(int maxLength, string prefix)
    {
        var externalId = new StubId(maxLength, prefix);
        externalId.Value
            .ShouldStartWith(prefix);
        externalId.Value
            .Length
            .ShouldBe(maxLength);
    }

    [Theory]
    [MemberData(nameof(GetValidValues))]
    public void GivenExternalIdShouldCreateWithValue(string value, int maxLength)
    {
        var externalId = new StubId(value);
        externalId.Value
            .ShouldBe(value);
        externalId.Value
            .Length
            .ShouldBe(maxLength);
    }

    [Theory]
    [MemberData(nameof(GetInvalidMaxLengthParameter))]
    public void GivenExternalIdWhenMaxLengthInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .ShouldThrow<ArgumentOutOfRangeException>();
    }

    [Theory]
    [MemberData(nameof(GetInvalidPrefixDataParameter))]
    public void GivenExternalIdWhenPrefixDataInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .ShouldThrow<ArgumentException>();
    }

    [Theory]
    [MemberData(nameof(GetInvalidPrefixLengthParameter))]
    public void GivenExternalIdWhenPrefixLengthInvalidShouldThrow(int maxLength, string prefix)
    {
        var externalId = () => new StubId(maxLength, prefix);
        externalId
            .ShouldThrow<ArgumentException>();
    }

    [Fact]
    public void GivenExternalIdWhenPrefixNullShouldThrow()
    {
        var externalId = () => new StubId(20, null!);
        externalId
            .ShouldThrow<ArgumentNullException>();
    }
}
