using HashidsNet;

namespace TRExternalId.Core;

public static class ExternalId
{
    private const string LOWER_CASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
    private const string UPPER_CASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string DIGITS = "0123456789";
    private const int NUMBERS = 4;
    private const int MAX_NUMBER_VALUE = 100;
    private const int MIN_LENGTH = 20;
    private static readonly Random _random = new();
    private static readonly string _alphabet = string.Concat(LOWER_CASE_CHARACTERS, UPPER_CASE_CHARACTERS, DIGITS);

    public static string Create(int maxLength) => Create(maxLength, string.Empty);
    
    public static string Create(int maxLength, string prefix)
    {
        if (maxLength < MIN_LENGTH)
        {
            throw new ArgumentOutOfRangeException(nameof(maxLength), "The max length should be greater than 20");
        }

        if (ReferenceEquals(prefix, null))
        {
            throw new ArgumentNullException(nameof(prefix), "The prefix is required");
        }
        
        if (!prefix.EndsWith("_")
            || !prefix.EndsWith("-"))
        {
            prefix += "_";
        }
        
        var salt = Guid.NewGuid().ToString();
        var hashids = new Hashids(salt, maxLength - prefix.Length, _alphabet);
        var numbers = Enumerable
            .Range(0, NUMBERS)
            .Select(r => _random.Next(MAX_NUMBER_VALUE))
            .ToList();
        var hash = hashids.Encode(numbers);
        return string.Concat(prefix, hash);
    }
}
