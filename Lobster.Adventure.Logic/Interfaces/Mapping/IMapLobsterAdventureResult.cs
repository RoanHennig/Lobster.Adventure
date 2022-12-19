namespace Lobster.Adventure.Logic.Interfaces.Mapping;

public interface IMapLobsterAdventureResult
{
    ILobsterAdventureResultEntity Map(LobsterAdventureResult adventureResult);

    LobsterAdventureResult Map(ILobsterAdventureResultEntity adventureResultEntity);
}
