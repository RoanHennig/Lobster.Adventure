namespace Lobster.Adventure.DataAccess.Repositories;

public class AdventureResultsMongoDbRespository : IAdventureResultsRespository
{
    private IMongoCollection<LobsterAdventureResultMongoDbEntity> _adventureResultCollection;

    public AdventureResultsMongoDbRespository(IMongoCollection<LobsterAdventureResultMongoDbEntity> adventureResultCollection)
    {
        _adventureResultCollection = adventureResultCollection;
    }

    public void Create(ILobsterAdventureResultEntity entity)
    {
        var mongoDbEntity = entity as LobsterAdventureResultMongoDbEntity;

        _adventureResultCollection.InsertOne(mongoDbEntity, null, CancellationToken.None);
    }

    public ILobsterAdventureResultEntity Read(LobsterAdventureResultKey key)
    {
        var filter = Builders<LobsterAdventureResultMongoDbEntity>.Filter.Eq("userId", key.UserId) &
                     Builders<LobsterAdventureResultMongoDbEntity>.Filter.Eq("adventureName", key.AdventureName) &
                     Builders<LobsterAdventureResultMongoDbEntity>.Filter.Eq("adventureTakenDate", key.AdventureTakenDate);

        var result = _adventureResultCollection.FindSync(filter, null, CancellationToken.None).FirstOrDefault();

        return result;
    }
}
