namespace Lobster.Adventure.Logic.Models;

public class ChoiceResult
{
    [Required]
    public string ChoiceId { get; init; }

    [Required]
    public string ChoiceIdTaken { get; init; }
}
