namespace Lobster.Adventure.DataAccess.Entities;

public class LobsterAdventureEntity
{
    [BsonElement("userId")]
    public string UserId { get; init; }
    [BsonElement("name")]
    public string Name { get; init; }
    [BsonElement("adventureChoice")]
    public string AdventureChoice { get; init; }
}
