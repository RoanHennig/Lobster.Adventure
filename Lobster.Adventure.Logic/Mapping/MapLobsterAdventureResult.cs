namespace Lobster.Adventure.Logic.Mapping;

public class MapLobsterAdventureResult : IMapLobsterAdventureResult
{
    public ILobsterAdventureResultEntity Map(LobsterAdventureResult adventureResult)
    {
        return new LobsterAdventureResultMongoDbEntity()
        {
            AdventureName = adventureResult.AdventureName,
            ChoiceResults = JsonSerializer.Serialize(adventureResult.ChoiceResults),
            UserId = adventureResult.UserId,
            AdventureTakenDate = adventureResult.AdventureTakenDate.ToString()
        };
    }

    public LobsterAdventureResult Map(ILobsterAdventureResultEntity adventureResultEntity)
    {
        return new LobsterAdventureResult()
        {
            AdventureName = adventureResultEntity.AdventureName,
            ChoiceResults = JsonSerializer.Deserialize<List<ChoiceResult>>(adventureResultEntity.ChoiceResults),
            UserId = adventureResultEntity.UserId,
            AdventureTakenDate = DateTime.Parse(adventureResultEntity.AdventureTakenDate)
        };
    }
}
