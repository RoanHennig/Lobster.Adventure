namespace Lobster.Adventure.Controllers.Tests;

public class AdventureControllerTests
{
    [Fact()]
    public async Task Post_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();

        var controller = new AdventureController(mockLogger.Object, mockCreateAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = (OkResult)await controller.Post(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }


    [Fact()]
    public async Task Post_OnSuccess_InvokesCreateAdventureServiceExactlyOnce()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();

        var controller = new AdventureController(mockLogger.Object, mockCreateAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act
        var result = (OkResult)await controller.Post(request);

        //Assert
        mockCreateAdventureService.Verify(service => service.Create(request), Times.Once());
    }

    [Fact()]
    public async Task Post_OnFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();

        var controller = new AdventureController(mockLogger.Object, mockCreateAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockCreateAdventureService.Setup(service => service.Create(request)).Returns("dummyFailure");

        //Act

        var result = (ObjectResult)await controller.Post(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Post_OnTechnicalFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();

        var controller = new AdventureController(mockLogger.Object, mockCreateAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockCreateAdventureService.Setup(service => service.Create(request)).Throws(new Exception());

        //Act

        var result = (ObjectResult)await controller.Post(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }
}