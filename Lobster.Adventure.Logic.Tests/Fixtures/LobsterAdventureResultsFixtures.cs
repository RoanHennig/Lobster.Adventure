namespace Lobster.Adventure.Logic.Tests.Fixtures;

public static class LobsterAdventureResultsFixtures
{
    public static LobsterAdventureResult GetAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            AdventureName = "dummyName",
            AdventureTakenDate = DateTime.Now,
            ChoiceResults = new List<ChoiceResult>()
            {
                new ChoiceResult()
                {
                    ChoiceId = "1",
                    ChoiceIdTaken = "2"
                }
            }
        };
    }

    public static LobsterAdventureResult GetNullChoiceIdTakenAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            AdventureName = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
            {
                new ChoiceResult()
                {
                    ChoiceId = "1"
                }
            }
        };
    }

    public static LobsterAdventureResult GetNullChoiceIdAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            AdventureName = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
            {
                new ChoiceResult()
                {
                    ChoiceIdTaken = "2"
                }
            }
        };
    }

    public static LobsterAdventureResult GetNullAdventureNameAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            ChoiceResults = new List<ChoiceResult>()
            {
                new ChoiceResult()
                {
                    ChoiceId = "1",
                    ChoiceIdTaken = "2"
                }
            }
        };
    }

    public static LobsterAdventureResult GetNullUserIdAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            AdventureName = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
            {
                new ChoiceResult()
                {
                    ChoiceId = "1",
                    ChoiceIdTaken = "2"
                }
            }
        };
    }

    public static LobsterAdventureResult GetNullChoicesAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            AdventureName = "dummyName"
        };
    }

    public static LobsterAdventureResult GetEmptyChoicesAdventureResult()
    {
        return new LobsterAdventureResult()
        {
            UserId = "dummyUserId",
            AdventureName = "dummyName",
            ChoiceResults = new List<ChoiceResult>()
        };
    }

    public static LobsterAdventureResult GetNullAdventureResult()
    {
        return null;
    }
}