namespace Lobster.Adventure.DataAccess.Repositories;

public class AdventureMongoDbRespository : IAdventureRespository
{
    private IMongoCollection<LobsterAdventureMongoDbEntity> _adventureCollection;

    public AdventureMongoDbRespository(IMongoCollection<LobsterAdventureMongoDbEntity> adventureCollection)
    {
        _adventureCollection = adventureCollection;
    }

    public void Create(ILobsterAdventureEntity entity)
    {
        var mongoDbEntity = entity as LobsterAdventureMongoDbEntity;
        _adventureCollection.InsertOne(mongoDbEntity, null, CancellationToken.None);
    }

    public ILobsterAdventureEntity Read(LobsterAdventureKey key)
    {
        var filter = Builders<LobsterAdventureMongoDbEntity>.Filter.Eq("userId", key.UserId) &
                     Builders<LobsterAdventureMongoDbEntity>.Filter.Eq("name", key.Name);

        var result = _adventureCollection.FindSync(filter, null, CancellationToken.None)
                                                  .FirstOrDefault();

        return result;
    }
}
