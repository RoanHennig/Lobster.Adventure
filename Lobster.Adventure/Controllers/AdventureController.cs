namespace Lobster.Adventure.Controllers;

[ApiController]
[Route("[controller]")]
public class AdventureController : ControllerBase
{
    private readonly ILogger<AdventureController> _logger;
    private readonly ICreateAdventureService _createAdventureService;
    private readonly IGetAdventureService _getAdventureService;

    public AdventureController(ILogger<AdventureController> logger,
                               ICreateAdventureService createAdventureService,
                               IGetAdventureService readAdventureService)
    {
        _logger = logger;
        _createAdventureService = createAdventureService;
        _getAdventureService = readAdventureService;
    }

    [HttpPost(Name = "CreateAdventure")]
    public async Task<IActionResult> Create(LobsterAdventure adventure)
    {
        try
        {
            _logger.LogInformation($"Received post request {adventure.UserId} - {JsonSerializer.Serialize(adventure)}");

            var failureReason = _createAdventureService.Create(adventure);

            if (!string.IsNullOrEmpty(failureReason))
            {
                return Problem($"Failed to create adventure - {failureReason}");
            }

            return Ok();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet(Name = "CreateAdventure")]
    public async Task<IActionResult> Get(string userId, string adventureName)
    {
        try
        {
            _logger.LogInformation($"Received get request {userId} - {adventureName}");

            var adventure = _getAdventureService.Get(userId, adventureName);

            return Ok(adventure);
        }
        catch (Exception ex)
        {
            return Problem($"Could not retrieve adventure - {ex.Message}");
        }
    }
}
