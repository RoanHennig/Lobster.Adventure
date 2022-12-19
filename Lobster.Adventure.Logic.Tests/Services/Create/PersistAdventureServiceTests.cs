namespace Lobster.Adventure.Logic.Services.Create.Tests;

public class PersistAdventureServiceTests
{
    [Fact()]
    public void Persist_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = persistAdventureService.Persist(request);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact()]
    public void Persist_OnSuccess_InvokesMapperExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        persistAdventureService.Persist(request);

        //Assert
        mockMapLobsterAdventure.Verify(service => service.Map(request), Times.Once());
    }

    [Fact()]
    public void Persist_OnAdventureExistsException_ReturnsValidationFailure()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockAdventureRespository.Setup(service => service.Create(It.IsAny<LobsterAdventureMongoDbEntity>())).Throws(new AdventureExistsException("", null));

        //Act

        var result = persistAdventureService.Persist(request);

        //Assert
        result.Should().Be(AdventureFailureMessages.AdventureAlreadyExists);
    }

    [Fact()]
    public void Persist_OnSuccess_InvokesRepositoryExactlyOnce()
    {
        //Arrange
        var mockMapLobsterAdventure = new Mock<IMapLobsterAdventure>();
        var mockAdventureRespository = new Mock<IAdventureRespository>();

        var persistAdventureService = new PersistAdventureService(mockAdventureRespository.Object,
                                                                  mockMapLobsterAdventure.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        persistAdventureService.Persist(request);

        //Assert
        mockAdventureRespository.Verify(service => service.Create(It.IsAny<LobsterAdventureMongoDbEntity>()), Times.Once());
    }
}