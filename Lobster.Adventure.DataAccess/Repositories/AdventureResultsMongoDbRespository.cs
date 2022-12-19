namespace Lobster.Adventure.DataAccess.Repositories;

public class AdventureResultsMongoDbRespository : IAdventureResultsRespository
{
    private IMongoCollection<LobsterAdventureResultEntity> _adventureResultCollection;

    public AdventureResultsMongoDbRespository(IMongoCollection<LobsterAdventureResultEntity> adventureResultCollection)
    {
        _adventureResultCollection = adventureResultCollection;
    }

    public void Create(LobsterAdventureResultEntity entity)
    {
        _adventureResultCollection.InsertOne(entity, null, CancellationToken.None);
    }

    public LobsterAdventureResultEntity Read(LobsterAdventureResultKey key)
    {
        var filter = Builders<LobsterAdventureResultEntity>.Filter.Eq("userId", key.UserId) &
                     Builders<LobsterAdventureResultEntity>.Filter.Eq("adventureName", key.AdventureName) &
                     Builders<LobsterAdventureResultEntity>.Filter.Eq("adventureTakenDate", key.AdventureTakenDate);

        var result = _adventureResultCollection.FindSync(filter, null, CancellationToken.None).FirstOrDefault();

        return result;
    }
}
