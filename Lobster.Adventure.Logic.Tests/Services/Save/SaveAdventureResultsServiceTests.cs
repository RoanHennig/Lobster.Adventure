namespace Lobster.Adventure.Logic.Services.Save.Tests;

public class SaveAdventureResultsServiceTests
{
    [Fact()]
    public void Save_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var mockValidateAdventureResultsService = new Mock<IValidateAdventureResultsService>();
        var mockPersistAdventureResultsService = new Mock<IPersistAdventureResultsService>();

        var createAdventureService = new SaveAdventureResultsService(mockValidateAdventureResultsService.Object,
                                                                     mockPersistAdventureResultsService.Object);


        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockPersistAdventureResultsService.Setup(service => service.Persist(request)).Returns(string.Empty);

        //Act

        var result = createAdventureService.Save(request);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact()]
    public void Save_OnSuccess_InvokesValidateAdventureResultsServiceExactlyOnce()
    {
        //Arrange
        var mockValidateAdventureResultsService = new Mock<IValidateAdventureResultsService>();
        var mockPersistAdventureResultsService = new Mock<IPersistAdventureResultsService>();

        var createAdventureService = new SaveAdventureResultsService(mockValidateAdventureResultsService.Object,
                                                                     mockPersistAdventureResultsService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = createAdventureService.Save(request);

        //Assert
        mockValidateAdventureResultsService.Verify(service => service.Validate(request), Times.Once());
    }

    [Fact()]
    public void Create_OnSuccess_PersistAdventureResultsServiceExactlyOnce()
    {
        //Arrange
        var mockValidateAdventureResultsService = new Mock<IValidateAdventureResultsService>();
        var mockPersistAdventureResultsService = new Mock<IPersistAdventureResultsService>();

        var createAdventureService = new SaveAdventureResultsService(mockValidateAdventureResultsService.Object,
                                                                     mockPersistAdventureResultsService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = createAdventureService.Save(request);

        //Assert
        mockPersistAdventureResultsService.Verify(service => service.Persist(request), Times.Once());
    }
}