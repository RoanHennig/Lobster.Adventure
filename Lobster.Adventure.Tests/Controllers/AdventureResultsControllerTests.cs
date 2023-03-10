namespace Lobster.Adventure.Controllers.Tests;

public class AdventureResultsControllerTests
{
    [Fact()]
    public async Task Save_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = (OkResult)await controller.Save(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact()]
    public async Task Save_OnSuccess_InvokesSaveAdventureResultsServiceExactlyOnce()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act
        var result = (OkResult)await controller.Save(request);

        //Assert
        mockSaveAdventureResultsService.Verify(service => service.Save(request), Times.Once());
    }

    [Fact()]
    public async Task Save_OnFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        mockSaveAdventureResultsService.Setup(service => service.Save(request)).Returns("dummyFailure");

        //Act

        var result = (ObjectResult)await controller.Save(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Save_OnFailure_ReturnsFailureReason()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        mockSaveAdventureResultsService.Setup(service => service.Save(request)).Returns("dummyFailure");

        //Act

        var result = (ObjectResult)await controller.Save(request);

        //Assert
        result.Value.Should().BeOfType<ProblemDetails>();
        var problem = (ProblemDetails)result.Value;
        problem.Detail.Should().Be($"Failed to save adventure results - dummyFailure");
    }

    [Fact()]
    public async Task Save_OnTechnicalFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        mockSaveAdventureResultsService.Setup(service => service.Save(request)).Throws(new Exception());

        //Act

        var result = (ObjectResult)await controller.Save(request);

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockGetAdventureResultService.Setup(service => service.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString())).Returns(request);

        //Act

        var result = (OkObjectResult)await controller.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString());

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact()]
    public async Task Get_OnSuccess_ReturnsAdventureResult()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockGetAdventureResultService.Setup(service => service.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString())).Returns(request);

        //Act

        var result = (OkObjectResult)await controller.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString());

        //Assert
        result.Value.Should().BeOfType<LobsterAdventureResult>();
    }

    [Fact()]
    public async Task Get_OnTechnicalFailure_ReturnsStatusCode500()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockGetAdventureResultService.Setup(service => service.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString())).Throws(new Exception());

        //Act

        var result = (ObjectResult)await controller.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString());

        //Assert
        result.StatusCode.Should().Be(500);
    }

    [Fact()]
    public async Task Get_OnTechnicalFailure_ReturnsProblem()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockGetAdventureResultService.Setup(service => service.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString())).Throws(new Exception("dummy"));

        //Act

        var result = (ObjectResult)await controller.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString());

        //Assert
        result.Value.Should().BeOfType<ProblemDetails>();
        var problem = (ProblemDetails)result.Value;
        problem.Detail.Should().Be($"Could not retrieve adventure result - dummy");
    }

    [Fact()]
    public async Task Get_OnNullAdventureResult_ReturnsProblem()
    {
        //Arrange
        var mockLogger = new Mock<ILogger<AdventureResultsController>>();
        var mockSaveAdventureResultsService = new Mock<ISaveAdventureResultsService>();
        var mockGetAdventureResultService = new Mock<IGetAdventureResultService>();

        var controller = new AdventureResultsController(mockLogger.Object,
                                                        mockSaveAdventureResultsService.Object,
                                                        mockGetAdventureResultService.Object);

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();
        mockGetAdventureResultService.Setup(service => service.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString())).Returns(LobsterAdventureResultsFixtures.GetNullAdventureResult());

        //Act

        var result = (ObjectResult)await controller.Get(request.UserId,
                                                          request.AdventureName,
                                                          request.AdventureTakenDate.ToString());

        //Assert
        result.Value.Should().BeOfType<ProblemDetails>();
        var problem = (ProblemDetails)result.Value;
        problem.Detail.Should().Be($"Could not retrieve adventure result - result not found.");
    }
}