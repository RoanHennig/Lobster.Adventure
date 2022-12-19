namespace Lobster.Adventure.Logic.Services.Read;

public class GetAdventureService : IGetAdventureService
{
    private readonly IAdventureRespository _adventureRespository;
    private readonly IMapLobsterAdventure _mapLobsterAdventure;
    private readonly ICreateLobsterAdventureKeyService _createLobsterAdventureKeyService;

    public GetAdventureService(IAdventureRespository adventureRespository,
                               IMapLobsterAdventure mapLobsterAdventure,
                               ICreateLobsterAdventureKeyService createLobsterAdventureKeyService)
    {
        _adventureRespository = adventureRespository;
        _mapLobsterAdventure = mapLobsterAdventure;
        _createLobsterAdventureKeyService = createLobsterAdventureKeyService;   }

    public LobsterAdventure Get(string userId, string adventureName)
    {
        var key = _createLobsterAdventureKeyService.Create(userId, adventureName);

        var entity = _adventureRespository.Read(key);

        if (entity is null)
            return null;

        return _mapLobsterAdventure.Map(entity);
    }
}
