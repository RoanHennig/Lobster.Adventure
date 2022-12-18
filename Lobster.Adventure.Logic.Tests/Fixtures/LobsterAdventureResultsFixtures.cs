namespace Lobster.Adventure.Logic.Tests.Fixtures;

public static class LobsterAdventureResultsFixtures
{
    public static LobsterAdventureResult GetAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "123",
            Name = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
        };
    }
}