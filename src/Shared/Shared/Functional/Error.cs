namespace Shared.Functional;

public record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public string Code { get; init; } = Code;
    public string Description { get; init; } = Description;

    public override string ToString() => $"{Code}: {Description}";
}
