namespace Lobster.Adventure.Logic.Interfaces.Mapping;

public interface IMapLobsterAdventureResult
{
    LobsterAdventureResultEntity Map(LobsterAdventureResult adventureResult);

    LobsterAdventureResult Map(LobsterAdventureResultEntity adventureResultEntity);
}
