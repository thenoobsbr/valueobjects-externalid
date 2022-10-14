namespace TheNoobs.ValueObjects.ExternalId.UnitTests.Stubs;

public class StubId : ExternalId
{
    public StubId(string value) : base(value)
    {
    }

    public StubId(int maxLength, string prefix) : base(maxLength, prefix)
    {
    }
}
