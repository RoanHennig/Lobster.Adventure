namespace Lobster.Adventure.Logic.Tests.Fixtures;

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

    public static LobsterAdventure GetEmptyAdventureName()
    {
        return new LobsterAdventure()
        {
            UserId = "123",
            Name = "",
            AdventureChoice = new Choice()
        };
    }

    public static LobsterAdventure GetNullAdventureChoice()
    {
        return new LobsterAdventure()
        {
            UserId = "123",
            Name = "dummy"
        };
    }
}