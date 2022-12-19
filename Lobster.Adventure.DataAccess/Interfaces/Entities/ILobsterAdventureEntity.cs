namespace Lobster.Adventure.DataAccess.Interfaces.Entities;

public interface ILobsterAdventureEntity
{
    string UserId { get; init; }
    string Name { get; init; }
    string AdventureChoice { get; init; }
}
