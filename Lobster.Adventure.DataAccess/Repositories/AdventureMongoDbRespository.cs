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
        try
        {
            var mongoDbEntity = entity as LobsterAdventureMongoDbEntity;
            _adventureCollection.InsertOne(mongoDbEntity, null, CancellationToken.None);
        }
        catch (MongoWriteException ex)
        {
            //Code 11000 refers to a duplicate index error
            if(ex.WriteError.Code == 11000)
            {
                throw new AdventureExistsException("adventure already exists.", ex);
            }
        }
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
