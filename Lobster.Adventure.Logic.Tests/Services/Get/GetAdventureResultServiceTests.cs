namespace Lobster.Adventure.Logic.Services.Get.Tests;

public class GetAdventureResultServiceTests
{
    [Fact()]
    public void Get_OnSuccess_ReturnsAdventureResult()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockCreateLobsterAdventureResultKeyService = new Mock<ICreateLobsterAdventureResultKeyService>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var getAdventureService = new GetAdventureResultService(mockAdventureResultsRespository.Object,
                                                                mockMapLobsterAdventureResult.Object,
                                                                mockCreateLobsterAdventureResultKeyService.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockMapLobsterAdventureResult.Setup(service => service.Map(It.IsAny<LobsterAdventureResultMongoDbEntity>())).Returns(request);
        mockAdventureResultsRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureResultKey>())).Returns(LobsterAdventureResultEntityFixtures.GetEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.AdventureName, request.AdventureTakenDate.ToString());

        //Assert
        result.Should().BeOfType<LobsterAdventureResult>();
    }

    [Fact()]
    public void Get_OnSuccess_InvokesMapperExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockCreateLobsterAdventureResultKeyService = new Mock<ICreateLobsterAdventureResultKeyService>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var getAdventureService = new GetAdventureResultService(mockAdventureResultsRespository.Object,
                                                                mockMapLobsterAdventureResult.Object,
                                                                mockCreateLobsterAdventureResultKeyService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockMapLobsterAdventureResult.Setup(service => service.Map(It.IsAny<LobsterAdventureResultMongoDbEntity>())).Returns(request);
        mockAdventureResultsRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureResultKey>())).Returns(LobsterAdventureResultEntityFixtures.GetEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.AdventureName, request.AdventureTakenDate.ToString());

        //Assert
        mockMapLobsterAdventureResult.Verify(service => service.Map(It.IsAny<LobsterAdventureResultMongoDbEntity>()), Times.Once());
    }

    [Fact()]
    public void Get_OnSuccess_InvokesRepositoryReadExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockCreateLobsterAdventureResultKeyService = new Mock<ICreateLobsterAdventureResultKeyService>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var getAdventureService = new GetAdventureResultService(mockAdventureResultsRespository.Object,
                                                                mockMapLobsterAdventureResult.Object,
                                                                mockCreateLobsterAdventureResultKeyService.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockMapLobsterAdventureResult.Setup(service => service.Map(It.IsAny<LobsterAdventureResultMongoDbEntity>())).Returns(request);


        //Act

        var result = getAdventureService.Get(request.UserId, request.AdventureName, request.AdventureTakenDate.ToString());

        //Assert
        mockAdventureResultsRespository.Verify(service => service.Read(It.IsAny<LobsterAdventureResultKey>()), Times.Once());
    }

    [Fact()]
    public void Get_OnSuccess_InvokesCreateLobsterAdventureKeyServiceExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockCreateLobsterAdventureResultKeyService = new Mock<ICreateLobsterAdventureResultKeyService>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var getAdventureService = new GetAdventureResultService(mockAdventureResultsRespository.Object,
                                                                mockMapLobsterAdventureResult.Object,
                                                                mockCreateLobsterAdventureResultKeyService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockMapLobsterAdventureResult.Setup(service => service.Map(It.IsAny<LobsterAdventureResultMongoDbEntity>())).Returns(request);

        //Act

        var result = getAdventureService.Get(request.UserId, request.AdventureName, request.AdventureTakenDate.ToString());

        //Assert
        mockCreateLobsterAdventureResultKeyService.Verify(service => service.Create(
                                                                            request.UserId,
                                                                            request.AdventureName,
                                                                            request.AdventureTakenDate.ToString()), Times.Once());
    }

    [Fact()]
    public void Get_OnNullRead_ReturnsNull()
    {
        var mockMapLobsterAdventureResult = new Mock<IMapLobsterAdventureResult>();
        var mockCreateLobsterAdventureResultKeyService = new Mock<ICreateLobsterAdventureResultKeyService>();
        var mockAdventureResultsRespository = new Mock<IAdventureResultsRespository>();

        var getAdventureService = new GetAdventureResultService(mockAdventureResultsRespository.Object,
                                                                mockMapLobsterAdventureResult.Object,
                                                                mockCreateLobsterAdventureResultKeyService.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockAdventureResultsRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureResultKey>())).Returns(LobsterAdventureResultEntityFixtures.GetNullEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.AdventureName, request.AdventureTakenDate.ToString());

        //Assert
        result.Should().BeNull();
    }
}