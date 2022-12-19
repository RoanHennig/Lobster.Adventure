namespace Lobster.Adventure.Logic.Mapping;

public class MapLobsterAdventure : IMapLobsterAdventure
{
    public ILobsterAdventureEntity Map(LobsterAdventure adventure)
    {
        return new LobsterAdventureMongoDbEntity()
        {
            UserId = adventure.UserId,
            Name = adventure.Name,
            AdventureChoice = JsonSerializer.Serialize(adventure.AdventureChoice)
        };
    }

    public LobsterAdventure Map(ILobsterAdventureEntity adventureEntity)
    {
        return new LobsterAdventure()
        {
            UserId = adventureEntity.UserId,
            Name = adventureEntity.Name,
            AdventureChoice = JsonSerializer.Deserialize<Choice>(adventureEntity.AdventureChoice)
        };
    }
}
