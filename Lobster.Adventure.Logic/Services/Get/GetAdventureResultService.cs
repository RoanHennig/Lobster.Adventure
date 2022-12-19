namespace Lobster.Adventure.Logic.Services.Get;

public class GetAdventureResultService : IGetAdventureResultService
{
    private readonly IAdventureResultsRespository _adventureResultsRespository;
    private readonly IMapLobsterAdventureResult _mapLobsterAdventureResult;
    private readonly ICreateLobsterAdventureResultKeyService _createLobsterAdventureResultKeyService;

    public GetAdventureResultService(IAdventureResultsRespository adventureResultsRespository,
                                     IMapLobsterAdventureResult mapLobsterAdventureResult,
                                     ICreateLobsterAdventureResultKeyService createLobsterAdventureResultKeyService)
    {
        _adventureResultsRespository = adventureResultsRespository;
        _mapLobsterAdventureResult = mapLobsterAdventureResult;
        _createLobsterAdventureResultKeyService = createLobsterAdventureResultKeyService;
    }

    public LobsterAdventureResult Get(string userId, string adventureName, string adventureDateTaken)
    {
        var key = _createLobsterAdventureResultKeyService.Create(userId, adventureName, adventureDateTaken);

        var entity = _adventureResultsRespository.Read(key);

        if (entity is null)
            return null;

        return _mapLobsterAdventureResult.Map(entity);
    }
}
