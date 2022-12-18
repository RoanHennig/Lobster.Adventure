namespace Lobster.Adventure.Logic.Models;

public class LobsterAdventureResult
{
    public string UserId { get; init; }
    public string Name { get; init; }
    public string AdventureTakenDate { get; set; }
    public List<ChoiceResult> ChoiceResults { get; init; }
}
