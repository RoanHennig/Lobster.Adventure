namespace Lobster.Adventure.Logic.Services.Create;

public class ValidateService : IValidateService
{
    public string Validate(LobsterAdventure adventure)
    {
        if(adventure is null)
        {
            return ValidationFailuresMessages.NullAdventure;
        }

        if(string.IsNullOrEmpty(adventure.Name))
        {
            return ValidationFailuresMessages.NullOrEmptyAdventureName;
        }

        if (adventure.AdventureChoice is null)
        {
            return ValidationFailuresMessages.NullAdventureChoice;
        }

        return string.Empty;
    }
}
