namespace Lobster.Adventure.Logic.Services.Create;

public class CreateAdventureService : ICreateAdventureService
{
    private readonly IValidateAdventureService _validateService;
    private readonly IPersistAdventureService _persistAdventureService;

    public CreateAdventureService(IValidateAdventureService validateService,
                                  IPersistAdventureService persistAdventureService)
    {
        _validateService = validateService;
        _persistAdventureService = persistAdventureService;
    }

    public string Create(LobsterAdventure adventure)
    {
        var validationFailure = _validateService.Validate(adventure);

        if (!string.IsNullOrEmpty(validationFailure))
        {
            return validationFailure;
        }

        return _persistAdventureService.Persist(adventure);
    }
}
