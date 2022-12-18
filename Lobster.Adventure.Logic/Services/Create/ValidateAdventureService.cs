namespace Lobster.Adventure.Logic.Services.Create;

public class ValidateAdventureService : IValidateAdventureService
{
    public string Validate(LobsterAdventure adventure)
    {
        if(adventure is null)
            return FailuresMessages.NullAdventure;

        if (string.IsNullOrEmpty(adventure.Name))
            return FailuresMessages.NullOrEmptyAdventureName;

        if (adventure.AdventureChoice is null)
            return FailuresMessages.NullAdventureChoice;

        return ValidateChoices(adventure.AdventureChoice);
    }

    private string ValidateChoices(Choice choice)
    {
        if(string.IsNullOrEmpty(choice.Id))
            return FailuresMessages.NullOrEmptyChoiceId;

        if (string.IsNullOrEmpty(choice.Prompt))
            return FailuresMessages.NullOrEmptyChoicePrompt;

        if(choice.Choices is not null)
        {
            foreach (var childChoice in choice.Choices)
                return ValidateChoices(childChoice);
        }

        return String.Empty;
    }
}
