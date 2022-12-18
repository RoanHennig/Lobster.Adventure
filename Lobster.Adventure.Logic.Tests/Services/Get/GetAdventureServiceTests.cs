namespace Lobster.Adventure.Logic.Services.Read.Tests;

public class GetAdventureServiceTests
{
    [Fact()]
    public void Get_OnSuccess_ReturnsAdventure()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockCreateLobsterAdventureKeyService = new Mock<ICreateLobsterAdventureKeyService>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var getAdventureService = new GetAdventureService(mockAdventureRespository.Object,
                                                              mockMapLobsterAdventure.Object,
                                                              mockCreateLobsterAdventureKeyService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockMapLobsterAdventure.Setup(service => service.Map(It.IsAny<LobsterAdventureEntity>())).Returns(request);

        //Act

        var result = getAdventureService.Get(request.UserId, request.Name);

        //Assert
        result.Should().BeOfType<LobsterAdventure>();
    }

    [Fact()]
    public void Get_OnSuccess_InvokesMapperExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockCreateLobsterAdventureKeyService = new Mock<ICreateLobsterAdventureKeyService>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var getAdventureService = new GetAdventureService(mockAdventureRespository.Object,
                                                              mockMapLobsterAdventure.Object,
                                                              mockCreateLobsterAdventureKeyService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockAdventureRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureKey>())).Returns(new LobsterAdventureEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.Name);

        //Assert
        mockMapLobsterAdventure.Verify(service => service.Map(It.IsAny<LobsterAdventureEntity>()), Times.Once());
    }

    [Fact()]
    public void Get_OnSuccess_InvokesRepositoryReadExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockCreateLobsterAdventureKeyService = new Mock<ICreateLobsterAdventureKeyService>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var getAdventureService = new GetAdventureService(mockAdventureRespository.Object,
                                                              mockMapLobsterAdventure.Object,
                                                              mockCreateLobsterAdventureKeyService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockAdventureRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureKey>())).Returns(new LobsterAdventureEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.Name);

        //Assert
        mockAdventureRespository.Verify(service => service.Read(It.IsAny<LobsterAdventureKey>()), Times.Once());
    }

    [Fact()]
    public void Get_OnSuccess_InvokesCreateLobsterAdventureKeyServiceExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockCreateLobsterAdventureKeyService = new Mock<ICreateLobsterAdventureKeyService>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var getAdventureService = new GetAdventureService(mockAdventureRespository.Object,
                                                              mockMapLobsterAdventure.Object,
                                                              mockCreateLobsterAdventureKeyService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockAdventureRespository.Setup(service => service.Read(It.IsAny<LobsterAdventureKey>())).Returns(new LobsterAdventureEntity());

        //Act

        var result = getAdventureService.Get(request.UserId, request.Name);

        //Assert
        mockCreateLobsterAdventureKeyService.Verify(service => service.Create(request.UserId, request.Name), Times.Once());
    }
}