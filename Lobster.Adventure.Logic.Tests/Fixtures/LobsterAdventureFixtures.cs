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
            {
                Id = "dummyId1",
                Prompt = "dummyPrompt1",
                Choices = new List<Choice>()
                {
                    new Choice()
                    {
                        Id = "dummyId2",
                        Prompt = "dummyPrompt2",
                    },
                    new Choice()
                    {
                        Id = "dummyId3",
                        Prompt = "dummyPrompt3",
                    }
                }
            }
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
            {
                Id = "dummyId1",
                Prompt = "dummyPrompt1",
                Choices = new List<Choice>()
                {
                    new Choice()
                    {
                        Id = "dummyId2",
                        Prompt = "dummyPrompt2",
                    }
                }
            }
        };
    }

    public static LobsterAdventure GetEmptyAdventureUserId()
    {
        return new LobsterAdventure()
        {
            UserId = "",
            Name = "123",
            AdventureChoice = new Choice()
            {
                Id = "dummyId1",
                Prompt = "dummyPrompt1",
                Choices = new List<Choice>()
                {
                    new Choice()
                    {
                        Id = "dummyId2",
                        Prompt = "dummyPrompt2",
                    }
                }
            }
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

    public static LobsterAdventure GetNullOrEmptyChoiceIdAdventure()
    {
        return new LobsterAdventure()
        {
            UserId = "123",
            Name = "dummyName",
            AdventureChoice = new Choice()
            {
                Prompt = "dummyPrompt1"
            }
        };
    }

    public static LobsterAdventure GetNullOrEmptyChoicePromptAdventure()
    {
        return new LobsterAdventure()
        {
            UserId = "123",
            Name = "dummyName",
            AdventureChoice = new Choice()
            {
                Id = "dummyChoice"
            }
        };
    }
}