namespace Lobster.Adventure.Logic.Models;

public class LobsterAdventureResult
{
    [Required]
    public string UserId { get; init; }

    [Required]
    public string AdventureName { get; init; }

    [Required]
    public DateTime AdventureTakenDate { get; set; }

    [Required]
    public List<ChoiceResult> ChoiceResults { get; init; }
}
