namespace Lobster.Adventure.DataAccess.Tests.Fixtures;

public static class LobsterAdventureKeyFixtures
{
    public static LobsterAdventureKey GetKey()
    {
        return new LobsterAdventureKey()
        {
            Name = "dummyName",
            UserId = "dummyId"
        };
    }
}
