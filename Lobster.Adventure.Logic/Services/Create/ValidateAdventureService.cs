namespace Lobster.Adventure.Logic.Services.Create;

public class ValidateAdventureService : IValidateAdventureService
{
    public string Validate(LobsterAdventure adventure)
    {
        if(adventure is null)
            return AdventureFailureMessages.NullAdventure;

        if (string.IsNullOrEmpty(adventure.Name))
            return AdventureFailureMessages.NullOrEmptyAdventureName;

        if (string.IsNullOrEmpty(adventure.UserId))
            return AdventureFailureMessages.NullOrEmptyAdventureUserId;

        if (adventure.AdventureChoice is null)
            return AdventureFailureMessages.NullAdventureChoice;

        return ValidateChoices(adventure.AdventureChoice);
    }

    private string ValidateChoices(Choice choice)
    {
        if(string.IsNullOrEmpty(choice.Id))
            return AdventureFailureMessages.NullOrEmptyChoiceId;

        if (string.IsNullOrEmpty(choice.Prompt))
            return AdventureFailureMessages.NullOrEmptyChoicePrompt;

        if(choice.Choices is not null)
        {
            foreach (var childChoice in choice.Choices)
                return ValidateChoices(childChoice);
        }

        return String.Empty;
    }
}
