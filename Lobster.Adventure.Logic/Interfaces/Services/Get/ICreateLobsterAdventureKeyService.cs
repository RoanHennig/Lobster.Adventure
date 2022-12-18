namespace Lobster.Adventure.Logic.Interfaces.Services.Get;

public interface ICreateLobsterAdventureKeyService
{
    LobsterAdventureKey Create(string userId, string adventureName);
}
