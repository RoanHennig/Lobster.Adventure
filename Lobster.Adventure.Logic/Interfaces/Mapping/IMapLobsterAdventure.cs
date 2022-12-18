namespace Lobster.Adventure.Logic.Interfaces.Mapping;

public interface IMapLobsterAdventure
{
    LobsterAdventureEntity Map(LobsterAdventure adventure);
    LobsterAdventure Map(LobsterAdventureEntity adventureEntity);
}
