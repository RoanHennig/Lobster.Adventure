namespace Lobster.Adventure.Logic.Settings;

public static class Constants
{
    public struct ValidationFailuresMessages
    {
        public static readonly string NullAdventure = "Input is null.";
        public static readonly string NullOrEmptyAdventureName = "Adventure name is null or empty.";
        public static readonly string NullAdventureChoice = "An adventure needs at least one choice.";
    }
}
