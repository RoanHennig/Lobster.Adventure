namespace Lobster.Adventure.Tests.Fixtures;

public static class LobsterAdventureResultsFixtures
{
    public static LobsterAdventureResult GetAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "123",
            AdventureName = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
        };
    }
}
