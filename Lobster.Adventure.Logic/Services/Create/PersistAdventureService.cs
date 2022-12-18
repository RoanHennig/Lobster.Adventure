namespace Lobster.Adventure.Logic.Services.Create;

public class PersistAdventureService : IPersistAdventureService
{
    private readonly IAdventureRespository _adventureRespository;
    private readonly IMapLobsterAdventure _mapLobsterAdventure;

    public PersistAdventureService(IAdventureRespository adventureRespository,
                                   IMapLobsterAdventure mapLobsterAdventure)
    {
        _adventureRespository = adventureRespository;
        _mapLobsterAdventure = mapLobsterAdventure;
    }

    public string Persist(LobsterAdventure adventure)
    {
        var entity = _mapLobsterAdventure.Map(adventure);

        try
        {
            _adventureRespository.Create(entity);

            return String.Empty;
        }
        catch (AdventureExistsException)
        {
            return FailuresMessages.AdventureAlreadyExists;
        }
    }
}
