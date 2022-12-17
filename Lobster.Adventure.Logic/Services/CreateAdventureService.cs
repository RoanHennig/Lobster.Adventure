namespace Lobster.Adventure.Logic.Services;

public class CreateAdventureService : ICreateAdventureService
{
    private readonly IValidateService _validateService;
    private readonly IEnrichmentService _enrichmentService;
    private readonly IPersistAdventureService _persistAdventureService;

    public CreateAdventureService(IValidateService validateService,
                                  IEnrichmentService enrichmentService,
                                  IPersistAdventureService persistAdventureService)
    {
        _validateService = validateService;
        _enrichmentService = enrichmentService;
        _persistAdventureService = persistAdventureService;
    }

    public string Create(LobsterAdventure adventure)
    {
        var validationFailure = _validateService.Validate(adventure);

        if(!string.IsNullOrEmpty(validationFailure))
        {
            return validationFailure;
        }

        _enrichmentService.Enrich(adventure);

        _persistAdventureService.Persist(adventure);

        return null;
    }
}
