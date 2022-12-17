namespace Lobster.Adventure.Controllers.Tests;

public class AdventureControllerTests
{
    [Fact()]
    public async Task Post_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange

        var controller = new AdventureController();
        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = (OkResult)await controller.Post(request);

        //Assert
        result.StatusCode.Should().Be(200);
    }
}