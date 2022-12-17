namespace Lobster.Adventure.Logic.Models;

public class Choice
{
    public string Id { get; init; }
    public string Prompt { get; init; }
    public List<Choice> Choices { get; init; }
    public bool IsEnd { get; init; }
}
