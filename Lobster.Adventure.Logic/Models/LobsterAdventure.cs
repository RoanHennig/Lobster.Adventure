namespace Lobster.Adventure.Logic.Models;

public class LobsterAdventure
{
    [Required]
    public string UserId { get; init; }

    [Required]
    public string Name { get; init; }

    public DateTime AdventureCreationDate { get; set; }

    [Required]
    public Choice AdventureChoice { get; init; }
}
