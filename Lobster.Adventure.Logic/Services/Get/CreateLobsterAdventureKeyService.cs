namespace Lobster.Adventure.Logic.Services.Get;

public class CreateLobsterAdventureKeyService : ICreateLobsterAdventureKeyService
{
    public LobsterAdventureKey Create(string userId, string adventureName)
    {
        return new LobsterAdventureKey()
        {
            Name = adventureName,
            UserId = userId
        };
    }
}
