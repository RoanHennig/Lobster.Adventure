namespace Lobster.Adventure.DataAccess.Interfaces.Entities;

public interface ILobsterAdventureResultEntity
{
    string UserId { get; init; }
    string AdventureName { get; init; }
    string AdventureTakenDate { get; init; }
    string ChoiceResults { get; init; }
}
