namespace Lobster.Adventure.DataAccess.Entities;

public class LobsterAdventureResultEntity
{
    [BsonElement("userId")]
    public string UserId { get; init; }
    [BsonElement("adventureName")]
    public string AdventureName { get; init; }
    [BsonElement("adventureTakenDate")]
    public string AdventureTakenDate { get; init; }
    [BsonElement("choiceResults")]
    public string ChoiceResults { get; init; }
}
