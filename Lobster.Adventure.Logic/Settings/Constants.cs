namespace Lobster.Adventure.Logic.Settings;

public static class Constants
{
    public struct FailuresMessages
    {
        public static readonly string NullAdventure = "Input is null.";
        public static readonly string NullOrEmptyAdventureName = "Adventure name is null or empty.";
        public static readonly string NullAdventureChoice = "An adventure needs at least one choice.";
        public static readonly string NullOrEmptyChoiceId = "A choice does not have an Id.";
        public static readonly string NullOrEmptyChoicePrompt = "A choice prompt cannot be empty.";
        public static readonly string AdventureAlreadyExists = "Adventure already exists!";
    }
}
