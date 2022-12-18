namespace Lobster.Adventure.Logic.Interfaces.Services.Get;

public interface IGetAdventureResultService
{
    LobsterAdventureResult Get(string userId, string adventureName, string adventureDateTaken);
}
