namespace Lobster.Adventure.Logic.Services;

public class CreateAdventureService : ICreateAdventureService
{
    private readonly IValidateService _validateService;
    private readonly IPersistAdventureService _persistAdventureService;

    public CreateAdventureService(IValidateService validateService,
                                  IPersistAdventureService persistAdventureService)
    {
        _validateService = validateService;
        _persistAdventureService = persistAdventureService;
    }

    public string Create(LobsterAdventure adventure)
    {
        var validationFailure = _validateService.Validate(adventure);

        if(!string.IsNullOrEmpty(validationFailure))
        {
            return validationFailure;
        }

        _persistAdventureService.Persist(adventure);

        return String.Empty;
    }
}
