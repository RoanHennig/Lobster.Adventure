namespace Lobster.Adventure.Logic.Interfaces.Services.Get;

public interface ICreateLobsterAdventureResultKeyService
{
    LobsterAdventureResultKey Create(string userId, string adventureName, string adventureDateTaken);
}
