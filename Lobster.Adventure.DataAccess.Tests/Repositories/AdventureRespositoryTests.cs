namespace Lobster.Adventure.DataAccess.Repositories.Tests;

public class AdventureRespositoryTests
{
    [Fact()]
    public void Create_OnSuccess_InvokesCollectionInsertExactlyOnce()
    {
        //Arrange
        var mockadventureCollection = new Mock<IMongoCollection<LobsterAdventureEntity>>();

        var adventureRespository = new AdventureMongoDbRespository(mockadventureCollection.Object);

        var request = LobsterAdventureEntityFixtures.GetEntity();

        //Act

        adventureRespository.Create(request);

        //Assert
        mockadventureCollection.Verify(service => service.InsertOne(request, It.IsAny<InsertOneOptions>(), CancellationToken.None), Times.Once());
    }

    //[Fact()]
    //public void Read_OnSuccess_CollectionFindExactlyOnce()
    //{
    //    //Arrange
    //    var mockadventureCollection = new Mock<IMongoCollection<LobsterAdventureEntity>>();

    //    var adventureRespository = new AdventureMongoDbRespository(mockadventureCollection.Object);

    //    var request = LobsterAdventureKeyFixtures.GetKey();

    //    var filter = Builders<LobsterAdventureEntity>.Filter.Eq("userId", request.UserId) &
    //                Builders<LobsterAdventureEntity>.Filter.Eq("name", request.Name);

    //    mockadventureCollection.Setup(service => service.FindSync(filter, null, CancellationToken.None)).Returns(new LobsterAdventureAsyncCurser());

    //    //Act

    //    var result = adventureRespository.Read(request);

    //    //Assert

    //    mockadventureCollection.Verify(service => service.FindSync(filter, null, CancellationToken.None), Times.Once());
    //}
}