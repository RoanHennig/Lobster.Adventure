namespace Lobster.Adventure.Logic.Mapping;

public class MapLobsterAdventure : IMapLobsterAdventure
{
    public LobsterAdventureEntity Map(LobsterAdventure adventure)
    {
        return new LobsterAdventureEntity()
        {
            UserId = adventure.UserId,
            Name = adventure.Name,
            AdventureChoice = JsonSerializer.Serialize(adventure.AdventureChoice)
        };
    }

    public LobsterAdventure Map(LobsterAdventureEntity adventureEntity)
    {
        return new LobsterAdventure()
        {
            UserId = adventureEntity.UserId,
            Name = adventureEntity.Name,
            AdventureChoice = JsonSerializer.Deserialize<Choice>(adventureEntity.AdventureChoice)
        };
    }
}
