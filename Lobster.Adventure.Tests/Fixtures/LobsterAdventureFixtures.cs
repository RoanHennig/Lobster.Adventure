namespace Lobster.Adventure.Tests.Fixtures;

public static class LobsterAdventureFixtures
{
    public static LobsterAdventure GetAdventure()
    {
        return new LobsterAdventure()
        {
            Id = "123",
            Name = "dummyName",
            AdventureChoice = new Choice()
        };
    }
}
