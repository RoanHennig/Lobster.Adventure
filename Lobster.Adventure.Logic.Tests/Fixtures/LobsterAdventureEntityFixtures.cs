namespace Lobster.Adventure.Logic.Tests.Fixtures;

public static class LobsterAdventureEntityFixtures
{
    public static LobsterAdventureEntity GetEntity()
    {
        return new LobsterAdventureEntity()
        {
            AdventureChoice = "{\"Id\":\"dummyId1\",\"Prompt\":\"dummyPrompt1\",\"Choices\":[{\"Id\":\"dummyId2\",\"Prompt\":\"dummyPrompt2\",\"Choices\":null},{\"Id\":\"dummyId3\",\"Prompt\":\"dummyPrompt3\",\"Choices\":null}]}",
            Name = "dummyName",
            UserId = "dummyId"
        };
    }
}
