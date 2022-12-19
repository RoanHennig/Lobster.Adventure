namespace Lobster.Adventure.Logic.Models;

public class Choice
{
    [Required]
    public string Id { get; init; }

    [Required]
    public string Prompt { get; init; }

    public List<Choice> Choices { get; init; }
}
