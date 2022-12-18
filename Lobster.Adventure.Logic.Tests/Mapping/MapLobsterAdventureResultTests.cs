namespace Lobster.Adventure.Logic.Mapping.Tests;

public class MapLobsterAdventureResultTests
{
    [Fact()]
    public void Map_OnSuccess_ReturnsLobsterAdventureResultEntity()
    {
        //Arrange
        var mapLobsterAdventureResult = new MapLobsterAdventureResult();

        var request = LobsterAdventureResultsFixtures.GetAdventureResult();

        //Act

        var result = mapLobsterAdventureResult.Map(request);

        //Assert
        result.Should().NotBeNull();
        result.AdventureName.Should().Be(request.AdventureName);
        result.UserId.Should().Be(request.UserId);
        result.AdventureTakenDate.Should().Be(request.AdventureTakenDate.ToString());
        result.ChoiceResults.Should().Be(JsonSerializer.Serialize(request.ChoiceResults));
    }

    [Fact()]
    public void Map_OnSuccess_ReturnsLobsterAdventureResult()
    {
        //Arrange
        var mapLobsterAdventureResult = new MapLobsterAdventureResult();

        var request = LobsterAdventureResultEntityFixtures.GetEntity();

        //Act

        var result = mapLobsterAdventureResult.Map(request);

        //Assert
        result.Should().NotBeNull();
        result.AdventureName.Should().Be(request.AdventureName);
        result.UserId.Should().Be(request.UserId);
        result.AdventureTakenDate.Should().Be(DateTime.Parse(request.AdventureTakenDate));
    }
}