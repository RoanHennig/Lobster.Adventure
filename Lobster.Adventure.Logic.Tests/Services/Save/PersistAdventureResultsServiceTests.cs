namespace Lobster.Adventure.Logic.Services.Save.Tests;

public class PersistAdventureResultsServiceTests
{

    [Fact()]
    public void Persist_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var persistAdventureResultService = new PersistAdventureResultsService(mockAdventureResultsRespository.Object,
                                                                         mockMapLobsterAdventureResult.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = persistAdventureResultService.Persist(request);

        //Assert
        result.Should().BeEmpty();
    }

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
    public void Persist_OnAdventureResultExistsException_ReturnsValidationFailure()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var persistAdventureResultService = new PersistAdventureResultsService(mockAdventureResultsRespository.Object,
                                                                         mockMapLobsterAdventureResult.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockAdventureResultsRespository.Setup(service => service.Create(It.IsAny<LobsterAdventureResultMongoDbEntity>())).Throws(new AdventureResultExistsException("", null));

        //Act

        var result = persistAdventureResultService.Persist(request);

        //Assert
        result.Should().Be(AdventureResultFailureMessages.AdventureResultAlreadyExists);
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