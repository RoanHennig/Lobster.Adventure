namespace Lobster.Adventure.Logic.Services.Get.Tests;

public class CreateLobsterAdventureKeyServiceTests
{
    [Fact()]
    public void Create_OnSuccess_ReturnsLobsterAdventureKey()
    {
        //Arrange
        var createLobsterAdventureKeyService = new CreateLobsterAdventureKeyService();
        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createLobsterAdventureKeyService.Create(request.UserId, request.Name);

        //Assert
        result.Should().BeOfType<LobsterAdventureKey>();
    }

    [Fact()]
    public void Create_OnSuccess_ReturnsPopulatedLobsterAdventureKey()
    {
        //Arrange
        var createLobsterAdventureKeyService = new CreateLobsterAdventureKeyService();
        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = createLobsterAdventureKeyService.Create(request.UserId, request.Name);

        //Assert
        result.UserId.Should().Be(request.UserId);
        result.Name.Should().Be(request.Name);
    }
}