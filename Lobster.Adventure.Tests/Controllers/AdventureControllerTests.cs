namespace Lobster.Adventure.Controllers.Tests;

public class AdventureControllerTests
{
    [Fact()]
    public async Task Post_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();
    
        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = (OkResult)await controller.Create(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }


    [Fact()]
    public async Task Post_OnSuccess_InvokesCreateAdventureServiceExactlyOnce()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        //Act
        var result = (OkResult)await controller.Create(request);

        //Assert
        mockCreateAdventureService.Verify(service => service.Create(request), Times.Once());
    }

    [Fact()]
    public async Task Post_OnFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        mockCreateAdventureService.Setup(service => service.Create(request)).Returns("dummyFailure");

        //Act

        var result = (ObjectResult)await controller.Create(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Post_OnFailure_ReturnsFailureReason()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);


        var request = LobsterAdventureFixtures.GetAdventure();

        mockCreateAdventureService.Setup(service => service.Create(request)).Returns("dummyFailure");

        //Act

        var result = (ObjectResult)await controller.Create(request);

        //Assert
        result.Value.Should().BeOfType<ProblemDetails>();
        var problem = (ProblemDetails)result.Value;
        problem.Detail.Should().Be($"Failed to create adventure - dummyFailure");
    }

    [Fact()]
    public async Task Post_OnTechnicalFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockCreateAdventureService.Setup(service => service.Create(request)).Throws(new Exception());

        //Act

        var result = (ObjectResult)await controller.Create(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = (OkObjectResult)await controller.Get(request.UserId, request.Name);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact()]
    public async Task Get_OnSuccess_ReturnsAdventure()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockReadAdventureService.Setup(service => service.Get(request.UserId, request.Name)).Returns(request);

        //Act

        var result = (OkObjectResult)await controller.Get(request.UserId, request.Name);

        //Assert
        result.Value.Should().BeOfType<LobsterAdventure>();
    }

    [Fact()]
    public async Task Get_OnTechnicalFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureController>>();
        var mockCreateAdventureService = new Mock<ICreateAdventureService>();
        var mockReadAdventureService = new Mock<IGetAdventureService>();

        var controller = new AdventureController(mockLogger.Object,
                                                 mockCreateAdventureService.Object,
                                                 mockReadAdventureService.Object);

        var request = LobsterAdventureFixtures.GetAdventure();

        mockReadAdventureService.Setup(service => service.Get(request.UserId, request.Name)).Throws(new Exception());

        //Act

        var result = (ObjectResult)await controller.Get(request.UserId, request.Name);

        //Assert
        result.StatusCode.Should().Be(500);
    }
}