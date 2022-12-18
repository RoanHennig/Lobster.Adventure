namespace Lobster.Adventure.Logic.Interfaces.Services.Read;

public interface IGetAdventureService
{
    LobsterAdventure Get(string userId, string adventureName);
}
