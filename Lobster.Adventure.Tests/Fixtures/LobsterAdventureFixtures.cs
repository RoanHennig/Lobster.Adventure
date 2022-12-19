namespace Lobster.Adventure.Tests.Fixtures;

public static class LobsterAdventureFixtures
{
    public static LobsterAdventure GetAdventure()
    {
        return new LobsterAdventure()
        {
            UserId = "123",
            Name = "dummyName",
            AdventureChoice = new Choice()
        };
    }

    public static LobsterAdventure GetNullAdventure()
    {
        return null;
    }
}
