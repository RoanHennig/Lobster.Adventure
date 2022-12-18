namespace Lobster.Adventure.Logic.Services.Save;

public class ValidateAdventureResultsService : IValidateAdventureResultsService
{
    public string Validate(LobsterAdventureResult adventureResult)
    {
        if (adventureResult is null)
            return AdventureResultFailureMessages.NullAdventureResult;

        if (string.IsNullOrEmpty(adventureResult.AdventureName))
            return AdventureResultFailureMessages.NullOrEmptyAdventureName;

        if (string.IsNullOrEmpty(adventureResult.UserId))
            return AdventureResultFailureMessages.NullOrEmptyAdventureUserId;

        if (adventureResult.ChoiceResults is null || adventureResult.ChoiceResults.Count == 0)
            return AdventureResultFailureMessages.NullOrEmptyAdventureResultChoices;

        foreach(var adventureResultChoice in adventureResult.ChoiceResults)
        {
            if (string.IsNullOrEmpty(adventureResultChoice.ChoiceIdTaken))
                return AdventureResultFailureMessages.NullOrEmptyChoiceIdTaken;
            
            if (string.IsNullOrEmpty(adventureResultChoice.ChoiceId))
                return AdventureResultFailureMessages.NullOrEmptyChoiceId;
        }

        return string.Empty;
    }
}
