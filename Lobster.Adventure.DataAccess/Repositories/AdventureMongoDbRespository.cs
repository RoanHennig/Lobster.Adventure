namespace Lobster.Adventure.DataAccess.Repositories;

public class AdventureMongoDbRespository : IAdventureRespository
{
    private IMongoCollection<LobsterAdventureEntity> _adventureCollection;

    public AdventureMongoDbRespository(IMongoCollection<LobsterAdventureEntity> adventureCollection)
    {
        _adventureCollection = adventureCollection;
    }

    public void Create(LobsterAdventureEntity entity)
    {
        _adventureCollection.InsertOne(entity, null, CancellationToken.None);
    }

    public LobsterAdventureEntity Read(LobsterAdventureKey key)
    {
        var filter = Builders<LobsterAdventureEntity>.Filter.Eq("userId", key.UserId) &
                     Builders<LobsterAdventureEntity>.Filter.Eq("name", key.Name);

        var result = _adventureCollection.FindSync(filter, null, CancellationToken.None)
                                                  .FirstOrDefault();

        return result;
    }
}
