namespace Lobster.Adventure.Logic.Models;

public class Choice
{
    public string Id { get; set; }
    public string Prompt { get; init; }
    public List<Choice> Choices { get; init; }
}
