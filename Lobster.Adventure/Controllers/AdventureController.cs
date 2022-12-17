namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureController : ControllerBase
{
    private readonly ILogger<AdventureController> _logger;
    private readonly ICreateAdventureService _createAdventureService;

    public AdventureController(ILogger<AdventureController> logger,
                               ICreateAdventureService createAdventureService)
    {
        _logger = logger;
        _createAdventureService = createAdventureService;
    }

    [HttpPost(Name = "CreateAdventure")]
    public async Task<IActionResult> Post(LobsterAdventure adventure)
    {
        try
        {
            _logger.LogInformation($"Received request {adventure.Id} - {JsonSerializer.Serialize(adventure)}");

            var isSuccessful = _createAdventureService.Create(adventure);

            _logger.LogInformation($"Processed request {adventure.Id}");

            return Ok(isSuccessful);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}
