namespace Lobster.Adventure.Logic.Interfaces.Mapping;

public interface IMapLobsterAdventure
{
    ILobsterAdventureEntity Map(LobsterAdventure adventure);
    LobsterAdventure Map(ILobsterAdventureEntity adventureEntity);
}
