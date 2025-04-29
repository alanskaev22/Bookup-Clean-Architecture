namespace Shared.Functional;

public record Error
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public string Code { get; init; }
    public string Description { get; init; }

    private Error(string code, string description)
    {
        Code = code;
        Description = description;
    }

    public static Error ForBadRequest(string code, string description) => new(code, description);
    public static Error ForBadRequest(string description) => new(string.Empty, description);
}
