using FluentAssertions;
using Lobster.Adventure.DataAccess.Exceptions;

namespace Lobster.Adventure.DataAccess.Repositories.Tests;

public class AdventureRespositoryTests
{

    [Fact()]
    public void teasd()
    {
        //Arrange
        var connectionString = $"mongodb://root:rootpassword@localhost:27017/?authSource=admin";

        MongoClient dbClient = new MongoClient(connectionString);
        var database = dbClient.GetDatabase("lobster");
        var adventureCollection = database.GetCollection<LobsterAdventureMongoDbEntity>("adventure");

        var adventureRespository = new AdventureMongoDbRespository(adventureCollection);

        var request = LobsterAdventureEntityFixtures.GetEntity();

        //Act

        adventureRespository.Create(request);

        //Assert
        //mockadventureCollection.Verify(service => service.InsertOne(request, It.IsAny<InsertOneOptions>(), CancellationToken.None), Times.Once());
    }

    [Fact()]
    public void Create_OnSuccess_InvokesCollectionInsertExactlyOnce()
    {
        //Arrange
        var mockadventureCollection = new Mock<IMongoCollection<LobsterAdventureMongoDbEntity>>();

        var adventureRespository = new AdventureMongoDbRespository(mockadventureCollection.Object);

        var request = LobsterAdventureEntityFixtures.GetEntity();

        //Act

        adventureRespository.Create(request);

        //Assert
        mockadventureCollection.Verify(service => service.InsertOne(request, It.IsAny<InsertOneOptions>(), CancellationToken.None), Times.Once());
    }
}