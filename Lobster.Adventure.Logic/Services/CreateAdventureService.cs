namespace Lobster.Adventure.Logic.Services;

public class CreateAdventureService : ICreateAdventureService
{
    private readonly IValidateService _validateService;

    public CreateAdventureService(IValidateService validateService)
    {
        _validateService = validateService;
    }

    public string Create(LobsterAdventure adventure)
    {
        var validationFailure = _validateService.Validate(adventure);

        if(!string.IsNullOrEmpty(validationFailure))
        {
            return validationFailure;
        }



        return null;
    }
}
