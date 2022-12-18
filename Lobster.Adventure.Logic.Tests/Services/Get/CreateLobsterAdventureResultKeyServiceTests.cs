namespace Lobster.Adventure.Logic.Services.Get.Tests;

public class CreateLobsterAdventureResultKeyServiceTests
{
    [Fact()]
    public void Create_OnSuccess_ReturnsLobsterAdventureKey()
    {
        //Arrange
        var createLobsterAdventureResultKeyService = new CreateLobsterAdventureResultKeyService();
        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = createLobsterAdventureResultKeyService.Create(request.UserId,
                                                                   request.AdventureName,
                                                                   request.AdventureTakenDate.ToString());

        //Assert
        result.Should().BeOfType<LobsterAdventureResultKey>();
    }

    [Fact()]
    public void Create_OnSuccess_ReturnsPopulatedLobsterAdventureKey()
    {
        //Arrange
        var createLobsterAdventureResultKeyService = new CreateLobsterAdventureResultKeyService();
        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = createLobsterAdventureResultKeyService.Create(request.UserId,
                                                                   request.AdventureName,
                                                                   request.AdventureTakenDate.ToString());

        //Assert
        result.Should().NotBeNull();
        result.UserId.Should().Be(request.UserId);
        result.AdventureName.Should().Be(request.AdventureName);
        result.AdventureTakenDate.Should().Be(request.AdventureTakenDate.ToString());
    }
}