namespace Lobster.Adventure.Logic.Services.Save;

public class SaveAdventureResultsService : ISaveAdventureResultsService
{
    private readonly IValidateAdventureResultsService _validateAdventureResultsService;
    private readonly IPersistAdventureResultsService _persistAdventureResultsService;

    public SaveAdventureResultsService(IValidateAdventureResultsService validateAdventureResultsService,
                                       IPersistAdventureResultsService persistAdventureResultsService)
    {
        _validateAdventureResultsService = validateAdventureResultsService;
        _persistAdventureResultsService = persistAdventureResultsService;
    }

    public string Save(LobsterAdventureResult adventureResult)
    {
        var validationFailure = _validateAdventureResultsService.Validate(adventureResult);

        if (!string.IsNullOrEmpty(validationFailure))
        {
            return validationFailure;
        }

        return _persistAdventureResultsService.Persist(adventureResult);
    }
}
