namespace Lobster.Adventure.DataAccess.Tests.Fixtures;

public static class LobsterAdventureResultEntityFixtures
{
    public static LobsterAdventureResultMongoDbEntity GetEntity()
    {
        return new LobsterAdventureResultMongoDbEntity()
        {
            ChoiceResults = "[{\"ChoiceId\":\"1\",\"ChoiceIdTaken\":\"2\"}]",
            AdventureName = "dummyName",
            UserId = "dummyId",
            AdventureTakenDate = "01/01/2022"
        };
    }
}
