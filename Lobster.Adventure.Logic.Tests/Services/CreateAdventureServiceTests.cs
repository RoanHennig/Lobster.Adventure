namespace Lobster.Adventure.Logic.Tests.Services;

public class CreateAdventureServiceTests
{
    [Fact()]
    public void Create_OnSuccess_ReturnsNull()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateService>();
        var mockEnrichmentService = new Mock<IEnrichmentService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockEnrichmentService.Object,
                                                                mockPersistAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        result.Should().BeNull();
    }

    [Fact()]
    public void Create_OnSuccess_InvokesValidateServiceExactlyOnce()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateService>();
        var mockEnrichmentService = new Mock<IEnrichmentService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockEnrichmentService.Object,
                                                                mockPersistAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        mockValidateService.Verify(service => service.Validate(request), Times.Once());
    }

    [Fact()]
    public void Create_OnSuccess_InvokesEnrichmentServiceExactlyOnce()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateService>();
        var mockEnrichmentService = new Mock<IEnrichmentService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockEnrichmentService.Object,
                                                                mockPersistAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        mockEnrichmentService.Verify(service => service.Enrich(request), Times.Once());
    }

    [Fact()]
    public void Create_OnSuccess_InvokesPersistServiceExactlyOnce()
    {
        //Arrange
        var mockValidateService = new Mock<IValidateService>();
        var mockEnrichmentService = new Mock<IEnrichmentService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockEnrichmentService.Object,
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
        var mockValidateService = new Mock<IValidateService>();
        var mockEnrichmentService = new Mock<IEnrichmentService>();
        var mockPersistAdventureService = new Mock<IPersistAdventureService>();

        var createAdventureService = new CreateAdventureService(mockValidateService.Object,
                                                                mockEnrichmentService.Object,
                                                                mockPersistAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockValidateService.Setup(service => service.Validate(request)).Returns("dummyFailure");

        //Act

        var result = createAdventureService.Create(request);

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

}