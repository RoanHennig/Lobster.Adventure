namespace Lobster.Adventure.Logic.Services.Save.Tests;

public class PersistAdventureResultsServiceTests
{

    [Fact()]
    public void Persist_OnSuccess_InvokesMapperExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var persistAdventureResultService = new PersistAdventureResultsService(mockAdventureResultsRespository.Object,
                                                                         mockMapLobsterAdventureResult.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        persistAdventureResultService.Persist(request);

        //Assert
        mockMapLobsterAdventureResult.Verify(service => service.Map(request), Times.Once());
    }

    [Fact()]
    public void Persist_OnSuccess_InvokesRepositoryExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var persistAdventureResultService = new PersistAdventureResultsService(mockAdventureResultsRespository.Object,
                                                                         mockMapLobsterAdventureResult.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        persistAdventureResultService.Persist(request);

        //Assert
        mockAdventureResultsRespository.Verify(service => service.Create(It.IsAny<LobsterAdventureResultMongoDbEntity>()), Times.Once());
    }
}