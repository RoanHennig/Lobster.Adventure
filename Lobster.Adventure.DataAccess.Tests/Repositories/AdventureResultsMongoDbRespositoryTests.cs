namespace Lobster.Adventure.DataAccess.Repositories.Tests;

public class AdventureResultsMongoDbRespositoryTests
{

    [Fact()]
    public void Create_OnSuccess_InvokesCollectionInsertExactlyOnce()
    {
        //Arrange
        var mockadventureResultCollection = new Mock<IMongoCollection<LobsterAdventureResultEntity>>();

        var adventureRespository = new AdventureResultsMongoDbRespository(mockadventureResultCollection.Object);

        var request = LobsterAdventureResultEntityFixtures.GetEntity();

        //Act

        adventureRespository.Create(request);

        //Assert
        mockadventureResultCollection.Verify(service => service.InsertOne(request, It.IsAny<InsertOneOptions>(), CancellationToken.None), Times.Once());
    }
}