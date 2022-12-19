namespace Lobster.Adventure.DataAccess.Repositories.Tests;

public class AdventureRespositoryTests
{

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