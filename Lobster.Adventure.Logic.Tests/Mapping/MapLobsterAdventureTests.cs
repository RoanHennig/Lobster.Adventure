namespace Lobster.Adventure.Logic.Mapping.Tests;

public class MapLobsterAdventureTests
{
    [Fact()]
    public void Map_OnSuccess_ReturnsLobsterAdventureEntity()
    {
        //Arrange
        var mapLobsterAdventure = new MapLobsterAdventure();

        var request = LobsterAdventureFixtures.GetAdventure();

        //Act

        var result = mapLobsterAdventure.Map(request);

        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.UserId.Should().Be(request.UserId);
        result.AdventureChoice.Should().Be(JsonSerializer.Serialize(request.AdventureChoice));
    }

    [Fact()]
    public void Map_OnSuccess_ReturnsLobsterAdventure()
    {
        //Arrange
        var mapLobsterAdventure = new MapLobsterAdventure();

        var request = LobsterAdventureEntityFixtures.GetEntity();

        //Act

        var result = mapLobsterAdventure.Map(request);

        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.UserId.Should().Be(request.UserId);
        result.AdventureChoice.Should().BeOfType<Choice>();
    }
}