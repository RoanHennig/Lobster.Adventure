namespace Lobster.Adventure.Logic.Tests.Services;

public class CreateAdventureServiceTests
{
    [Fact()]
    public void Create_OnSuccess_ReturnsEmptyString()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateAdventureService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockPersistAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();
        mockPersistAdventureService.Setup(service => service.Persist(request)).Returns(String.Empty);

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        result.Should().BeEmpty();
    }

    [Fact()]
    public void Create_OnSuccess_InvokesValidateServiceExactlyOnce()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateAdventureService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockPersistAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        mockValidateService.Verify(service => service.Validate(request), Times.Once());
    }

    [Fact()]
    public void Create_OnSuccess_InvokesPersistServiceExactlyOnce()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateAdventureService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockPersistAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        mockPersistAdventureService.Verify(service => service.Persist(request), Times.Once());
    }

    [Fact()]
    public void Create_OnValidationFailure_ReturnsFailureReason()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateAdventureService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockPersistAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockValidateService.Setup(service => service.Validate(request)).Returns("dummyFailure");

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

}