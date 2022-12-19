namespace Lobster.Adventure.Logic.Services.Save;

public class PersistAdventureResultsService : IPersistAdventureResultsService
{
    private readonly IAdventureResultsRespository _adventureResultsRespository;
    private readonly IMapLobsterAdventureResult _mapLobsterAdventureResult;

    public PersistAdventureResultsService(IAdventureResultsRespository adventureResultsRespository,
                                          IMapLobsterAdventureResult mapLobsterAdventureResult)
    {
        _adventureResultsRespository = adventureResultsRespository;
        _mapLobsterAdventureResult = mapLobsterAdventureResult;
    }

    public string Persist(LobsterAdventureResult adventureResult)
    {
        var entity = _mapLobsterAdventureResult.Map(adventureResult);

        try
        {
            _adventureResultsRespository.Create(entity);

            return string.Empty;
        }
        catch (AdventureResultExistsException)
        {
            return AdventureResultFailureMessages.AdventureResultAlreadyExists;
        }
    }
}
