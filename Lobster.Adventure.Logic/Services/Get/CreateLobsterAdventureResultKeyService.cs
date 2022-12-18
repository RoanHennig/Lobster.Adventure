namespace Lobster.Adventure.Logic.Services.Get;

public class CreateLobsterAdventureResultKeyService : ICreateLobsterAdventureResultKeyService
{
    public LobsterAdventureResultKey Create(string userId, string adventureName, string adventureDateTaken)
    {
        return new LobsterAdventureResultKey()
        {
            AdventureName = adventureName,
            AdventureTakenDate = adventureDateTaken,
            UserId = userId
        };
    }
}
