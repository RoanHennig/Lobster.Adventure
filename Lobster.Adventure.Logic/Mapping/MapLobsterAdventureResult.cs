namespace Lobster.Adventure.Logic.Mapping;

public class MapLobsterAdventureResult : IMapLobsterAdventureResult
{
    public LobsterAdventureResultEntity Map(LobsterAdventureResult adventureResult)
    {
        return new LobsterAdventureResultEntity()
        {
            AdventureName = adventureResult.AdventureName,
            ChoiceResults = JsonSerializer.Serialize(adventureResult.ChoiceResults),
            UserId = adventureResult.UserId,
            AdventureTakenDate = adventureResult.AdventureTakenDate.ToString()
        };
    }
}
